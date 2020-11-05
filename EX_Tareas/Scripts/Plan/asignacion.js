$(document).ready(function () {
    console.log("ready!");
});

function MostrarAsignacionPopUp() {
   
    $('#asignacionFmr').show();
}

function OcultarAsignacionPopUp() {
    $('#asignacionFmr').hide();
}

function EditRow(idTarea) {
    console.log(idTarea)
    $.ajax({
        method: "POST",
        url: "/Views/Plan/Asignacion.aspx/DatosTareaPlantilla",
        data: JSON.stringify({ idTarea: idTarea }),
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        success: function (x) {
            var m = JSON.parse(x.d);
            $('#MainContent_idPlantilla').val(m.IdPlantilla);
            $('#MainContent_nombrePlantilla').val(m.NombrePlantilla);
            $('#MainContent_idTarea').val(m.IdTarea);
            $('#MainContent_id_Tarea').val(m.IdTarea);
            $('#MainContent_tarea').val(m.Tarea);
            $('#MainContent_tipoTarea').val(m.TipoTarea);
            $('#MainContent_estadoTarea').val(m.EstadoTarea);
            $('#MainContent_tipoServicio').val(m.TipoServicio);
            $('#MainContent_tareaValor').val(m.TareaValor);
            $('#MainContent_fechaInicio').val(SetFechaTarea(m.FechaInicio));
            $('#MainContent_fechaFinal').val(SetFechaTarea(m.FechaFinal));
            $('#MainContent_descripcion').val(m.Descripcion);
            $('#MainContent_tiempoEstimado').val(m.TiempoEstimado);
            $('#MainContent_orden').val(m.Orden);
        },
        complete: function () {
            MostrarAsignacionPopUp();
        }
    });
}

function SetFechaTarea(val) {
    var p = val.split('/');
    var fecha = p[2] + '-' + p[1] + '-' + p[0]
    return fecha;
}