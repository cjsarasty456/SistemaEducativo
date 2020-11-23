

//function NuevoEstudiante() {
//    var ObjEstudiante = {
//        id : "",
//        TipoDocumentoIdentidad: document.getElementById("CmpTipoDocumentoIdentidad").value,
//        DocumentoIdentidad: document.getElementById("CmpDocumentoIdentidad").value,
//        PrimerNombre: document.getElementById("CmpPrimerNombre").value,
//        SegundoNombre: document.getElementById("CmpSegundoNombre").value,
//        PrimerApellido: document.getElementById("CmpPrimerApellido").value,
//        SegundoApellido: document.getElementById("CmpSegundoApellido").value,
//        Genero: document.getElementById("CmpGenero").value,
//        FechaNacimiento: document.getElementById("CmpFechaNacimiento").value,
//        IdInstitucion: document.getElementById("CmpIdInstitucion").value,
//        Jornada: document.getElementById("CmpIdJornada").value,
//        IdSede: document.getElementById("CmpIdSede").value,
//        Grado: document.getElementById("CmpGrado").value
//    };
//    $.post(
//        'Estudiante/Edit', JSON.stringify(ObjEstudiante)
//    ).done(function (response) {
//        MostrarMensaje(response.TituloMensaje, response.CuerpoMensaje, response.tipoMensaje);
//        CargarListaEstudiante();
//    });
//    //$.ajax({
//    //    async: true,
//    //    type: 'POST',
//    //    dataType: 'JSON',
//    //    data: JSON.stringify(ObjEstudiante),
//    //    url: 'Estudiante/Edit',
//    //    success: function (response) {
//    //        MostrarMensaje(response.TituloMensaje, response.CuerpoMensaje, response.tipoMensaje);
//    //    }
//    //});
//}

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

//función para mostrar mensajes

function MostrarMensaje(Titulo, Mensaje, Tipo) {
    switch (Tipo) {
        case "success":
            toastr.success(Mensaje, Titulo, "Toastr");
            break;
        case "danger":
            toastr.danger(Titulo, Mensaje, "Toastr");
            break;
        case "warning":
            toastr.warning(Titulo, Mensaje, "Toastr");
            break;
    }
}