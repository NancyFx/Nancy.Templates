Imports Nancy.Hosting.Self

Module Program

    Sub Main()
        Dim uri = New Uri("http://localhost:3579")

        Using host = New NancyHost(uri)

            host.Start()

            Console.WriteLine("Your application is running on {0}", uri)
            Console.WriteLine("Press any [Enter] to close the host.")
            Console.ReadLine()
        End Using
    End Sub

End Module
