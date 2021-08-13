<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EBS.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyPlaceHolder" runat="server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <label>User Name:</label>
            <asp:TextBox ID="userNameTextBox" runat="server"></asp:TextBox>
            <label>Password:</label>
            <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
            <label>First Name:</label>
            <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
            <label>Last Name:</label>
            <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
            <label>User Type:</label>
            <asp:TextBox ID="userTypeTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="saveButton" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="saveButton_Click" />
            <br />
            <br />
            <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>