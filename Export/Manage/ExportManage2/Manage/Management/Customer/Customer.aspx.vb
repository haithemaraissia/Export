
Imports System.Net.Mail
Imports System.Linq
Imports SidejobModel

Namespace Management.User
    Partial Class ManagementUserCustomer
        Inherits Page

        Private Sub CustomerGridViewRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles CustomerGridView.RowCommand
            Dim customerId As String = CustomerGridView.DataKeys(CType(e.CommandArgument.ToString, Integer)).Value.ToString
            Select Case e.CommandName
                Case "AcceptChange"
                    UpdateCustomerPortfolio(customerId)
                Case "DenyChange"
                    DenyCustomer(customerId)
                Case "LockUser"
                    LockCustomer(customerId)
            End Select
        End Sub

        Private Sub UpdateCustomerPortfolio(ByVal customerID As String)
            Dim updatePortfolio As String
            updatePortfolio = " UPDATE CustomerPortfolio SET Modified = 0 WHERE CustomerID = " & customerID.ToString
            CustomerSqlDataSource.UpdateCommand = updatePortfolio
            CustomerSqlDataSource.Update()
        End Sub

        Private Sub DenyCustomer(ByVal customerID As String)
            ''Deny Customer            
            ''Modified = 2 
            Dim updatePortfolio As String
            updatePortfolio = " UPDATE CustomerPortfolio SET Modified = 2 WHERE CustomerID = " & customerID.ToString
            CustomerSqlDataSource.UpdateCommand = updatePortfolio
            CustomerSqlDataSource.Update()
            Using sidejobcontext = New SidejobEntities()
                Dim customer = (From c In sidejobcontext.CustomerGenerals
                Where c.CustomerID = customerID Select c).FirstOrDefault()
                Dim deniedcustomer As New DeniedCustomer
                deniedcustomer.CustomerId = customer.CustomerID
                deniedcustomer.FirstName = customer.FirstName
                deniedcustomer.LastName = customer.LastName
                deniedcustomer.Country = customer.CountryName
                deniedcustomer.Region = customer.RegionName
                deniedcustomer.Age = customer.Age
                deniedcustomer.Gender = customer.Gender
                deniedcustomer.EmailAddress = customer.EmailAddress
                sidejobcontext.AddToDeniedCustomers(deniedcustomer)
            End Using
            SendEmail(CType(customerID, Integer), "Profile Update Denied",
                  "Your portfolio update had been denied due to infringment of website agreement.<br/>" + _
                 "If you want to dispute this transaction, please email us with the explination.<br/>" + _
                 "Sincerely,<br/>" + _
                 "My-Side-Job Team")
        End Sub

        Private Sub LockCustomer(ByVal customerID As String)
            ''Lock Customer
            ''Modified = 3
            Dim updatePortfolio As String
            updatePortfolio = " UPDATE CustomerPortfolio SET Modified = 3 WHERE CustomerID = " & customerID.ToString
            CustomerSqlDataSource.UpdateCommand = updatePortfolio
            CustomerSqlDataSource.Update()
            Using sidejobcontext = New SidejobEntities()
                Dim customer = (From c In sidejobcontext.CustomerGenerals
                Where c.CustomerID = customerID Select c).FirstOrDefault()
                Dim lockedCustomer As New LockedCustomer
                lockedCustomer.CustomerID = customer.CustomerID
                lockedCustomer.FirstName = customer.FirstName
                lockedCustomer.LastName = customer.LastName
                lockedCustomer.Country = customer.CountryName
                lockedCustomer.Region = customer.RegionName
                lockedCustomer.Age = customer.Age
                lockedCustomer.Gender = customer.Gender
                lockedCustomer.EmailAddress = customer.EmailAddress
                lockedCustomer.Reason = "Locked Customer"
                lockedCustomer.Date = Date.UtcNow.Date
                lockedCustomer.IP = 0
                lockedCustomer.ProjectID = 0
                sidejobcontext.AddToLockedCustomers(lockedCustomer)
            End Using
            SendEmail(CType(customerID, Integer), "Account Locked",
                     "Your Account has been locked due to infringment of website agreement.<br/>" + _
                    "If you want to dispute this transaction, please email us with the explination.<br/>" + _
                    "Sincerely,<br/>" + _
                    "My-Side-Job Team")
        End Sub

        Private Sub SendEmail(customerID As Integer, subject As String, body As String)
            Using sidejobcontext = New SidejobEntities()
                Dim receiverEmail As String = (From c In sidejobcontext.CustomerGenerals
                Where c.CustomerID = customerID Select c.EmailAddress).FirstOrDefault()
                Dim mailMessage As New MailMessage
                mailMessage.From = New MailAddress("automated_noreply@programmingfundamental.com")
                mailMessage.To.Add(New MailAddress(receiverEmail))
                mailMessage.Subject = subject
                mailMessage.Body = body
                mailMessage.IsBodyHtml = True
                Dim smtpClient As New SmtpClient()
                Dim userState As Object = mailMessage
                'AddHandler smtpClient.SendCompleted, AddressOf SmtpClient_OnCompleted
                Try
                    smtpClient.SendAsync(mailMessage, userState)
                Catch smtpEx As SmtpException
                    InsertEmailSentException(customerID, "Error while Sending the Email", receiverEmail)
                Catch ex As Exception
                    InsertEmailSentException(customerID, "Error while Sending the Email", receiverEmail)
                End Try
            End Using
        End Sub

        'Private Sub SmtpClient_OnCompleted(ByVal sender As Object, ByVal e As ComponentModel.AsyncCompletedEventArgs)
        '    If (e.Cancelled) Then
        '        InsertEmailSentException(0, "CanceledReceiver", )
        '    End If

        '    If Not (e.Error Is Nothing) Then
        '        InsertEmailSentException(0, "ErrorSending", )
        '    Else
        '    End If
        'End Sub

        Private Sub InsertEmailSentException(customerID As Integer, reason As String, Optional receiverEmail As String = "NoEmailAddress")
            Using sidejobcontext = New SidejobEntities()
                Dim emailException As New EmailSentException
                emailException.Reason = reason
                emailException.UserId = customerID
                emailException.EmailAddress = receiverEmail
                emailException.DateTime = Date.UtcNow.Date
                emailException.UserRole = "CUS"
                sidejobcontext.AddToEmailSentExceptions(emailException)
                sidejobcontext.SaveChanges()
            End Using
        End Sub

        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If Page.IsPostBack Then
                Return
            End If
            Utility.Authenticate()
        End Sub

    End Class
End Namespace