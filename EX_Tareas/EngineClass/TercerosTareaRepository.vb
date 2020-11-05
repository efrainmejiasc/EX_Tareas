Imports System.Data.SqlClient

Public Class TercerosTareaRepository


    Public Function InsertNuevaTarea(ByVal model As List(Of TareasPlantillasModel)) As Boolean
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "INSERT INTO A_Tarea (IdTarea,Tarea,Descripcion,IdTipoTarea,IdEmpresa,IdEstadoTarea,FechaInicio,FechaFin,FechaCreacion,FechaModificacion,FechaTerminado,IdProyecto,IdContrato,TiempoEstimado,IdTipoServicio,IdTareaValor,Orden)
                               VALUES 
                                              (@IdTarea,@Tarea,@Descripcion,@IdTipoTarea,@IdEmpresa,@IdEstadoTarea,@FechaInicio,@FechaFin,@FechaCreacion,@FechaModificacion,@FechaTerminado,@IdProyecto,@IdContrato,@TiempoEstimado,@IdTipoServicio,@IdTareaValor,@Orden)"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim utilidad As Utilidad = New Utilidad()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            For Each m As TareasPlantillasModel In model
                comando.Parameters.Clear()
                comando.Parameters.AddWithValue("@IdTarea", m.IdTarea)
                comando.Parameters.AddWithValue("@Tarea", m.Tarea)
                comando.Parameters.AddWithValue("@Descripcion", m.Descripcion)
                comando.Parameters.AddWithValue("@IdTipoTarea", m.IdTipoTarea)
                comando.Parameters.AddWithValue("@IdEmpresa", m.IdEmpresa)
                comando.Parameters.AddWithValue("@IdEstadoTarea", m.IdEstadoTarea)
                comando.Parameters.AddWithValue("@FechaInicio", Convert.ToDateTime(m.FechaInicio))
                comando.Parameters.AddWithValue("@FechaFin", Convert.ToDateTime(m.FechaFinal))
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now)
                comando.Parameters.AddWithValue("@FechaModificacion", DateTime.Now)
                comando.Parameters.AddWithValue("@FechaTerminado", Convert.ToDateTime("01/01/1900"))
                comando.Parameters.AddWithValue("@IdProyecto", m.IdProyecto)
                comando.Parameters.AddWithValue("@IdContrato", m.IdContrato)
                comando.Parameters.AddWithValue("@TiempoEstimado", m.TiempoEstimado)
                comando.Parameters.AddWithValue("@IdTipoServicio", m.IdTipoServicio)
                comando.Parameters.AddWithValue("@IdTareaValor", m.IdTareaValor)
                comando.Parameters.AddWithValue("@Orden", m.Orden)
                comando.ExecuteNonQuery()
            Next
            conexion.Close()
        End Using
        Return True
    End Function
End Class
