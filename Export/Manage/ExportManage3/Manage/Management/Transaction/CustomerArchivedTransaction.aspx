<%@ Page Title="" Language="C#" MasterPageFile="~/Plain.master" AutoEventWireup="true" CodeFile="CustomerArchivedTransaction.aspx.cs" Inherits="Management_Transaction_CustomerArchivedTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        Archieved</p>
    <p>
        <asp:GridView ID="SuccessfulPDTGridView" runat="server" 
            DataSourceID="SuccessfulPDTSqlDataSource" AutoGenerateColumns="False" 
            DataKeyNames="PDTID">
            <Columns>
                <asp:BoundField DataField="PDTID" HeaderText="PDTID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="PDTID" />
                <asp:BoundField DataField="GrossTotal" HeaderText="GrossTotal" 
                    SortExpression="GrossTotal" />
                <asp:BoundField DataField="Invoice" HeaderText="Invoice" 
                    SortExpression="Invoice" />
                <asp:BoundField DataField="PaymentStatus" HeaderText="PaymentStatus" 
                    SortExpression="PaymentStatus" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" 
                    SortExpression="LastName" />
                <asp:BoundField DataField="PaymentFee" HeaderText="PaymentFee" 
                    SortExpression="PaymentFee" />
                <asp:BoundField DataField="BusinessEmail" HeaderText="BusinessEmail" 
                    SortExpression="BusinessEmail" />
                <asp:BoundField DataField="TxToken" HeaderText="TxToken" 
                    SortExpression="TxToken" />
                <asp:BoundField DataField="ReceiverEmail" HeaderText="ReceiverEmail" 
                    SortExpression="ReceiverEmail" />
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" 
                    SortExpression="ItemName" />
                <asp:BoundField DataField="CurrencyCode" HeaderText="CurrencyCode" 
                    SortExpression="CurrencyCode" />
                <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" 
                    SortExpression="TransactionId" />
                <asp:BoundField DataField="Custom" HeaderText="Custom" 
                    SortExpression="Custom" />
                <asp:BoundField DataField="subscriberId" HeaderText="subscriberId" 
                    SortExpression="subscriberId" />
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" 
                    SortExpression="CustomerID" />
                <asp:BoundField DataField="ProjectID" HeaderText="ProjectID" 
                    SortExpression="ProjectID" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SuccessfulPDTSqlDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SideJobConnectionString %>" 
            SelectCommand="SELECT * FROM [ArchivedRefundCustomerSuccessfulPDT]">
        </asp:SqlDataSource>
    </p>
</asp:Content>

