$(document).ready(function () {
    var error = false;
});

function verificarForm() {
    verificarNombre();
    verificarEmail();
    verificarPass();
    confirmarPass();
    verificarTelefono();
    //verificarRut();
}

function verificarEmail(email)
{
    var email = $("#Email").val();
    $("#Email-Error").empty();
    $("#Email-form-group").removeClass("has-error");

    if (validarEmail(email)) {
        existeEmail(email);
        
    } else {
        $("#Email-form-group").addClass("has-error");
        $("#Email-Error").append("El correo no es valido");
        error = true;
    }
}

function verificarNombre() {
    var nombre = $("#Nombre").val();
    $("#Nombre-Error").empty();
    $("#Nombre-form-group").removeClass("has-error");

    if (nombre == "") {
        $("#Nombre-form-group").addClass("has-error");
        $("#Nombre-Error").append("Complete este campo");
        error = true;
    }
}

function verificarTelefono(telefono) {
    var telefono = $("#Telefono").val();
    $("#Telefono-Error").empty();
    $("#Telefono-form-group").removeClass("has-error");

    if (telefono) {
        if (isNaN(telefono)) {
            $("#Telefono-form-group").addClass("has-error");
            $("#Telefono-Error").append("El campo solo debe contener números");
            error = true;
        } else if (String(telefono).length != 8) {
            $("#Telefono-form-group").addClass("has-error");
            $("#Telefono-Error").append("El número debe contener 8 digitos");
            error = true;
        }
    }
    
}

function verificarRut() {
    var rut = $("#Rut").val();
    $("#Rut-Error").empty();
    $("#Rut-form-group").removeClass("has-error");

    if (isNaN(rut)) {
        $("#Rut-form-group").addClass("has-error");
        $("#Rut-Error").append("El campo solo debe contener números");
        error = true;
    } else if (String(rut).length != 8) {
        $("#Rut-form-group").addClass("has-error");
        $("#Rut-Error").append("El RUT debe contener 8 digitos");
        error = true;
    }

}

function verificarPass() {
    $("#Actual-Pass-Error").empty();
    $("#Actual-Pass-form-group").removeClass("has-error");
    var pass = $("#contraseñaActual").val();
    var values = {
        contraseña: pass
    }

    $.ajax ({
        type: 'post',
        url: '/Cuenta/VerificarContraseña/',
        data: values,
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.valida == false) {
                $("#Actual-Pass-Error").append("Contraseña Invalida");
                $("#Actual-Pass-form-group").addClass("has-error");
                error = true;
            }
        }
        });

    /*$.post('/Cuenta/VerificarContraseña/', values, function (data) {
        if (data.valida == false) {
            $("#Actual-Pass-Error").append("Contraseña Invalida");
            $("#Actual-Pass-form-group").addClass("has-error");
            error = true;
        }
    })*/

}
function confirmarPass() {
    $("#Pass-Error").empty();
    $("#Pass1-form-group").removeClass("has-error");
    $("#Pass2-form-group").removeClass("has-error");

    if ($("#passNueva1").val() != $("#passNueva2").val()) {
        $("#Pass1-form-group").addClass("has-error");
        $("#Pass2-form-group").addClass("has-error");
        $("#Pass-Error").append("Las contraseñas no coinciden");
        error = true;
    }
}

function existeEmail(email) {
    
    var values =
        {
            email: email
        }
   
    $.ajax({
        type: 'post',
        url: '/Cuenta/ExisteEmail/',
        data: values,
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.existe == true) {
                $("#Email-Error").append("El correo ya existe");
                $("#Email-form-group").addClass("has-error");
                error = true;
            }
        }
    });

    /*$.post('/Cuenta/ExisteEmail/', values, function (data) {
        if (data.existe == true) {
            $("#Email-Error").append("El correo ya existe");
            $("#Email-form-group").addClass("has-error");
            error = true;
        }
    })*/
}

function validarEmail(email) {
    var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
    return re.test(email);
}

function submitForm()
{
    
    error = false;

    verificarForm();
    console.log(error);

    if (error == false) {
        console.log("entreeeee!!!");
        $("#editarCuenta").submit();
    }
}