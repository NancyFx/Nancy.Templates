Public Class IndexModule
    Inherits NancyModule

    Public Sub New()
        MyBase.Get("/") = Function(parameters)
                              Return View("index")
                          End Function
    End Sub
End Class
