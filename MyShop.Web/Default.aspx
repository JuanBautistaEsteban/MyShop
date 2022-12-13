<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyShop.Web._Default" %>
    
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/materialize.min.js"></script>
    <script src="Scripts/main.js"></script>
    
    <div>
        <h1>Bienvenidos a la tienda virtual de MyShop</h1>
        <p class="lead">Cientos de productos a su disposición con un solo clic.<br />
            Ofertas especiales, Tecnología, Música, Libros, Perfumería y Cosméticos.
        </p>
    </div>

    <div class="container">
        <div class="rowcol-md-4">
            <div class ="col s12">
                <div class="carousel center-align">

                    <div class =" carousel-item ">
                        <h2 class="subtitulo">Tecnología</h2>
                        <div class="linea-division "></div>
                        <p class="producto">Telefonía móvil</p>
                        <img src="img/Carrusel/movil1.jpg" />
                    </div>

                     <div class =" carousel-item ">
                        <h2 class="subtitulo">Cultura</h2>
                         <div class="linea-division "></div>
                        <p class="producto">Libros</p>
                         <img src="img/Carrusel/libros.jpg" />
                    </div>

                    <div class =" carousel-item ">
                        <h2 class="subtitulo">Cosmética</h2>
                        <div class="linea-division "></div>
                        <p class="producto">Perfumes</p>
                        <img src="img/Carrusel/perfume2.jpg" />
                    </div>

                    <div class =" carousel-item ">
                        <h2 class="subtitulo">Tecnología</h2>
                         <div class="linea-division "></div>
                        <p class="producto">Portatiles</p>
                         <img src="img/Carrusel/portatil1.jpg" />
                    </div>

                    <div class =" carousel-item ">
                        <h2 class="subtitulo">Cultura</h2>
                        <div class="linea-division "></div>
                        <p class="producto">Música</p>
                        <img src="img/Carrusel/musica.jpg" />
                    </div>

                     <div class =" carousel-item ">
                        <h2 class="subtitulo">Cosmética</h2>
                        <div class="linea-division "></div>
                        <p class="producto">Maquillaje</p>
                        <img src="img/Carrusel/maquillaje.jpg" />
                    </div>
                     
                </div>

            </div>
        </div>
        
    </div>

</asp:Content>
