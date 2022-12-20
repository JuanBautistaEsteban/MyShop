<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCreate.aspx.cs" Inherits="MyShop.Web.Admin.ProductCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class ="form-horizontal ">
        <h4>Altas de productos</h4>
        <hr />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger "/>

        <div class="form-group ">
            <asp:Label ID="Label1" style="Font-Size:1.5rem"  runat ="server" Text="Nombre del producto:" CssClass ="col-md-3" AssociatedControlID ="txtNombre"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtNombre" runat="server" CssClass ="form-control"></asp:TextBox>
            </div>
        </div>

        <br /><br /><br />

         <div class="form-group ">
            <asp:Label ID="Label3" style="Font-Size:1.5rem" runat="server" Text="Área a la que pertence el producto:" CssClass ="col-md-3" AssociatedControlID ="ddlType"></asp:Label>
            <div class ="col-md-9 " >
                <asp:DropDownList ID="ddlType" runat="server" CssClass ="form-control"  OnTextChanged="ddlType_TextChanged"></asp:DropDownList>
            </div>
        </div>
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        <br /><br />

         <div class="form-group ">
            <asp:Label ID="Label2" style="Font-Size:1.5rem"  runat ="server" Text="Descripción del producto:" CssClass ="col-md-3" AssociatedControlID ="txtDescripcion"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass ="form-control" TextMode ="MultiLine" Rows ="10"></asp:TextBox>
            </div>
        </div>

        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

        <div class="form-group ">
            <asp:Label ID="Label4" style="Font-Size:1.5rem"  runat ="server" Text="Precio de venta:" CssClass ="col-md-3" AssociatedControlID ="txtPrecio"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtPrecio" runat="server" CssClass ="form-control"></asp:TextBox>
            </div>
        </div>

        <br /><br />

        <div class="form-group ">
            <asp:Label ID="Label5" style="Font-Size:1.5rem"  runat ="server" Text="Unidades en almacén:" CssClass ="col-md-3" AssociatedControlID ="txtStock"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtStock" runat="server" CssClass ="form-control"></asp:TextBox>
            </div>
        </div>
       
        <br /><br />

        <div class="form-group ">
            <asp:Label ID="Label6" style="Font-Size:1.5rem"  runat ="server" Text="Imágenes del producto:" CssClass ="col-md-3" AssociatedControlID ="FileUpload1"></asp:Label>
            <div class ="col-md-9" >
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="Añadir Imagen" OnClick="Button1_Click" />
                <br />
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            </div>
        </div>

        <div class ="form-group ">
            <div class ="col-md-1" style ="margin : 5px ">
                <asp:Button ID="btnSubmit" runat="server" Text="Alta Producto" CssClass ="btn btn-default "  />
            </div>
        </div>
        <br /><br /><br /><br /><br /><br /><br /><br />
    </div>

</asp:Content>