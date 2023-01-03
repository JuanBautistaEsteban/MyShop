<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AreaEdit.aspx.cs" Inherits="MyShop.Web.Admin.AreaEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

     <div class ="form-horizontal">
        <h4>Edición de Áreas de productos</h4>
        <hr />

         <div class="form-group ">
            <asp:Label ID="Label3" style="Font-Size:1.5rem" runat="server" Text="Área que desea editar:" CssClass ="col-md-3" AssociatedControlID ="ddlAreas"></asp:Label>
             <div class ="col-md-9">
                 <asp:DropDownList ID="ddlAreas" runat="server" CssClass ="form-control"  AutoPostBack="True" ></asp:DropDownList>

             </div>
        </div>

        <br /><br /><br />
        
        <div class="form-group ">
            <asp:Label ID="Label1" style="Font-Size:1.5rem"  runat ="server" Text="Nueva denominación del área:" CssClass ="col-md-3" AssociatedControlID ="txtNombre"></asp:Label>
            <div class ="col-md-9" >
                <asp:TextBox ID="txtNombre" runat="server" CssClass ="form-control"></asp:TextBox>
            </div>
        </div>
    </div>

    <br /><br /><br />
    
    

    <div class ="form-group ">
        <div class ="col-md-1" style ="margin : 5px ">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar denominación" CssClass ="btn btn-default " OnClick="btnActualizar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Área" CssClass ="btn btn-default" OnClientClick="Confirm('Centollos')" OnClick="btnEliminar_Click"  />
        </div>
   </div>

    <br /><br /><br />

    
</asp:Content>
