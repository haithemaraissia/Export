<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Plain.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:Label ID="ComingSoonLabel" runat="server" Width="100%" Text="<%$ Resources:Resource, ComingSoon %>"
            Style="color: #003366; font-weight: 700"></asp:Label>
    </p>
</asp:Content>

