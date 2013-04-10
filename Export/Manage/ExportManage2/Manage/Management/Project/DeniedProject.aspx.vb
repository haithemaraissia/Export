
Imports SidejobModel

Namespace Management.Project

    Partial Class ManagementProjectDeniedProject
        Inherits Page
        Private Sub ProjectGridViewRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles ProjectGridView.RowCommand
            Dim projectId As String = ProjectGridView.DataKeys(CType(e.CommandArgument.ToString, Integer)).Value.ToString
            Select Case e.CommandName
                Case "AcceptChange"
                    AcceptProject(projectId)
            End Select
        End Sub

        Private Sub AcceptProject(ByVal projectID As String)
            Using sidejobcontext = New SidejobEntities()
                sidejobcontext.AcceptProject(CType(projectID, Integer?))
            End Using
            Dim deletePendingProject As String
            deletePendingProject = "DELETE FROM DeniedProject WHERE ProjectID = " & projectID.ToString
            ProjectSqlDataSource.DeleteCommand = deletePendingProject
            ProjectSqlDataSource.Delete()
        End Sub

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If Page.IsPostBack Then
                Return
            End If
            Utility.Authenticate()
        End Sub
    End Class

End Namespace