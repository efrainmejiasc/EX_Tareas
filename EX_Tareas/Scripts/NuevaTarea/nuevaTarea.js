$(document).ready(function () {
    console.log("ready!");
    ActualizarFechas();
});


function MostrarNuevaTareaPopUp(idTareaPlantilla) { 
    $('#MainContent_idTareaPlantilla').val(idTareaPlantilla)
    $('#nuevaTarea').show();
}

function OcultarNuevaTareaPopUp() {
    $('#nuevaTarea').hide();
}

function ActualizarFechas() {
    var now = new Date();
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var today = now.getFullYear() + "-" + (month) + "-" + (day);
    $('#MainContent_fechaInicio').val(today);
    $('#MainContent_fechaFinal').val(today);
}

