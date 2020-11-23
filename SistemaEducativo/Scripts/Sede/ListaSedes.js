
function nuevaSede() {
    $("#modal-content").load("/Sede/NuevaSede");
}
function EditarSede(id) {
    $("#modal-content").load("/Sede/Details?id="+id);
}
function ModalEliminar(id) {
    //$("#modal-content").load();
    document.getElementById("IdItem").value = id;
}