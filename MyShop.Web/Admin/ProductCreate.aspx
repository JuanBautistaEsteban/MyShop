<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCreate.aspx.cs" Inherits="MyShop.Web.Admin.ProductCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class ="form-horizontal ">
        <h4>Administración de productos</h4>
        <hr />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger "/>

        

        <div class="form-group ">
            <asp:Label ID="Label3" style="Font-Size:1.5rem" runat="server" Text="Área a la que pertence el producto:" CssClass ="col-md-3" AssociatedControlID ="ddlType"></asp:Label>
            <div class ="col-md-9 " >
                <asp:DropDownList ID="ddlType" runat="server" CssClass ="form-control"   AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                
            </div>
        </div>

        <!--<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>-->

        <br /><br />

        <div class="form-group ">
            <asp:Label ID="Label8" style="Font-Size:1.5rem" runat="server" Text="Sección a la que pertence el producto:" CssClass ="col-md-3" AssociatedControlID ="ddlSeccion"></asp:Label>
            <div class ="col-md-9 " >
                <asp:DropDownList ID="ddlSeccion" runat="server" CssClass ="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlSeccion_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        
        <!--<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>-->
        
        <br /><br />

        <div class ="form-group ">
            <asp:Label ID="Label10" style="Font-Size:1.5rem" runat="server" Text="Productos registrados:" CssClass ="col-md-3" AssociatedControlID ="ddlSeccion"></asp:Label>
            <div class ="col-md-9 ">
                <asp:DropDownList ID="ddlProductos" runat="server" CssClass ="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>

        <!--<asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>-->
        
        <br /><br />

        <div class="form-group ">
            <!--<div class ="col-md-9" >-->
                    <asp:Button ID="btnLimpiarCajas" runat="server" Text="Limpiar cajas para nuevo producto" OnClick="btnLimpiarCajas_Click" />
            <!--</div>-->
            <br /><br />
            <asp:Label ID="Label1" style="Font-Size:1.5rem"  runat ="server" Text="Nombre del nuevo producto:" CssClass ="col-md-3" AssociatedControlID ="txtNombre"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtNombre" runat="server" CssClass ="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre del producto es obligatorio." ControlToValidate="txtNombre" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <br /><br />

         <div class="form-group ">
            <asp:Label ID="Label2" style="Font-Size:1.5rem"  runat ="server" Text="Descripción del producto:" CssClass ="col-md-3" AssociatedControlID ="txtDescripcion"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass ="form-control" TextMode ="MultiLine" Rows ="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="La descripción del producto es obligatorio." ControlToValidate="txtDescripcion" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <br /><br /><br /><br /><br />

        <div class="form-group ">
            <asp:Label ID="Label4" style="Font-Size:1.5rem"  runat ="server" Text="Precio de venta:" CssClass ="col-md-3" AssociatedControlID ="txtPrecio"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtPrecio" runat="server" CssClass ="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El precio del producto es obligatorio." ControlToValidate="txtPrecio" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <br /><br />

        <div class="form-group ">
            <asp:Label ID="Label5" style="Font-Size:1.5rem"  runat ="server" Text="Unidades en almacén:" CssClass ="col-md-3" AssociatedControlID ="txtStock"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtStock" runat="server" CssClass ="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El stock del producto es obligatorio." ControlToValidate="txtStock" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>
       
        <br /><br />

        <div class="form-group ">
            <asp:Label ID="Label6" style="Font-Size:1.5rem"  runat ="server" Text="Imágenes del producto:" CssClass ="col-md-3" AssociatedControlID ="FileUpload1"></asp:Label>
            <div class ="col-md-9" >
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <div class ="col-md-1" style ="margin-right  : 5px;  margin-top : 15px ">
                    <asp:Button ID="AddImg" runat="server" Text="Añadir Imágen" OnClick="AddImg_Click" />
                </div>
                <div class ="col-md-1" style ="margin-left  : 35px;  margin-top : 15px ">
                    <asp:Button ID="DelImg" runat="server" Text="Borrar Imágen" OnClick="DelImg_Click" />
                </div>
            </div>
        </div>
        <br /><br /><br />
        <div class="form-group ">
            <asp:Label ID="LabelX" style="Font-Size:1.5rem"  runat ="server" Text="" CssClass ="col-md-3"></asp:Label>
            <div class ="col-md-9 " style =" width : 25%; margin-right : 15px " >
                <asp:ListBox ID="LstImagenes" runat="server" AutoPostBack="true" OnSelectedIndexChanged ="LstImagenes_SelectedIndexChanged" Rows="8"></asp:ListBox>
                <asp:ListBox ID="LstImagenesBorrar" Visible ="false"  runat ="server"></asp:ListBox>
            </div>
            <div class ="col-md-offset-9" style =" width : 25%">
                <asp:Image ID="Image1"  runat="server" BorderColor ="Black"  Width="180" Height="200" alt="Imágen del producto."  BorderWidth="1px"/>
            </div>
        </div>
        <br /><br />
        
        <div class ="form-group ">
            <div class ="col-md-1" style ="margin-right  : 15px ">
                <asp:Button ID="AltaProducto" runat="server" Text="Alta Producto"  CssClass ="btn btn-default " OnClick="AltaProducto_Click"  />
            </div>
            <div class ="col-md-1" style ="margin-right  : 30px ">
                <asp:Button ID="EditarProducto" runat="server" Text="Editar Producto" CssClass ="btn btn-default " OnClick="EditarProducto_Click"/>
            </div>
            <div class ="col-md-1" style ="margin-right  : 15px ">
                <asp:Button ID="EliminarProducto" runat="server" Text="Eliminar Producto" CssClass ="btn btn-default " OnClick="EliminarProducto_Click" />
            </div>
            <div class ="col-md-1" style ="margin-right  : 15px ">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass ="btn btn-default " OnClick="btnLimpiar_Click" />
                <asp:Label ID="LabelUser" runat="server" Text="Label"></asp:Label>
            </div> 
        </div>
        
    </div>
   <br />

</asp:Content>