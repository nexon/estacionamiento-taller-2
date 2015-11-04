$(document).ready(function () {

    // se selecciona el boton editar de cada personal
    $(".personal-editar-eliminar").find(".green").on("click", function (e) {

        // se obtienen los atributos del personal que se quiere editar
        var nombre = $(this).attr("data-nombre");
        var rut = $(this).attr("data-rut");
        var email = $(this).attr("data-email");
        var telefono = $(this).attr("data-telefono");

        // se muestran los valores de los atributos que se quieren editar
        $("#personal-editar-nombre").val(nombre);
        $("#personal-editar-rut").val(rut);
        $("#personal-editar-email").val(email);
        $("#personal-editar-telefono").val(telefono);

        /* -solo el rut atributo tiene un campo hidden, porque no se puede editar */
        $("#personal-editar-rut-hidden").val(rut);

        // se muestra el modal dialog de editar personal
        $(this).attr("#modalEditar").dialog("open");

        return false;
    });


    // se selecciona el boton eliminar de cada personal
    $(".personal-editar-eliminar").find(".red").on("click", function (e) {

        // se obtienen los atributos del personal que se quiere editar
        var nombre = $(this).attr("data-nombre");
        var rut = $(this).attr("data-rut");
        var email = $(this).attr("data-email");
        var telefono = $(this).attr("data-telefono");

        // se muestran los valores de los atributos que se quieren editar
        $("#personal-eliminar-nombre").val(nombre);
        $("#personal-eliminar-rut").val(rut);
        $("#personal-eliminar-email").val(email);
        $("#personal-eliminar-telefono").val(telefono);

        /* -cada atributo tiene un campo hidden
           -los atributos se deben modificar para ser enviado por post cuando se elimine un personal
        */
        $("#personal-eliminar-nombre-hidden").val(nombre);
        $("#personal-eliminar-rut-hidden").val(rut);
        $("#personal-eliminar-email-hidden").val(email);
        $("#personal-eliminar-telefono-hidden").val(telefono);

        // se muestra el modal dialog de eliminar personal
        $(this).attr("#modalEliminar").dialog("open");

        return false;
    });
  


});