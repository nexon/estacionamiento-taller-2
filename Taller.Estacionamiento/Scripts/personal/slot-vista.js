$(document).ready(function () {

    // se selecciona el boton editar de cada personal
    $(".slot-editar-eliminar").find(".green").on("click", function (e) {

        var codigo = $(this).attr("data-codigo");
        var estado = $(this).attr("data-estado");

        $("#slot-editar-codigo").val(codigo);
        $("#slot-editar-estado").val(estado);

        $(this).attr("#modalEditarSlot").dialog("open");

        return false;
    });


    // se selecciona el boton eliminar de cada personal
    $(".slot-editar-eliminar").find(".red").on("click", function (e) {

        var codigo = $(this).attr("data-codigo");
        var estado = $(this).attr("data-estado");

        $("#slot-eliminar-codigo").val(codigo);
        $("#slot-eliminar-estado").val(estado);

        /* -cada atributo tiene un campo hidden
          -los atributos se deben modificar para ser enviado por post cuando se elimine un personal
       */
        $("#slot-eliminar-codigo-hidden").val(codigo);
        $("#slot-eliminar-estado-hidden").val(estado);

        $(this).attr("#modalEliminarSlot").dialog("open");

        return false;


    });



});