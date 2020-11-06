Imports System.Data.SqlClient

Public Class TercerosTareaRepository


    Public Function InsertNuevaTarea(ByVal Optional idEmpresa As String = "", ByVal Optional idProyecto As String = "", ByVal Optional idContrato As String = "") As Boolean
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
            For Each r As DataRow In EngineData.GdvAsignacion.Rows
                comando.Parameters.Clear()
                comando.Parameters.AddWithValue("@IdTarea", r("IdTarea").ToString())
                comando.Parameters.AddWithValue("@Tarea", r("Tarea").ToString())
                comando.Parameters.AddWithValue("@Descripcion", r("Descripcion").ToString())
                comando.Parameters.AddWithValue("@IdTipoTarea", Convert.ToInt32(r("IdTipoTarea")))
                comando.Parameters.AddWithValue("@IdEmpresa", idEmpresa)
                comando.Parameters.AddWithValue("@IdEstadoTarea", Convert.ToInt32(r("IdEstadoTarea")))
                comando.Parameters.AddWithValue("@FechaInicio", Convert.ToDateTime(r("FechaInicio")))
                comando.Parameters.AddWithValue("@FechaFin", Convert.ToDateTime(r("FechaFin")))
                comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now)
                comando.Parameters.AddWithValue("@FechaModificacion", DateTime.Now)
                comando.Parameters.AddWithValue("@FechaTerminado", Convert.ToDateTime("01/01/1900"))
                comando.Parameters.AddWithValue("@IdProyecto", idProyecto)
                comando.Parameters.AddWithValue("@IdContrato", idContrato)
                comando.Parameters.AddWithValue("@TiempoEstimado", Convert.ToDecimal(r("TiempoEstimado")))
                comando.Parameters.AddWithValue("@IdTipoServicio", r("IdTipoServicio").ToString())
                comando.Parameters.AddWithValue("@IdTareaValor", r("IdTareaValor").ToString())
                comando.Parameters.AddWithValue("@Orden", r("Orden").ToString())
                comando.ExecuteNonQuery()
            Next
            conexion.Close()
        End Using
        Return True
    End Function
End Class
