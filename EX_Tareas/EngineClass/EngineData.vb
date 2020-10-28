Public Class EngineData

    Private Shared valor As EngineData

    Public Shared Function Instance() As EngineData
        If (valor Is Nothing) Then
            valor = New EngineData()

        End If

        Return valor

    End Function

    Public Shared cadenaConexion As String = ConfigurationManager.ConnectionStrings("CnxTareas").ToString()


End Class
