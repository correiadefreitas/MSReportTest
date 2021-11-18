Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        Dim executable As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim appPath As String = System.IO.Path.GetDirectoryName(executable)
        AppDomain.CurrentDomain.SetData("DataDirectory", appPath)

        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class