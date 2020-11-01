Imports System.Data.SqlClient
Imports DevExpress.Web

Public Class Utilidad


    Public Function AddItemsListTareas(ByVal list As DropDownList) As DropDownList
        list.Items.Clear()
        EngineData.TareaTipo.Clear()
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "SELECT  Tipo, IdTipoTarea  FROM A_TareaTipo WHERE Activo = @Activo"
        Dim conexion As SqlConnection = New SqlConnection(cnx)

        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@Activo", True)
            Dim lector As SqlDataReader = comando.ExecuteReader()
            While lector.Read()
                list.Items.Add(lector.GetString(0))
                EngineData.TareaTipo.Add(lector.GetString(0), lector.GetInt64(1))
            End While
            conexion.Close()
        End Using

        Return list
    End Function

    Public Function AddItemsListServicios(ByVal list As DropDownList) As DropDownList
        list.Items.Clear()
        EngineData.TareaTipoServicio.Clear()
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "SELECT TipoServicio, IdTipoServicio FROM A_TareaTipoServicio WHERE Activo = @Activo"
        Dim conexion As SqlConnection = New SqlConnection(cnx)

        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@Activo", True)
            Dim lector As SqlDataReader = comando.ExecuteReader()
            While lector.Read()
                list.Items.Add(lector.GetString(0))
                EngineData.TareaTipoServicio.Add(lector.GetString(0), lector.GetInt64(1))
            End While
            conexion.Close()
        End Using

        Return list
    End Function


    Public Function AddItemsListEstados(ByVal list As DropDownList) As DropDownList
        list.Items.Clear()
        EngineData.TareaEstado.Clear()
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "SELECT Estado, IdEstadoTarea  FROM A_TareaEstado WHERE Activo = @Activo"
        Dim conexion As SqlConnection = New SqlConnection(cnx)

        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@Activo", True)
            Dim lector As SqlDataReader = comando.ExecuteReader()
            While lector.Read()
                list.Items.Add(lector.GetString(0))
                EngineData.TareaEstado.Add(lector.GetString(0), lector.GetInt64(1))
            End While
            conexion.Close()
        End Using

        Return list
    End Function

    Public Function AddItemsListValores(ByVal list As DropDownList) As DropDownList
        list.Items.Clear()
        EngineData.TareaValor.Clear()
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "SELECT Valor, Id FROM A_TareaValor WHERE Tipo = @Tipo"
        Dim conexion As SqlConnection = New SqlConnection(cnx)

        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            comando.Parameters.Clear()
            comando.Parameters.AddWithValue("@Tipo", "Resultado")
            Dim lector As SqlDataReader = comando.ExecuteReader()
            While lector.Read()
                list.Items.Add(lector.GetString(0))
                EngineData.TareaValor.Add(lector.GetString(0), lector.GetInt32(1))
            End While
            conexion.Close()
        End Using

        Return list
    End Function

    Public Function IdValue(ByVal objeto As Dictionary(Of String, Integer), ByVal key As String) As Integer
        For Each x As KeyValuePair(Of String, Integer) In objeto
            If x.Key = key Then
                Return x.Value
            End If
        Next
        Return -1
    End Function


    Public Function IdentificadorReg() As Guid
        Dim g As Guid = New Guid()
        g = CrearGuid()
        While (g = Guid.Empty)
            g = CrearGuid()
        End While
        Return g
    End Function


    Private Function CrearGuid() As Guid
        Return Guid.NewGuid()
    End Function

    Public Function CreateIdTarea() As String
        Dim idTarea As String = String.Empty
        Dim prefix As String = "TA"
        Dim numero As Int32 = NumeroTareas()
        If (numero = 0) Then
            idTarea = prefix & "00000" & "1"
        ElseIf (numero >= 1 And numero <= 9) Then
            idTarea = prefix & "00000" & (numero + 1).ToString()
        ElseIf (numero >= 10 And numero <= 99) Then
            idTarea = prefix & "0000" & (numero + 1).ToString()
        ElseIf (numero >= 100 And numero <= 999) Then
            idTarea = prefix & "000" & (numero + 1).ToString()
        ElseIf (numero >= 1000 And numero <= 9999) Then
            idTarea = prefix & "00" & (numero + 1).ToString()
        End If

        Return idTarea
    End Function

    Private Function NumeroTareas() As Int32
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = "SELECT COUNT(*) As Numero FROM A_PlantillaTarea"
        Dim numero As Int32 = 0
        Dim conexion As SqlConnection = New SqlConnection(cnx)
        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            Dim obj As Object = comando.ExecuteScalar()
            conexion.Close()
            If obj <> Nothing Then
                numero = Convert.ToInt32(obj)
            End If
        End Using
        Return numero
    End Function
End Class
