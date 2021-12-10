Imports Microsoft.Security.Application

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim filename As String
        filename = "c:\\newfolder\\<script>alert('suck');</script>"
        filename = Sanitizer.GetSafeHtmlFragment(filename)


        System.Web.HttpContext.Current.Response.Write(Environment.NewLine)
        System.Web.HttpContext.Current.Response.Write(filename)
        System.Web.HttpContext.Current.Response.Write(filename)

        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
