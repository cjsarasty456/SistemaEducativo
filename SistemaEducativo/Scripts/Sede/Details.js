function CargarMunicipioNacimiento(Departamento) {
    var campo = document.getElementById('CmpMunicipioNacimiento');
    var data = Departamento.value;
    var url = "/Estudiante/ConsultaListaMunicipio";
    $.post(url, { "CodDepartamento": data }).done(function (data) {
        campo.innerHTML = "<option disabled selected>Seleccione una opción</option>";
        data.forEach(MunicipioNacimiento);
    });
}

function MunicipioNacimiento(item, index) {
    var campo = document.getElementById('CmpMunicipioNacimiento');
    campo.innerHTML += "<option value=" + item.CodMunicipio + ">" + item.NomMunicipio + "</option>";
}

function CargarMunicipioDomicilio(Departamento) {
    var campo = document.getElementById('CmpMunicipioDomicilio');
    var data = Departamento.value;
    var url = "/Estudiante/ConsultaListaMunicipio";
    $.post(url, { "CodDepartamento": data }).done(function (data) {
        campo.innerHTML = "<option disabled selected>Seleccione una opción</option>";
        data.forEach(MunicipioDomicilio);
    });
}

function MunicipioDomicilio(item, index) {
    var campo = document.getElementById('CmpMunicipioDomicilio');
    campo.innerHTML += "<option value="+item.CodMunicipio+">"+item.NomMunicipio+"</option>";
}