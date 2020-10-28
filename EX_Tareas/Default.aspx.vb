Imports DevExpress.Web

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If (IsPostBack = False) Then
            Dim util = New Utilidad()
            prioridad = util.PrioridadItems(prioridad)
            tipoTarea = util.AddItemsList(tipoTarea, "tareas")
            usuarios = util.AddItemsList(usuarios, "usuarios")
            resultado = util.AddItemsList(resultado, "resultados")
            Dim plantillaTareaRepository = New PlantillaTareaRepository()
            Dim dt = plantillaTareaRepository.GetTareasRegistradas()
            gdvTareas.DataSource = dt
            gdvTareas.DataBind()
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim m = New NuevaTarea()
        m.Tarea = tarea.Value
        m.Prioridad = prioridad.SelectedItem.ToString()
        m.FechaInicio = fechaInicio.Value
        m.FechaFinal = fechaFinal.Value
        m.Descripcion = descripcion.Value
        m.Resultado = resultado.SelectedItem.ToString()
        m.TiempoEstimado = tiempoEstimado.Value
        m.Proceso = proceso.Value
        m.Usuario = String.Empty
        For Each item As Object In usuarios.Items
            If item.Selected = True Then
                If m.Usuario = String.Empty Then
                    m.Usuario = item.ToString()
                Else
                    m.Usuario = m.Usuario & ";" & item.ToString()
                End If
            End If
        Next

        Dim plantillaTareaRepository = New PlantillaTareaRepository()
        Dim result As Boolean = plantillaTareaRepository.InsertNuevaTarea(m)
        Dim dt = plantillaTareaRepository.GetTareasRegistradas()
        gdvTareas.DataSource = dt
        gdvTareas.DataBind()
        ClearFormNuevaTarea()
    End Sub

    Public Sub ClearFormNuevaTarea()
        usuarios.ClearSelection()
        tarea.Value = String.Empty
        prioridad.SelectedIndex = -1
        descripcion.Value = String.Empty
        resultado.SelectedIndex = -1
        tiempoEstimado.Value = 0
        proceso.Value = String.Empty
    End Sub
End Class