<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AreaCreate.aspx.cs" Inherits="MyShop.Web.Admin.AreaCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class ="form-horizontal">
        <h4>Crear Área de productos</h4>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"/>
        
        <div class="form-group ">
            <asp:Label ID="Label1" style="Font-Size:1.5rem"  runat ="server" Text="Introduzca la denominación de la nueva área:" CssClass ="col-md-3" AssociatedControlID ="txtNombreArea"></asp:Label>
            <div class ="col-md-9">
                <asp:TextBox ID="txtNombreArea" runat="server" CssClass ="form-control"></asp:TextBox>
            </div>
        </div>

        <br />

        <div class ="form-group ">
            <div class ="col-md-1" style ="margin : 5px ">
                <asp:Button ID="btnSubmit" runat="server" Text="Crear" CssClass ="btn btn-default " OnClick="btnSubmit_Click" />
            </div>
        </div>
        <br /><br />
    </div>

</asp:Content>