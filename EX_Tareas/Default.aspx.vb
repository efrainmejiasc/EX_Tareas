Imports DevExpress.Web

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If (IsPostBack = False) Then
            SetModeEditGrid()
            Dim util = New Utilidad()
            tipoTarea = util.AddItemsListTareas(tipoTarea)
            estadoTarea = util.AddItemsListEstados(estadoTarea)
            tipoServicio = util.AddItemsListServicios(tipoServicio)
            tareaValor = util.AddItemsListValores(tareaValor)
            CargarGrid()
        End If

    End Sub

    Private Sub CargarGrid()
        Dim plantillaTareaRepository = New PlantillaTareaRepository()
        Dim dt = plantillaTareaRepository.GetTareasRegistradas()
        gdvTareas.DataSource = dt
        gdvTareas.DataBind()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim m = New NuevaTarea()
        m.Tarea = tarea.Value
        m.TipoTarea = tipoTarea.SelectedItem.ToString()
        m.EstadoTarea = estadoTarea.SelectedItem.ToString()
        m.TipoServicio = tipoServicio.SelectedItem.ToString()
        m.TareaValor = tareaValor.SelectedItem.ToString()
        m.FechaInicio = fechaInicio.Value
        m.FechaFinal = fechaFinal.Value
        m.Descripcion = descripcion.Value
        m.TiempoEstimado = Convert.ToDecimal(tiempoEstimado.Value.Replace(",", "."))

        Dim util = New Utilidad()
        m.IdTipoTarea = util.IdValue(EngineData.TareaTipo, m.TipoTarea)
        m.IdEstadoTarea = util.IdValue(EngineData.TareaEstado, m.EstadoTarea)
        m.IdTipoServicio = util.IdValue(EngineData.TareaTipoServicio, m.TipoServicio)
        m.IdTareaValor = util.IdValue(EngineData.TareaValor, m.TareaValor)

        Dim plantillaTareaRepository = New PlantillaTareaRepository()
        Dim result As Boolean = plantillaTareaRepository.InsertNuevaTarea(m)
        CargarGrid()
        ClearFormNuevaTarea()
    End Sub

    Public Sub ClearFormNuevaTarea()
        tarea.Value = String.Empty
        descripcion.Value = String.Empty
        estadoTarea.SelectedIndex = -1
        tiempoEstimado.Value = 0
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

    Protected Sub gdvTareas_RowUpdating(sender As Object, e As Data.ASPxDataUpdatingEventArgs) Handles gdvTareas.RowUpdating
        'Dim i As OrderedDictionary = e.OldValues
        'Dim j As OrderedDictionary = e.NewValues
        Dim plantillaTareaRepository = New PlantillaTareaRepository()
        'Dim m = New NuevaTarea With {
        '.IdTarea = e.OldValues("IdTarea").ToString(),
        'rea = e.NewValues("Tarea").ToString(),
        '.FechaInicio = Convert.ToDateTime(e.NewValues("FechaInicio")),
        '.FechaFinal = Convert.ToDateTime(e.NewValues("FechaFinal")),
        '.Descripcion = e.NewValues("Descripcion").ToString(),
        '.Resultado = resultado.SelectedItem.ToString(),
        '.TiempoEstimado = Convert.ToDecimal(e.NewValues("TiempoEstimado"))
        ' }

        e.Cancel = True
        gdvTareas.CancelEdit()
    End Sub

    Protected Sub gdvTareas_RowDeleting(sender As Object, e As Data.ASPxDataDeletingEventArgs) Handles gdvTareas.RowDeleting
        Dim idTarea As String = e.Values("IdTarea").ToString()
        Dim plantillaTareaRepository = New PlantillaTareaRepository()
        Dim result As Boolean = plantillaTareaRepository.EliminarTarea(idTarea)
        e.Cancel = True
        CargarGrid()
    End Sub
End Class