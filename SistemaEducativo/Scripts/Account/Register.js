ContrasenaPredeterminado();

function CargarMunicipioExpedicion(Departamento) {
    var campo = document.getElementById('CodMunicipioExpedicion');
    var data = Departamento.value;
    var url = "/Account/ConsultaListaMunicipio";
    $.post(url, { "CodDepartamento": data }).done(function (data) {
        campo.innerHTML = "<option disabled selected>Seleccione una opción</option>";
        data.forEach(AgregarMuniciosExpedicion);
    });
}

function AgregarMuniciosExpedicion(item, index) {
    var campo = document.getElementById('CodMunicipioExpedicion');
    campo.innerHTML += "<option value=" + item.CodMunicipio + ">" + item.NomMunicipio + "</option>";
}

function CargarSede(Institucion) {
    var campo = document.getElementById('IdSede');
    var data = Institucion.value;
    var url = "/Account/ConsultaListaSedes";
    $.post(url, { "Institucion": data }).done(function (data) {
        campo.innerHTML = "<option disabled selected>Seleccione una opción</option>";
        data.forEach(AgregarSedes);
    });
}

function AgregarSedes(item, index) {
    var campo = document.getElementById('IdSede');
    campo.innerHTML += "<option value=" + item.Id + ">" + item.Nombre + "</option>";
}

function ContrasenaPredeterminado() {
    var Documento = document.getElementById("Documento").value;
    var Apellido = document.getElementById("PrimerApellido").value;
    var Contrasena = document.getElementById("cmpPassword");
    var PasswordConfirm = document.getElementById("cmpPasswordConfirm");
    Contrasena.value = Apellido.substring(0, 1) + Documento;
    PasswordConfirm.value = Contrasena.value;

}

function Mayuscula(e) {
    e.value = e.value.toUpperCase();
}