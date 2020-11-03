Imports DevExpress.Web
Imports Newtonsoft.Json

Public Class Tareas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Dim idPlantilla = Request.QueryString("idPlantilla")
            id_Plantilla.Value = idPlantilla
            SetModeEditGrid()
            Dim util = New Utilidad()
            tipoTarea = util.AddItemsListTareas(tipoTarea)
            estadoTarea = util.AddItemsListEstados(estadoTarea)
            tipoServicio = util.AddItemsListServicios(tipoServicio)
            tareaValor = util.AddItemsListValores(tareaValor)
            CargarGrid(idPlantilla)
        Else
            Dim postback = True
        End If
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim m = New NuevaTarea()
        m.IdPlantilla = id_Plantilla.Value
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

        If (m.TiempoEstimado > 0) Then
            Dim plantillaTareaRepository = New TareaRepository()
            Dim result As Boolean = If(m.IdTarea = String.Empty, plantillaTareaRepository.InsertNuevaTarea(m), plantillaTareaRepository.ActualizarTarea(m))
        End If
        CargarGrid(m.IdPlantilla)
        ClearFormNuevaTarea()
    End Sub

    Private Sub CargarGrid(ByVal idPlantilla As String)
        Dim plantillaTareaRepository = New TareaRepository()
        Dim dt = plantillaTareaRepository.GetTareasRegistradas(idPlantilla)
        gdvTareas.DataSource = dt
        gdvTareas.DataBind()
    End Sub

    Private Sub SetModeEditGrid()
        Dim mode As GridViewEditingMode = CType(System.Enum.Parse(GetType(GridViewEditingMode), "PopupEditForm"), GridViewEditingMode)
        gdvTareas.SettingsEditing.Mode = mode
        Dim commandColumn = TryCast(gdvTareas.Columns(0), GridViewCommandColumn)
        commandColumn.Visible = Not Object.Equals(mode, GridViewEditingMode.Batch)
    End Sub

    Protected Sub gdvTareas_CommandButtonInitialize(sender As Object, e As ASPxGridViewCommandButtonEventArgs) Handles gdvTareas.CommandButtonInitialize
        If (e.ButtonType = ColumnCommandButtonType.Update Or e.ButtonType = ColumnCommandButtonType.Cancel Or e.ButtonType = ColumnCommandButtonType.Delete) Then
            e.Visible = True
        End If
    End Sub

    Protected Sub gdvTareas_RowDeleting(sender As Object, e As Data.ASPxDataDeletingEventArgs) Handles gdvTareas.RowDeleting
        Dim idTarea As String = e.Values("IdTarea").ToString()
        Dim plantillaTareaRepository = New TareaRepository()
        Dim result As Boolean = plantillaTareaRepository.EliminarTarea(idTarea)
        e.Cancel = True
        CargarGrid(id_Plantilla.Value)
    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function DatosTareaPlantilla(ByVal idTareaPlantilla As String) As String
        Dim plantillaTareaRepository = New TareaRepository()
        Dim tarea = plantillaTareaRepository.GetTarea(idTareaPlantilla)
        Dim result = JsonConvert.SerializeObject(tarea)
        Return result
    End Function

    Public Sub ClearFormNuevaTarea()
        tarea.Value = String.Empty
        descripcion.Value = String.Empty
        estadoTarea.SelectedIndex = -1
        tiempoEstimado.Value = 0
        id_Tarea.Value = String.Empty
    End Sub
End Class