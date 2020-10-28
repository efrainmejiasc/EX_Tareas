Imports System.Data.SqlClient

Public Class PlantillaTareaRepository

    Public Function InsertNuevaTarea(ByVal m As NuevaTarea) As Boolean
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "INSERT INTO A_PlantillaTarea (IdTarea,Tarea,IdTipoTarea,IdEmpresa,IdEstadoTarea,Prioridad,FechaInicio,FechaFin,Descripcion,Resultado,UserIdCrea,FechaCrea,FechaModifica,Eliminado,FechaTerminado,Proceso,TiempoEstimado,Orden)
                               VALUES 
                              (@IdTarea,@Tarea,@IdTipoTarea,@IdEmpresa,@IdEstadoTarea,@Prioridad,@FechaInicio,@FechaFin,@Descripcion,@Resultado,@UserIdCrea,@FechaCrea,@FechaModifica,@Eliminado,@FechaTerminado,@Proceso,@TiempoEstimado,@Orden)"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim utilidad As Utilidad = New Utilidad()
        Dim guid As Guid = utilidad.IdentificadorReg()
        m.IdTarea = utilidad.CreateIdTarea()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdTarea", m.IdTarea)
            comando.Parameters.AddWithValue("@Tarea", m.Tarea)
            comando.Parameters.AddWithValue("@IdTipoTarea", 2)
            comando.Parameters.AddWithValue("@IdEmpresa", "CL0001")
            comando.Parameters.AddWithValue("@IdEstadoTarea", 5)
            comando.Parameters.AddWithValue("@Prioridad", m.Prioridad)
            comando.Parameters.AddWithValue("@FechaInicio", Convert.ToDateTime(m.FechaInicio))
            comando.Parameters.AddWithValue("@FechaFin", Convert.ToDateTime(m.FechaFinal))
            comando.Parameters.AddWithValue("@Descripcion", m.Descripcion)
            comando.Parameters.AddWithValue("@Resultado", m.Resultado)
            comando.Parameters.AddWithValue("@UserIdCrea", guid)
            comando.Parameters.AddWithValue("@FechaCrea", DateTime.Now)
            comando.Parameters.AddWithValue("@FechaModifica", DateTime.Now)
            comando.Parameters.AddWithValue("@Eliminado", False)
            comando.Parameters.AddWithValue("@FechaTerminado", Convert.ToDateTime("01/01/1900"))
            comando.Parameters.AddWithValue("@Proceso", m.Proceso)
            comando.Parameters.AddWithValue("@TiempoEstimado", m.TiempoEstimado)
            comando.Parameters.AddWithValue("@Orden", 1)
            comando.ExecuteNonQuery()
            conexion.Close()
        End Using
        Return True
    End Function

    Public Function GetTareasRegistradas() As DataTable
        Dim dt As DataTable = New DataTable
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "SELECT * FROM  A_PlantillaTarea"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter(comando)
            adaptador.Fill(dt)
            conexion.Close()
        End Using

        Return dt
    End Function

End Class
