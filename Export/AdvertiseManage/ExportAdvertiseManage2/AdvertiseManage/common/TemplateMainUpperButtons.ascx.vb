﻿
Namespace common
    Partial Class TemplateMainUpperButtons
        Inherits UserControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            SelectedLanguages()
            SelectedUpperMenuStyle()
        End Sub


        Protected Sub SelectedUpperMenuStyle()

            Dim requestUrl As String = HttpContext.Current.Request.Url.ToString()
            'Default
            HomeHyperlink.CssClass = "selected"
            ManagementHyperLink.CssClass = ""
            AccountHyperLink.CssClass = ""
            HelpHyperlink.CssClass = ""

            If String.IsNullOrEmpty(requestUrl) Then
                HomeHyperlink.CssClass = "selected"
                ManagementHyperLink.CssClass = ""
                AccountHyperLink.CssClass = ""
                HelpHyperlink.CssClass = ""
            ElseIf requestUrl.Contains(Resources.Resource.Home) Then
                HomeHyperlink.CssClass = "selected"
                ManagementHyperLink.CssClass = ""
                AccountHyperLink.CssClass = ""
                HelpHyperlink.CssClass = ""
            ElseIf requestUrl.Contains(Resources.Resource.Management) Then
                HomeHyperlink.CssClass = ""
                ManagementHyperLink.CssClass = "selected"
                AccountHyperLink.CssClass = ""
                HelpHyperlink.CssClass = ""
            ElseIf requestUrl.Contains(Resources.Resource.Account) Then
                HomeHyperlink.CssClass = ""
                ManagementHyperLink.CssClass = ""
                AccountHyperLink.CssClass = "selected"
                HelpHyperlink.CssClass = ""
            ElseIf requestUrl.Contains(Resources.Resource.Help) Then
                HomeHyperlink.CssClass = ""
                ManagementHyperLink.CssClass = ""
                AccountHyperLink.CssClass = ""
                HelpHyperlink.CssClass = "selected"
            End If

        End Sub

        Protected Sub SelectedLanguages()
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