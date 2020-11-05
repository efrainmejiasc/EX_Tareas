Public Class EngineData

    Private Shared valor As EngineData

    Public Shared Function Instance() As EngineData
        If (valor Is Nothing) Then
            valor = New EngineData()

        End If

        Return valor

    End Function

    Public Shared cadenaConexion As String = ConfigurationManager.ConnectionStrings("CnxTareas").ToString()

    Public Shared Property TareaTipo As New Dictionary(Of String, Integer)

    Public Shared Property TareaEstado As New Dictionary(Of String, Integer)

    Public Shared Property TareaTipoServicio As New Dictionary(Of String, Integer)

    Public Shared Property TareaValor As New Dictionary(Of String, Integer)


    Public Shared Property PostBack As Boolean

    Public Shared Property GdvAsignacion As DataTable

End Class
