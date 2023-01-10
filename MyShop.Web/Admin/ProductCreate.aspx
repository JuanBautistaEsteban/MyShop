<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCreate.aspx.cs" Inherits="MyShop.Web.Admin.ProductCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class ="form-horizontal ">
        <h4>Altas de productos</h4>
        <hr />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger "/>


        <div class="form-group ">
            <asp:Label ID="Label3" style="Font-Size:1.5rem" runat="server" Text="Área a la que pertence el producto:" CssClass ="col-md-3" AssociatedControlID ="ddlType"></asp:Label>
            <div class ="col-md-9 " >
                <asp:DropDownList ID="ddlType" runat="server" CssClass ="form-control"   AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                
            </div>
        </div>
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        <br /><br />

        <div class="form-group ">
            <asp:Label ID="Label8" style="Font-Size:1.5rem" runat="server" Text="Sección a la que pertence el producto:" CssClass ="col-md-3" AssociatedControlID ="ddlSeccion"></asp:Label>
            <div class ="col-md-9 " >
                <asp:DropDownList ID="ddlSeccion" runat="server" CssClass ="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlSeccion_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
        <br /><br />

        <div class ="form-group ">
            <asp:Label ID="Label10" style="Font-Size:1.5rem" runat="server" Text="Productos registrados:" CssClass ="col-md-3" AssociatedControlID ="ddlSeccion"></asp:Label>
            <div class ="col-md-9 ">
                <asp:DropDownList ID="ddlProductos" runat="server" CssClass ="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
        <br /><br />

        <div class="form-group ">
            <asp:Label ID="Label1" style="Font-Size:1.5rem"  runat ="server" Text="Nombre del nuevo producto:" CssClass ="col-md-3" AssociatedControlID ="txtNombre"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtNombre" runat="server" CssClass ="form-control"></asp:TextBox>
                <asp:Button ID="btnLimpiarCajas" runat="server" Text="Limpiar cajas para nuevo producto" OnClick="btnLimpiarCajas_Click" />
            </div>
        </div>
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
                <asp:ListBox ID="LstImagenes" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="LstImagenes_SelectedIndexChanged"></asp:ListBox>
                <asp:Image ID="Image1" runat="server" BorderColor ="Black"  Width="200" Height="200" />
            </div>
        </div>
        
        <div class ="form-group ">
            <div class ="col-md-1" style ="margin : 5px ">
                <asp:Button ID="btnSubmit" runat="server" Text="Alta Producto"  CssClass ="btn btn-default " OnClick="btnSubmit_Click"  />
            </div>
        </div>
        <br /><br /><br /><br /><br /><br /><br /><br />
    </div>

</asp:Content>