<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SectionCreate.aspx.cs" Inherits="MyShop.Web.Admin.SectionCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class ="form-horizontal">
        <h4>Crear Sección de productos</h4>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger"/>

         <div class="form-group ">
            <asp:Label ID="Label3" style="Font-Size:1.5rem" runat="server" Text="Área a la que pertence la sección:" CssClass ="col-md-3" AssociatedControlID ="ddlType"></asp:Label>
            <div class ="col-md-9 " >
                <asp:DropDownList ID="ddlType" runat="server" CssClass ="form-control"  AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <br /><br /><br />

        <div class ="form-group ">
            <asp:Label ID="Label4" style="Font-Size:1.5rem" runat="server" Text="Secciones ya asignadas al área:" CssClass ="col-md-3" AssociatedControlID ="lstBoxSeccionesCreadas"></asp:Label>
            <div class ="col-md-9 " >
                <asp:ListBox ID="lstBoxSeccionesCreadas" Width="25%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstBoxSeccionesCreadas_SelectedIndexChanged"></asp:ListBox>
            </div>
        </div>
        
        <br /><br /><br />

        <div class="form-group ">
            <asp:Label ID="Label1" style="Font-Size:1.5rem"  runat ="server" Text="Nombre de la sección:" CssClass ="col-md-3" AssociatedControlID ="txtNombre"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtNombre" runat="server" CssClass ="form-control"></asp:TextBox>
                <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El nombre de la sección es obligatorio." ControlToValidate="txtNombre" Text="*"></asp:RequiredFieldValidator>-->
            </div>
        </div>

        <br />

        <div class ="form-group ">
            <div class ="col-md-1" style ="margin : 5px ">
                <asp:Button ID="btnSubmit" runat="server" Text="Crear sección" CssClass ="btn btn-default" OnClick="btnSubmit_Click"  />
             </div>
            <div class ="col-md-2" style ="margin : 5px ">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar nombre" CssClass ="btn btn-default" OnClick="btnActualizar_Click" />
            </div> 
            <div class ="col-md-3" style ="margin : 5px ">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar sección" CssClass ="btn btn-default " OnClientClick="ConfirmarEliminarSeccion()" OnClick="btnEliminar_Click"/>
           </div>
        </div>
        <br /><br />

        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>


    </div>
</asp:Content>
