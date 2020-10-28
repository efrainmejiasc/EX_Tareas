Imports System.Data.SqlClient
Imports DevExpress.Web

Public Class Utilidad

    Public Function PrioridadItems(ByVal list As DropDownList) As DropDownList
        list.Items.Clear()
        list.Items.Add("Alta")
        list.Items.Add("Media")
        list.Items.Add("Baja")
        Return list
    End Function

    Public Function AddItemsList(ByVal list As DropDownList, ByVal tipo As String) As DropDownList
        list.Items.Clear()
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = QueryItems(tipo)
        Dim conexion As SqlConnection = New SqlConnection(cnx)

        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            Dim lector As SqlDataReader = comando.ExecuteReader()
            While lector.Read()
                list.Items.Add(lector.GetString(0))
            End While
            conexion.Close()
        End Using

        Return list
    End Function

    Public Function AddItemsList(ByVal list As ListBox, ByVal tipo As String) As ListBox
        list.Items.Clear()
        Dim cnx As String = EngineData.cadenaConexion
        Dim query As String = QueryItems(tipo)
        Dim conexion As SqlConnection = New SqlConnection(cnx)

        Using conexion
            conexion.Open()
            Dim comando = New SqlCommand(query, conexion)
            comando.CommandType = CommandType.Text
            Dim lector As SqlDataReader = comando.ExecuteReader()
            While lector.Read()
                list.Items.Add(lector.GetString(0))
            End While
            conexion.Close()
        End Using

        Return list
    End Function

    Public Function QueryItems(ByVal tipo As String) As String
        Dim query As String = String.Empty

        If (tipo = "tareas") Then
            query = "SELECT  Tipo FROM A_TareaTipo"
        ElseIf (tipo = "usuarios") Then
            query = "SELECT  UserName FROM A_Usuarios"
        ElseIf (tipo = "resultados") Then
            query = "SELECT Valor FROM A_TareaValor WHERE Tipo = 'Resultado'"
        End If

        Return query
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
