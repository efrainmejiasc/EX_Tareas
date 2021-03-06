﻿$(document).ready(function () {
    console.log("ready!");
    EncabezadoPlantilla();
    ActualizarFechas();
});

function MostrarNuevaTareaPopUp(idTareaPlantilla) {
    if (idTareaPlantilla === '') {
        $('#MainContent_orden').hide();
        $('#lblOrden').hide()
        $('#lblIdTarea').hide()
    } else {
        $('#MainContent_orden').show();
        $('#lblOrden').show()
        $('#lblIdTarea').show();
    }
    $('#lblIdTarea').text(idTareaPlantilla);
    $('#MainContent_id_Tarea').val(idTareaPlantilla)
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

function SetFechaTarea(val) {
    var p = val.split('/');
    var fecha = p[2] + '-' + p[1] + '-' + p[0]
    return fecha;
}

function EditRow(idTareaPlantilla) {
    console.log(idTareaPlantilla)
    $.ajax({
        method: "POST",
        url: "/Views/Actividad/Tareas.aspx/DatosTareaPlantilla",
        data: JSON.stringify({ idTareaPlantilla: idTareaPlantilla }),
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        success: function (x) {
            var m = JSON.parse(x.d);
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
            MostrarNuevaTareaPopUp(idTareaPlantilla);
        }
    });
}

function EncabezadoPlantilla() {
    var idPlantilla = $('#MainContent_id_Plantilla').val();
    console.log(idPlantilla);
    $.ajax({
        method: "POST",
        url: "/Views/Actividad/Tareas.aspx/EncabezadoPlantilla",
        data: JSON.stringify({ idPlantilla : idPlantilla }),
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        success: function (x) {
            var m = JSON.parse(x.d);
            $('#MainContent_nombrePlantillaStr').val(m.NombrePlantilla);
            $('#MainContent_idPlantillaStr').val(m.IdPlantilla);
        },
        complete: function () {
            console.log('EncabezadoPlantilla');
        }
    });
}


function IrDefault() {
    window.location.href = "/Default.aspx";
}





