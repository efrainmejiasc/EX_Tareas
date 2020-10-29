Imports System.Data.SqlClient

Public Class PlantillaTareaRepository

    Public Function GetTareasRegistradas() As DataTable
        Dim dt As DataTable = New DataTable
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = QueryPlantillaTarea()
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

    Public Function QueryPlantillaTarea() As String
        Return "SELECT PT.IdTarea, PT.Tarea, PT.IdTipoTarea, TT.Tipo AS TipoTarea, 
                       PT.IdEstadoTarea,TE.Estado AS EstadoTarea, PT.IdTipoServicio, 
		               TTS.TipoServicio, PT.IdTareaValor, TV.Valor AS TareaValor,
		               PT.FechaInicio,PT.FechaFin,PT.Descripcion,PT.TiempoEstimado,PT.Orden
               FROM A_PlantillaTarea AS PT 
               INNER JOIN A_TareaTipo AS TT ON PT.IdTipoTarea = TT.IdTipoTarea
               INNER JOIN A_TareaEstado AS TE ON PT.IdEstadoTarea =TE.IdEstadoTarea
               INNER JOIN A_TareaTipoServicio AS TTS ON PT.IdTipoServicio = TTS.IdTipoServicio
               INNER JOIN A_TareaValor AS TV ON PT.IdTareaValor = TV.Id ORDER BY PT.Orden ASC"
    End Function



    Public Function InsertNuevaTarea(ByVal m As NuevaTarea) As Boolean
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "INSERT INTO A_PlantillaTarea (IdTarea,Tarea,IdTipoTarea,IdEstadoTarea,IdTipoServicio,IdTareaValor,FechaInicio,FechaFin,Descripcion,FechaCrea,FechaModifica,Eliminado,FechaTerminado,TiempoEstimado,Orden)
                               VALUES 
                                              (@IdTarea,@Tarea,@IdTipoTarea,@IdEstadoTarea,@IdTipoServicio,@IdTareaValor,@FechaInicio,@FechaFin,@Descripcion,@FechaCrea,@FechaModifica,@Eliminado,@FechaTerminado,@TiempoEstimado,@Orden)"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim utilidad As Utilidad = New Utilidad()
        m.IdTarea = utilidad.CreateIdTarea()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdTarea", m.IdTarea)
            comando.Parameters.AddWithValue("@Tarea", m.Tarea)
            comando.Parameters.AddWithValue("@IdTipoTarea", m.IdTipoTarea)
            comando.Parameters.AddWithValue("@IdEstadoTarea", m.IdEstadoTarea)
            comando.Parameters.AddWithValue("@IdTipoServicio", m.IdTipoServicio)
            comando.Parameters.AddWithValue("@IdTareaValor", m.IdTareaValor)
            comando.Parameters.AddWithValue("@FechaInicio", Convert.ToDateTime(m.FechaInicio))
            comando.Parameters.AddWithValue("@FechaFin", Convert.ToDateTime(m.FechaFinal))
            comando.Parameters.AddWithValue("@Descripcion", m.Descripcion)
            comando.Parameters.AddWithValue("@FechaCrea", DateTime.Now)
            comando.Parameters.AddWithValue("@FechaModifica", DateTime.Now)
            comando.Parameters.AddWithValue("@Eliminado", False)
            comando.Parameters.AddWithValue("@FechaTerminado", Convert.ToDateTime("01/01/1900"))
            comando.Parameters.AddWithValue("@TiempoEstimado", m.TiempoEstimado)
            comando.Parameters.AddWithValue("@Orden", OrdenTarea())
            comando.ExecuteNonQuery()
            conexion.Close()
        End Using
        Return True
    End Function

    Public Function ActualizarTarea(ByVal m As NuevaTarea) As Boolean
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "UPDATE  A_PlantillaTarea SET Tarea = @Tarea, IdTipoTarea = @IdTipoTarea, IdEstadoTarea = @IdEstadoTarea, TiempoEstimado = @TiempoEstimado, Orden = @Orden, FechaModifica = @FechaModifica WHERE IdTarea = @IdTarea"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim utilidad As Utilidad = New Utilidad()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdTarea", m.IdTarea)
            comando.Parameters.AddWithValue("@Tarea", m.Tarea)
            comando.Parameters.AddWithValue("@IdTipoTarea", 2)
            comando.Parameters.AddWithValue("@IdEstadoTarea", 4)
            comando.Parameters.AddWithValue("@TiempoEstimado", m.TiempoEstimado)
            comando.Parameters.AddWithValue("@Orden", 2)
            comando.Parameters.AddWithValue("@FechaModifica", DateTime.Now)
            comando.ExecuteNonQuery()
            conexion.Close()
        End Using
        Return True
    End Function


    Public Function EliminarTarea(ByVal idTarea As String) As Boolean
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "DELETE  A_PlantillaTarea WHERE IdTarea = @IdTarea"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdTarea", idTarea)
            comando.ExecuteNonQuery()
            conexion.Close()
        End Using
        Return True
    End Function


    Public Function OrdenTarea() As Int32
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "SELECT (MAX(Orden) + 10) AS ORDEN FROM A_PlantillaTarea"
        Dim numero As Int32 = 10
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            Dim obj As Object = comando.ExecuteScalar()
            conexion.Close()
            If Not obj Is DBNull.Value Then
                numero = Convert.ToInt32(obj)
            End If
        End Using
        Return numero
    End Function

End Class
