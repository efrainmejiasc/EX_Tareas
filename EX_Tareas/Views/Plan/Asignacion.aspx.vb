Imports DevExpress.Web
Imports Newtonsoft.Json

Public Class Asignacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim util = New Utilidad()
            tipoTarea = util.AddItemsListTareas(tipoTarea)
            estadoTarea = util.AddItemsListEstados(estadoTarea)
            tipoServicio = util.AddItemsListServicios(tipoServicio)
            tareaValor = util.AddItemsListValores(tareaValor)
            EngineData.PostBack = True
            CargarGrid()
        Else
            EngineData.PostBack = False
        End If
    End Sub

    Private Sub CargarGrid()
        If EngineData.PostBack Then
            Dim tareaRepository = New TareaRepository()
            EngineData.GdvAsignacion = tareaRepository.GetTareasPlantillas()
            EngineData.GdvAsignacion.AcceptChanges()
            gdvAsignacion.DataSource = EngineData.GdvAsignacion
            gdvAsignacion.DataBind()
        End If
    End Sub

    Protected Sub gdvAsignacion_CommandButtonInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewCommandButtonEventArgs) Handles gdvAsignacion.CommandButtonInitialize
        If (e.ButtonType = ColumnCommandButtonType.Update Or e.ButtonType = ColumnCommandButtonType.Cancel Or e.ButtonType = ColumnCommandButtonType.Delete) Then
            e.Visible = True
        End If
    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function DatosTareaPlantilla(ByVal idTarea As String) As String
        Dim tareaRepository = New TareaRepository()
        Dim tareaPlantilla = tareaRepository.GetTareaPlantilla(idTarea)
        Dim result = JsonConvert.SerializeObject(tareaPlantilla)
        Return result
    End Function

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim m = New TareasPlantillasModel()
        m.IdPlantilla = idPlantilla.Value
        m.NombrePlantilla = nombrePlantilla.Value
        m.IdTarea = id_Tarea.Value
        m.Tarea = tarea.Value
        m.TipoTarea = tipoTarea.SelectedItem.ToString()
        m.EstadoTarea = estadoTarea.SelectedItem.ToString()
        m.TipoServicio = tipoServicio.SelectedItem.ToString()
        m.TareaValor = tareaValor.SelectedItem.ToString()
        m.FechaInicio = fechaInicio.Value
        m.FechaFinal = fechaFinal.Value
        m.Descripcion = descripcion.Value
        m.TiempoEstimado = Convert.ToDecimal(tiempoEstimado.Value.ToString().Replace(",", "."))
        m.Orden = orden.Value

        Dim util = New Utilidad()
        m.IdTipoTarea = util.IdValue(EngineData.TareaTipo, m.TipoTarea)
        m.IdEstadoTarea = util.IdValue(EngineData.TareaEstado, m.EstadoTarea)
        m.IdTipoServicio = util.IdValue(EngineData.TareaTipoServicio, m.TipoServicio)
        m.IdTareaValor = util.IdValue(EngineData.TareaValor, m.TareaValor)

        util.ActualizarFilaDtAsignacion(m)
        gdvAsignacion.DataSource = Nothing
        gdvAsignacion.DataSource = EngineData.GdvAsignacion
        gdvAsignacion.DataBind()

    End Sub

    Protected Sub gdvAsignacion_RowDeleting(sender As Object, e As Data.ASPxDataDeletingEventArgs) Handles gdvAsignacion.RowDeleting
        Dim idTarea As String = e.Values("IdTarea").ToString()
        Dim util = New Utilidad()
        util.RemoverFilaDtAsignacion(idTarea)
        e.Cancel = True
        gdvAsignacion.DataSource = Nothing
        gdvAsignacion.DataSource = EngineData.GdvAsignacion
        gdvAsignacion.DataBind()
    End Sub

    Protected Sub GuardarDB_Click(sender As Object, e As EventArgs) Handles GuardarDB.Click
        Dim terceroTareaRepository = New TercerosTareaRepository()
        Dim resultado = terceroTareaRepository.InsertNuevaTarea("CL0001", "PRY0001", "CON0001")

    End Sub
End Class