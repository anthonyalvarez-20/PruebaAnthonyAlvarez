
var table;
var html = '';
var check = '';
$(document).ready(function () {
    obtenerAseg();
    table = $("#aseguradoratabla").DataTable({
        destroy: true,
        responsive: true,
    });

    $('#modalSeguro').modal('hide')
});


$("#fileUpload").on("change", function () {
    var dataString = new FormData();
    var html2 = "";
    var selectedFile = ($("#fileUpload"))[0].files[0];
    dataString.append("fileUpload", selectedFile);
    if (selectedFile) {
        html2 += "<b>Archivo subido con exito</b>";
        $.ajax({
            xhr: function () {
                let xhr = new window.XMLHttpRequest();
                return xhr;
            },
            url: "/Asegurados/Guardar",
            type: "Post",
            data: dataString,
            contentType: false,
            processData: false,
            cache: false,
            beforeSend: () => {
                $("#fileUpload").prop("disabled", true);
            }
        }).done(res => {
            var datos = JSON.parse(res);
            if (datos["codRespuesta"] == "200") {
                window.alert(datos["mensaje"]);
                $("#fileUpload").prop("disabled", false);
                table.clear().draw();
                obtenerAseg();
            } else {
                window.alert(datos["mensaje"]);
                $("#fileUpload").prop("disabled", false);
            }

        }).fail(err => {
            console.log("Ocurrio un error")
        })
    } else {
        console.log("No se ha cargado ningun archivo");
    }
});



function obtenerAseg() {
    $.ajax({
        url:"/Asegurados/ObtenerAsegurados",
        type: "Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(res => {
        var datos = JSON.parse(res);
        if (datos["codRespuesta"] == "200") {

            $.each(datos["data"], function (Keydata, value) {
                ObtenerSeg(value.IdPersona);
                table.row.add([
                    value.Cedula,
                    value.NombrePersona,
                    value.Edad,
                    value.Telefono,
                    html
                ]).draw();
                html = '';
            });

        }
    }).fail(err => {
        console.log("Ocurrio un error")
    })
};

function ObtenerSeg(id) {
    var idbuscar = { id: id }

    $.ajax({
        url: "/Asegurados/BuscarSeguroAseg",
        type: "Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(idbuscar),
        async:false
    }).done(res => {
        var datos = JSON.parse(res);
        if (datos["codRespuesta"] == "200") {

            if (datos["mensaje"] == "No hay elementos") {
                html += `<button type="button" class="btn btn-success" onclick="abrirModal(${id})" style="margin-left:2vw">Ingresar Seguro</button>`;
            }
        

            
        }
    }).fail(err => {
        console.log("Ocurrio un error")
    })
}


function abrirModal(id) {
    $('#modalSeguro').modal({ show: true });
    obtenerSeguro(id);
}

function obtenerSeguro(id) {
    var checkTemp = "";
    var botonIngresar = "";
    $.ajax({
        url: "/Asegurados/ObtenerSeguros",
        type: "Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false
    }).done(res => {
        var datos = JSON.parse(res);
        if (datos["codRespuesta"] == "200") {

            $.each(datos["data"], function (Keydata, value) {
                check += `
                            <label><input type="checkbox" id="${value.CodigoSeguro}" value="${value.CodigoSeguro}">${value.NombreSeguro}</label><br>
                         `
                checkTemp += check;
                check = "";
            });
            botonIngresar += `<button type="button" class="btn btn-primary" onclick="ingresarSegurosAseg(${id})" >Ingresar</button>
                              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>`
            $("#checkModal").html(checkTemp);
            $("#modalFooter").html(botonIngresar);
        }
    }).fail(err => {
        console.log("Ocurrio un error")
    })
}

function ingresarSegurosAseg(id) {
    var seguroseleccionados = new Array();

    $('input[type=checkbox]:checked').each(function () {
        seguroseleccionados.push($(this).val());
    });

    var SeguroAseg = {
        idAsegurado: id,
        idSeguros: seguroseleccionados
    };
    $.ajax({
        url: "/Asegurados/ingresarSeguroAseg",
        type: "Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(SeguroAseg),
        async: false
    }).done(res => {
        var datos = JSON.parse(res);
        if (datos["codRespuesta"] == "200") {

            window.alert(datos["mensaje"]);
            table.clear().draw();
            obtenerAseg();
            $('#modalSeguro').modal('hide')

        } else {
            window.alert(datos["mensaje"]);
        }
    }).fail(err => {
        console.log("Ocurrio un error")
    })

}
