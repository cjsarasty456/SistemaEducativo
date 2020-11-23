
function verificarEstudiante() {
    var TipoDocumento = document.getElementById('CmpTipoDocumentoIdentidad').value;
    var Documento = document.getElementById('CmpDocumentoIdentidad').value;
    
    var url = "/Estudiante/ConsultaEstudianteExiste";
    var data = { "TipoDocumento": TipoDocumento, "Documento": Documento };
    $.post(url, data).done(function (respuesta) {
        var contenedorMensaje = document.getElementById('contenedorMensaje');
        var TipoMensaje = document.getElementById('TipoMensaje');
        var TituloMensaje = document.getElementById('TituloMensaje');
        var cuerpoMensaje = document.getElementById('CuerpoMensaje');
        if (respuesta.Id != null) {
            contenedorMensaje.style.cssText = "";
            TipoMensaje.removeAttribute("class");
            TipoMensaje.setAttribute("class","alert alert-danger");
            TituloMensaje.innerHTML = "<i class='fa fa-exclamation-circles'></i> Error";
            cuerpoMensaje.innerHTML ="Actualmente existe un estudiante Existe un estudiante con el mismo Tipo de Identificación y Número de documento"
        } else {
            contenedorMensaje.style.cssText = "";
            TituloMensaje.innerHTML = "<i class='far fa - check - circle'></i> Excelente";
            TipoMensaje.removeAttribute("class");
            TipoMensaje.setAttribute("class","alert alert-success");
            cuerpoMensaje.innerHTML = "No existe otro tipo de registro con este Tipo de Identificación y Número de documento"
        }
    });
}