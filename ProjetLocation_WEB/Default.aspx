<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjetLocation_WEB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" Height="455px">
            <p>Login</p>
            <div style="padding: 10px;">
                <p>ID: <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="IDRequis" runat="server" Text="*ID requis" ForeColor="Red" Font-Bold="True"></asp:Label>
                </p>
                <p>Password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="passRequis" runat="server" Text="*password requis" ForeColor="Red" Font-Bold="True"></asp:Label>
                </p>
                <p><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></p>
            </div>
        </asp:Panel>
    </form>
</asp:Content>
