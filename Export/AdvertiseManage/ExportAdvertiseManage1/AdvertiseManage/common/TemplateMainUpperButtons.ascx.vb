
Namespace common
    Partial Class TemplateMainUpperButtons
        Inherits UserControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            Dim menu As String = Request.QueryString("m")
            If menu IsNot Nothing Or menu <> "" Then

                Select Case menu
                    Case "1"
                        HomeHyperlink.CssClass = "selected"

                End Select

            End If

            Dim lang As String = Request.QueryString("l")
            selectedlanguage.Src = "../Images/flags/earth.png"

            If lang IsNot Nothing Or lang <> "" Then

                Select Case lang

                    Case "en-US"
                        selectedlanguage.Src = "../Images/flags/MI.gif"

                    Case "fr"
                        selectedlanguage.Src = "../Images/flags/FR.png"

                    Case "es"
                        selectedlanguage.Src = "../Images/flags/ES.png"

                    Case "zh-CN"
                        selectedlanguage.Src = "../Images/flags/CN.png"

                    Case "ru"
                        selectedlanguage.Src = "../Images/flags/RU.png"

                    Case "ar"
                        selectedlanguage.Src = "../Images/flags/AE.png"

                    Case "ja"
                        selectedlanguage.Src = "../Images/flags/JP.png"

                    Case "de"
                        selectedlanguage.Src = "../Images/flags/DE.png"
                End Select

            End If

        End Sub
    End Class
End Namespace