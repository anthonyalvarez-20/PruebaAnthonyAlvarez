$(document).ready(function () {
   
    table = $("#segurotabla").DataTable({
        destroy: true,
        responsive: true,
    });
    $("#cedulaBuscar").hide();
    $("#codigoBuscar").hide();
    $("#labelcedula").hide();
    $("#labelCodigo").hide();
    $("#botonCedula").hide();
    $("#botonCodigo").hide();
    obtenerSeg();
});



$("#ceduBusqueda").on("click", function () {
    $("#codigoBuscar").hide();
    $("#labelCodigo").hide();
    $("#botonCodigo").hide();
    $("#cedulaBuscar").show();
    $("#labelcedula").show();
    $("#botonCedula").show();
});

$("#codiBusqueda").on("click", function () {
    $("#cedulaBuscar").hide();
    $("#labelcedula").hide();
    $("#botonCedula").hide();
    $("#labelCodigo").show();
    $("#codigoBuscar").show();
    $("#botonCodigo").show();

});

function obtenerSeg() {
    $.ajax({
        url: "/Home/ObtenerSegAseg",
        type: "Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(res => {
        var datos = JSON.parse(res);
        if (datos["codRespuesta"] == "200") {

            $.each(datos["data"], function (Keydata, value) {
                
                table.row.add([
                    value.CodigoSeguro,
                    value.NombreSeguro,
                    value.NombrePersona,
                    value.Cedula
                ]).draw();
            });

        }
    }).fail(err => {
        console.log("Ocurrio un error")
    })
}

$("#botonReset").on("click", function (e) {
    e.preventDefault();
    table.clear().draw();
    obtenerSeg();
})

$("#botonCedula").on("click", function (e) {
    e.preventDefault();
    var cedula = $("#cedulaBuscar").val();
    var cedulaData = { cedula: cedula };
    $.ajax({
        url: "/Home/BuscarCedula",
        method: "Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(cedulaData),
    }).done(res => {
        var datos = JSON.parse(res);
        if (datos["codRespuesta"] == "200") {
            table.clear().draw();
            $.each(datos["data"], function (Keydatas, value) {
                table.row.add([
                    value.CodigoSeguro,
                    value.NombreSeguro,
                    value.NombrePersona,
                    value.Cedula
                ]).draw();
            });
        } else {
            window.alert(datos["mensaje"]);
        }


    })
});



$("#botonCodigo").on("click", function (e) {
    e.preventDefault();
    var codigo = $("#codigoBuscar").val();
    var codigoData = { codigo: codigo };
    $.ajax({
        url: "/Home/BuscarCodigo",
        method: "Post",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(codigoData),
    }).done(res => {
        var datos = JSON.parse(res);
        if (datos["codRespuesta"] == "200") {
            table.clear().draw();
            $.each(datos["data"], function (Keydatas, value) {
                table.row.add([
                    value.CodigoSeguro,
                    value.NombreSeguro,
                    value.NombrePersona,
                    value.Cedula
                ]).draw();
            });
        } else {
            window.alert(datos["mensaje"]);
        }


    })
});


