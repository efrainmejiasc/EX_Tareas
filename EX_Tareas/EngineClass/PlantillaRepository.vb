Imports System.Data.SqlClient

Public Class PlantillaRepository

    Public Function InsertarNuevaPlantilla(ByVal nombrePlantilla As String) As Boolean
        Dim resultado = False
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "INSERT INTO A_Plantilla (IdPlantilla,Nombre,FechaCreacion,FechaModificacion)
                               VALUES (@IdPlantilla,@Nombre,@FechaCreacion,@FechaModificacion)"

        Dim conexion = New SqlConnection(cnx)
        Dim utilidad = New Utilidad()
        Dim idPlantilla = utilidad.CreateIdPlantilla()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdPlantilla", idPlantilla)
            comando.Parameters.AddWithValue("@Nombre", nombrePlantilla)
            comando.Parameters.AddWithValue("@FechaCreacion", DateTime.Now)
            comando.Parameters.AddWithValue("@FechaModificacion", DateTime.Now)
            comando.ExecuteNonQuery()
            conexion.Close()
            resultado = True
        End Using
        Return resultado
    End Function

    Public Function GetPlantillasRegistradas() As DataTable
        Dim dt As DataTable = New DataTable
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "SELECT * FROM A_Plantilla ORDER BY FechaCreacion ASC"
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

    Public Function EliminarPlantilla(ByVal idPlantilla As String) As Boolean
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "DELETE  A_Plantilla WHERE IdPlantilla = @IdPlantilla"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdPlantilla", idPlantilla)
            comando.ExecuteNonQuery()
            conexion.Close()
        End Using
        Return True
    End Function


    Public Function ActualizarPlantilla(ByVal idPlantilla As String, ByVal nombre As String) As Boolean
        Dim resultado = False
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "UPDATE  A_Plantilla SET Nombre = @Nombre, FechaModificacion = @FechaModificacion WHERE IdPlantilla = @IdPlantilla"
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Dim utilidad As Utilidad = New Utilidad()
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@IdPlantilla", idPlantilla)
            comando.Parameters.AddWithValue("@Nombre", nombre)
            comando.Parameters.AddWithValue("@FechaModificacion", DateTime.Now)
            comando.ExecuteNonQuery()
            conexion.Close()
            resultado = True
        End Using
        Return resultado
    End Function
End Class
