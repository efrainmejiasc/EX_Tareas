Imports System.Data.SqlClient

Public Class TareaRepository

    Public Function GetTareasRegistradas(ByVal idPlantilla As String) As DataTable
        Dim dt As DataTable = New DataTable
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = QueryPlantillaTarea()
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdPlantilla", idPlantilla)
            Dim adaptador As SqlDataAdapter = New SqlDataAdapter(comando)
            adaptador.Fill(dt)
            conexion.Close()
        End Using

        Return dt
    End Function

    Private Function QueryPlantillaTarea() As String
        Return "SELECT PT.IdTarea,PT.IdPlantilla, PT.Tarea, PT.IdTipoTarea, TT.Tipo AS TipoTarea, 
                       PT.IdEstadoTarea,TE.Estado AS EstadoTarea, PT.IdTipoServicio, 
		               TTS.TipoServicio, PT.IdTareaValor, TV.Valor AS TareaValor,
		               PT.FechaInicio,PT.FechaFin,PT.Descripcion, CAST(PT.TiempoEstimado AS DECIMAL(10,2)) AS TiempoEstimado,PT.Orden
               FROM A_PlantillaTarea AS PT 
               INNER JOIN A_TareaTipo AS TT ON PT.IdTipoTarea = TT.IdTipoTarea
               INNER JOIN A_TareaEstado AS TE ON PT.IdEstadoTarea =TE.IdEstadoTarea
               INNER JOIN A_TareaTipoServicio AS TTS ON PT.IdTipoServicio = TTS.IdTipoServicio
               INNER JOIN A_TareaValor AS TV ON PT.IdTareaValor = TV.Id WHERE PT.IdPlantilla = @IdPlantilla ORDER BY PT.Orden ASC"
    End Function



    Public Function InsertNuevaTarea(ByVal m As NuevaTareaModel) As Boolean
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "INSERT INTO A_PlantillaTarea (IdTarea,IdPlantilla,Tarea,IdTipoTarea,IdEstadoTarea,IdTipoServicio,IdTareaValor,FechaInicio,FechaFin,Descripcion,FechaCrea,FechaModifica,FechaTerminado,TiempoEstimado,Orden)
                               VALUES 
                                              (@IdTarea,@IdPlantilla,@Tarea,@IdTipoTarea,@IdEstadoTarea,@IdTipoServicio,@IdTareaValor,@FechaInicio,@FechaFin,@Descripcion,@FechaCrea,@FechaModifica,@FechaTerminado,@TiempoEstimado,@Orden)"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim utilidad As Utilidad = New Utilidad()
        m.IdTarea = utilidad.CreateIdTarea()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdTarea", m.IdTarea)
            comando.Parameters.AddWithValue("@IdPlantilla", m.IdPlantilla)
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
            comando.Parameters.AddWithValue("@FechaTerminado", Convert.ToDateTime("01/01/1900"))
            comando.Parameters.AddWithValue("@TiempoEstimado", m.TiempoEstimado)
            comando.Parameters.AddWithValue("@Orden", OrdenTarea())
            comando.ExecuteNonQuery()
            conexion.Close()
        End Using
        Return True
    End Function

    Public Function ActualizarTarea(ByVal m As NuevaTareaModel) As Boolean
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "UPDATE  A_PlantillaTarea SET Tarea = @Tarea, IdTipoTarea = @IdTipoTarea, IdEstadoTarea = @IdEstadoTarea, IdTipoServicio = @IdTipoServicio, IdTareaValor = @IdTareaValor, FechaInicio = @FechaInicio,
                                       FechaFin = @FechaFin, Descripcion = @Descripcion, TiempoEstimado = @TiempoEstimado, Orden = @Orden WHERE IdTarea = @IdTarea"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim utilidad As Utilidad = New Utilidad()
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
            comando.Parameters.AddWithValue("@FechaModifica", DateTime.Now)
            comando.Parameters.AddWithValue("@TiempoEstimado", m.TiempoEstimado)
            comando.Parameters.AddWithValue("@Orden", m.Orden)
            comando.ExecuteNonQuery()
            conexion.Close()
        End Using
        Return True
    End Function


    Public Function EliminarTarea(ByVal idTarea As String) As Boolean
        Dim result = False
        Dim cnx = EngineData.cadenaConexion
        Dim query = "DELETE  A_PlantillaTarea WHERE IdTarea = @IdTarea"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdTarea", idTarea)
            comando.ExecuteNonQuery()
            conexion.Close()
            result = True
        End Using
        Return result
    End Function

    Public Function EliminarPlantillas(ByVal idPlantilla As String) As Boolean
        Dim result = False
        Dim cnx = EngineData.cadenaConexion
        Dim query = "DELETE  A_PlantillaTarea WHERE IdPlantilla = @IdPlantilla"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdPlantilla", idPlantilla)
            comando.ExecuteNonQuery()
            conexion.Close()
            result = True
        End Using
        Return result
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
            If Not obj Is DBNull.Value And Not obj Is Nothing Then
                numero = Convert.ToInt32(obj)
            End If
        End Using
        Return numero
    End Function

    Public Function GetTarea(ByVal idTarea As String) As NuevaTareaModel
        Dim cnx As String = EngineData.cadenaConexion
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim m As NuevaTareaModel = New NuevaTareaModel()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(QueryPlantillaTareaEspecifica(), conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdTarea", idTarea)
            Dim lector As SqlDataReader = comando.ExecuteReader()
            If lector.Read() Then
                m.IdTarea = lector.GetString(0)
                m.IdPlantilla = lector.GetString(1)
                m.Tarea = lector.GetString(2)
                m.IdTipoTarea = lector.GetInt64(3)
                m.TipoTarea = lector.GetString(4)
                m.IdEstadoTarea = lector.GetInt64(5)
                m.EstadoTarea = lector.GetString(6)
                m.IdTipoServicio = lector.GetInt64(7)
                m.TipoServicio = lector.GetString(8)
                m.IdTareaValor = lector.GetInt32(9)
                m.TareaValor = lector.GetString(10)
                m.FechaInicio = lector.GetDateTime(11)
                m.FechaFinal = lector.GetDateTime(12)
                m.Descripcion = lector.GetString(13)
                m.TiempoEstimado = lector.GetDecimal(14)
                m.Orden = lector.GetInt32(15)
            End If
            conexion.Close()
        End Using

        Return m
    End Function

    Private Function QueryPlantillaTareaEspecifica() As String
        Return "SELECT PT.IdTarea, PT.IdPlantilla, PT.Tarea, PT.IdTipoTarea, TT.Tipo AS TipoTarea, 
                       PT.IdEstadoTarea,TE.Estado AS EstadoTarea, PT.IdTipoServicio, 
		               TTS.TipoServicio, PT.IdTareaValor, TV.Valor AS TareaValor,
		               PT.FechaInicio,PT.FechaFin,PT.Descripcion, CAST(PT.TiempoEstimado AS DECIMAL(10,2)) AS TiempoEstimado,PT.Orden
               FROM A_PlantillaTarea AS PT 
               INNER JOIN A_TareaTipo AS TT ON PT.IdTipoTarea = TT.IdTipoTarea
               INNER JOIN A_TareaEstado AS TE ON PT.IdEstadoTarea =TE.IdEstadoTarea
               INNER JOIN A_TareaTipoServicio AS TTS ON PT.IdTipoServicio = TTS.IdTipoServicio
               INNER JOIN A_TareaValor AS TV ON PT.IdTareaValor = TV.Id 
               WHERE PT.IdTarea = @IdTarea ORDER BY PT.Orden ASC"
    End Function


    Public Function GetTareasPlantillas() As DataTable
        Dim dt As DataTable = New DataTable
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = QueryTareasPlantillas()
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

    Public Function QueryTareasPlantillas() As String
        Return "SELECT P.IdPlantilla, P.Nombre, PT.IdTarea, PT.Tarea, PT.IdTipoTarea, TT.Tipo AS TipoTarea, 
                       PT.IdEstadoTarea,TE.Estado AS EstadoTarea, PT.IdTipoServicio, 
		               TTS.TipoServicio, PT.IdTareaValor, TV.Valor AS TareaValor,
		               PT.FechaInicio,PT.FechaFin,PT.Descripcion, CAST(PT.TiempoEstimado AS DECIMAL(10,2)) AS TiempoEstimado,PT.Orden 
	           FROM CRM_Pantallas..A_PLantilla AS P 
               INNER JOIN CRM_Pantallas..A_PlantillaTarea AS PT ON P.IdPlantilla = PT.IdPlantilla
               INNER JOIN CRM_Pantallas..A_TareaTipo AS TT ON PT.IdTipoTarea = TT.IdTipoTarea
               INNER JOIN CRM_Pantallas..A_TareaEstado AS TE ON PT.IdEstadoTarea =TE.IdEstadoTarea
               INNER JOIN CRM_Pantallas..A_TareaTipoServicio AS TTS ON PT.IdTipoServicio = TTS.IdTipoServicio
               INNER JOIN CRM_Pantallas..A_TareaValor AS TV ON PT.IdTareaValor = TV.Id ORDER BY PT.Orden ASC "
    End Function

    Public Function GetTareaPlantilla(ByVal idTarea As String) As TareasPlantillasModel
        Dim cnx As String = EngineData.cadenaConexion
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim m = New TareasPlantillasModel()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(QueryTareaPlantilla(), conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdTarea", idTarea)
            Dim lector As SqlDataReader = comando.ExecuteReader()
            If lector.Read() Then
                m.IdPlantilla = lector.GetString(0)
                m.NombrePlantilla = lector.GetString(1)
                m.IdTarea = lector.GetString(2)
                m.Tarea = lector.GetString(3)
                m.IdTipoTarea = lector.GetInt64(4)
                m.TipoTarea = lector.GetString(5)
                m.IdEstadoTarea = lector.GetInt64(6)
                m.EstadoTarea = lector.GetString(7)
                m.IdTipoServicio = lector.GetInt64(8)
                m.TipoServicio = lector.GetString(9)
                m.IdTareaValor = lector.GetInt32(10)
                m.TareaValor = lector.GetString(11)
                m.FechaInicio = lector.GetDateTime(12)
                m.FechaFinal = lector.GetDateTime(13)
                m.Descripcion = lector.GetString(14)
                m.TiempoEstimado = lector.GetDecimal(15)
                m.Orden = lector.GetInt32(16)
            End If
            conexion.Close()
        End Using

        Return m
    End Function


    Private Function QueryTareaPlantilla() As String
        Return "SELECT P.IdPlantilla, P.Nombre, PT.IdTarea, PT.Tarea, PT.IdTipoTarea, TT.Tipo AS TipoTarea, 
                       PT.IdEstadoTarea,TE.Estado AS EstadoTarea, PT.IdTipoServicio, 
		               TTS.TipoServicio, PT.IdTareaValor, TV.Valor AS TareaValor,
		               PT.FechaInicio,PT.FechaFin,PT.Descripcion, CAST(PT.TiempoEstimado AS DECIMAL(10,2)) AS TiempoEstimado,PT.Orden 
	           FROM CRM_Pantallas..A_PLantilla AS P 
               INNER JOIN CRM_Pantallas..A_PlantillaTarea AS PT ON P.IdPlantilla = PT.IdPlantilla
               INNER JOIN CRM_Pantallas..A_TareaTipo AS TT ON PT.IdTipoTarea = TT.IdTipoTarea
               INNER JOIN CRM_Pantallas..A_TareaEstado AS TE ON PT.IdEstadoTarea =TE.IdEstadoTarea
               INNER JOIN CRM_Pantallas..A_TareaTipoServicio AS TTS ON PT.IdTipoServicio = TTS.IdTipoServicio
               INNER JOIN CRM_Pantallas..A_TareaValor AS TV ON PT.IdTareaValor = TV.Id   WHERE  PT.IdTarea = @IdTarea"
    End Function
End Class
