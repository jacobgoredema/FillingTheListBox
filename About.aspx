<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
<p>&nbsp;</p>
<p>
    <asp:Label ID="Label1" runat="server" Text="Select Author:"></asp:Label>
    <asp:DropDownList ID="lstAuthor" runat="server" Height="35px" Width="221px">
    </asp:DropDownList>
</p>
<p>&nbsp;</p>
<p>
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</p>
</asp:Content>
