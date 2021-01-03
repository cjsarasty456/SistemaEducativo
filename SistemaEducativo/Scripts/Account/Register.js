$(function () {
    //Initialize Select2 Elements
    $('.select2').select2()

    //Initialize Select2 Elements
    $('.select2bs4').select2({
        theme: 'bootstrap4'
    })

})
ContrasenaPredeterminado();

function CargarMunicipioExpedicion(Departamento) {
    var campo = document.getElementById('CmpCodMunicipioExpedicion');
    var data = Departamento.value;
    var url = "/Account/ConsultaListaMunicipio";
    $.post(url, { "CodDepartamento": data }).done(function (data) {
        campo.innerHTML = "<option disabled selected>Seleccione una opción</option>";
        data.forEach(AgregarMuniciosExpedicion);
    });
}

function AgregarMuniciosExpedicion(item, index) {
    var campo = document.getElementById('CmpCodMunicipioExpedicion');
    campo.innerHTML += "<option value=" + item.CodMunicipio + ">" + item.NomMunicipio + "</option>";
}

function CargarSede(Institucion) {
    var campo = document.getElementById('CmpIdSede');
    var data = Institucion.value;
    var url = "/Account/ConsultaListaSedes";
    $.post(url, { "Institucion": data }).done(function (data) {
        campo.innerHTML = "<option disabled selected>Seleccione una opción</option>";
        data.forEach(AgregarSedes);
    });
}

function AgregarSedes(item, index) {
    var campo = document.getElementById('CmpIdSede');
    campo.innerHTML += "<option value=" + item.id + ">" + item.Nombre + "</option>";
}

function ContrasenaPredeterminado() {
    var Documento = document.getElementById("Documento").value;
    var Apellido = document.getElementById("PrimerApellido").value;
    var Contrasena = document.getElementById("cmpPassword");
    var PasswordConfirm = document.getElementById("cmpPasswordConfirm");
    Contrasena.value = Apellido.substring(0, 1) + Documento;
    PasswordConfirm.value = Contrasena.value;

}

function Mayuscyla(e) {
    e.value = e.value.toUpperCase();
}