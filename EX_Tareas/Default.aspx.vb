Imports DevExpress.Web

Public Class _Default1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetModeEditGrid()
            CargarGrid()
        End If
    End Sub

    Private Sub CargarGrid()
        Dim plantillaRepository = New PlantillaRepository()
        Dim dt = plantillaRepository.GetPlantillasRegistradas()
        gdvPlantillas.DataSource = dt
        gdvPlantillas.DataBind()
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim strNombrePlantilla = nombrePlantilla.Value
        If (String.IsNullOrEmpty(strNombrePlantilla)) Then
            Return
        End If

        Dim plantillaRepository = New PlantillaRepository()
        Dim resultado = plantillaRepository.InsertarNuevaPlantilla(strNombrePlantilla)
        CargarGrid()
    End Sub
    Private Sub SetModeEditGrid()
        Dim mode As GridViewEditingMode = CType(System.Enum.Parse(GetType(GridViewEditingMode), "PopupEditForm"), GridViewEditingMode)
        gdvPlantillas.SettingsEditing.Mode = mode
        Dim commandColumn = TryCast(gdvPlantillas.Columns(0), GridViewCommandColumn)
        commandColumn.Visible = Not Object.Equals(mode, GridViewEditingMode.Batch)
    End Sub

    Protected Sub gdvPlantillas_CommandButtonInitialize(sender As Object, e As DevExpress.Web.ASPxGridViewCommandButtonEventArgs) Handles gdvPlantillas.CommandButtonInitialize
        If (e.ButtonType = ColumnCommandButtonType.Update Or e.ButtonType = ColumnCommandButtonType.Cancel Or e.ButtonType = ColumnCommandButtonType.Delete) Then
            e.Visible = True
        End If
    End Sub

    Protected Sub gdvPlantillas_RowDeleting(sender As Object, e As Data.ASPxDataDeletingEventArgs) Handles gdvPlantillas.RowDeleting
        Dim idPlantilla = e.Values("IdPlantilla").ToString()
        Dim plantillaRepository = New PlantillaRepository()
        Dim result = plantillaRepository.EliminarPlantilla(idPlantilla)
        Dim tareaRepository = New TareaRepository()
        result = tareaRepository.EliminarPlantillas(idPlantilla)
        e.Cancel = True
        CargarGrid()
    End Sub

    Protected Sub gdvPlantillas_RowUpdating(sender As Object, e As Data.ASPxDataUpdatingEventArgs) Handles gdvPlantillas.RowUpdating
        Dim idPlantilla = e.OldValues("IdPlantilla").ToString()
        Dim nombre = e.NewValues("Nombre").ToString()
        Dim plantillaRepository = New PlantillaRepository()
        Dim result = plantillaRepository.ActualizarPlantilla(idPlantilla, nombre)
        e.Cancel = True
        gdvPlantillas.CancelEdit()
        CargarGrid()
    End Sub

    Protected Sub Asignacion_Click(sender As Object, e As EventArgs) Handles Asignacion.Click
        Response.Redirect("~/Views/Plan/Asignacion.aspx")
    End Sub
End Class