function validateEmail(email) {
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
}


$(document).ready(function () {
    $("#mailInput").on("input", function () {
        var email = $(this).val();

        if (validateEmail(email)) {
            $("#emailError").text("");
        } else {
            $("#emailError").text("Por favor ingresa un correo electrónico válido");
        }
    });
});


