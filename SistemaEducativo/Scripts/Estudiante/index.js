//funciones Cargar Lista Estudiante
CargarListaEstudiante();
function CargarListaEstudiante() {
    var pagina = window.location.search;
    var TipoDocumento = "TipoDocumento=";
    if (document.getElementById('CmpTipoDocumentoIdentidad').value != null)
        TipoDocumento += document.getElementById('CmpTipoDocumentoIdentidad').value;
    var Documento = "&Documento=";
    if (document.getElementById('CmpDocumentoIdentidad').value != null)
        Documento += document.getElementById('CmpDocumentoIdentidad').value;
    var Sede = "&Sede=";
    if (document.getElementById('CmpSede').value != null)
        Sede += document.getElementById('CmpSede').value;
    if (pagina == "")
        pagina = "&pagina=1";
    $("#contenedor").load("/Estudiante/ListaEstudiante?" + TipoDocumento + Documento + Sede + pagina);
}
//funciones para agregr un estudiante
function nuevoEstudiante() {
    $("#modal-content").load("/Estudiante/New");
}

//funciones para eliminar estudiante
function CargarIdEstudianteEliminar(id) {
    document.getElementById("IdItem").value = id;
}

function EliminarEstudiante() {
    var Id = document.getElementById("IdItem").value;
    $.post(
        '/Estudiante/Delete', { id: Id }
    ).done(function (response) {
        MostrarMensaje(response.TituloMensaje, response.CuerpoMensaje, response.tipoMensaje);
        CargarListaEstudiante();
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
