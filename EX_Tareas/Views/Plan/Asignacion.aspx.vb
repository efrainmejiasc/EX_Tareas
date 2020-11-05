Public Class Asignacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarGrid()
        End If
    End Sub

    Private Sub CargarGrid()
        Dim tareaRepository = New TareaRepository()
        Dim dt = tareaRepository.GetTareasPlantillas()
        gdvAsignacion.DataSource = dt
        gdvAsignacion.DataBind()
    End Sub
End Class