using Microsoft.AspNet.Identity;
using MyShop.Application;
using MyShop.CORE;
using MyShop.DAL;
using MyShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace MyShop.Web.Admin
{
    public partial class ProductCreate : System.Web.UI.Page
    {
        string RutaTemporal = "";
        

        // Creamos un manager generico
        GenericManager<Area> AreaManager = null;

        // Creamos un manager para las secciones almacenadas
        SectionManager SectionManager = null;


        //Creamos el manager para el producto
        ProductManager  ProductManager = null;


        //Creamos un manager para las imágenes almacenadas
        ImgManager ImgManager = null;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationDbContext contextDB = new ApplicationDbContext();
            AreaManager = new GenericManager<Area>(contextDB);
            SectionManager = new SectionManager(contextDB);
            ProductManager = new ProductManager(contextDB);
            ImgManager = new ImgManager(contextDB);

            //Prueba de carga de una imágen
            Image1.ImageUrl = Constants.IMAGEN_LOGO ;




            if (!IsPostBack)
            {
                List<Area> list = new List<Area>();
                list = AreaManager.GetAll().AsEnumerable().ToList();

                ddlType.DataSource = list;
                ddlType.DataTextField = "Description";
                ddlType.DataValueField = "Id";
                ddlType.DataBind();

                CargarSecciones();
                CargarProductos();
                if (ddlProductos.Items.Count > 0)
                    MostrarDatosProducto();
                else
                    limpiarCajas(true);
            }

            

        }


        // Selección de elementos de los desplegables.
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSecciones();
            CargarProductos();
            if(ddlProductos .Items.Count > 0)
                MostrarDatosProducto();
            else
                limpiarCajas(true);
        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProductos();
            if (ddlProductos.Items.Count > 0)
                MostrarDatosProducto();
            else
                limpiarCajas(true);
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosProducto();
        }


        // Carga de los datos de las secciones de un área y los productos de una sección
        private void CargarSecciones()
        {
            ddlSeccion.Items.Clear();

            List<CORE.Section> list = new List<CORE.Section>();
            list = SectionManager.GetByAreaId(int.Parse(ddlType.SelectedValue)).AsEnumerable().ToList();

            ddlSeccion.DataSource = list;
            ddlSeccion.DataTextField = "Name";
            ddlSeccion.DataValueField = "Id";
            ddlSeccion.DataBind();
        }

        private void CargarProductos()
        {
            ddlProductos.Items.Clear();

            List<Product> list = new List<Product>();
            if (!(ddlSeccion.Items.Count == 0))
            {
                list = ProductManager.GetBySectionId(int.Parse(ddlSeccion.SelectedValue)).AsEnumerable().ToList();
                ddlProductos.DataSource = list;
                ddlProductos.DataTextField = "Name";
                ddlProductos.DataValueField = "Id";
                ddlProductos.DataBind();
            }
        }


        // Mostrar los datos del producto seleccionado
        private void MostrarDatosProducto()
        {
            //Producto seleccinado
            Product productSelect = new Product();
            productSelect = ProductManager.GetById(int.Parse(ddlProductos.SelectedValue));

            txtNombre.Text = productSelect.Name;
            txtDescripcion.Text = productSelect.Description;
            txtPrecio.Text = productSelect.Price.ToString();
            txtStock.Text = productSelect.Stock.ToString();

            List<ImgProduct> list = new List<ImgProduct>();
            list = ImgManager.GetByProductId(productSelect.Id).AsEnumerable().ToList();

            LstImagenes.DataSource = list;
            LstImagenes.DataTextField = "FileName";
            LstImagenes.DataBind();

            AltaProducto.Enabled = false;
            EditarProducto.Enabled = true;
            EliminarProducto.Enabled = true;
        }


        // Seleccionar una imágen de la lista.
        protected void LstImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (File.Exists(Request.PhysicalApplicationPath + Constants.DESTINO_IMAGENES_PRODUCTOS + LstImagenes.SelectedValue))
                Image1.ImageUrl = Constants.RUTA_RELATIVA_CARGA_IMAGENES_PRODUCTOS + LstImagenes.SelectedValue;
            else
                Image1.ImageUrl = Constants.RUTA_TEMPORAL_SUBIR_IMAGENES_PRODUCTOS + LstImagenes.SelectedValue;

        }


        // Añadir y eliminar imágenes de la lista
        protected void AddImg_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                RutaTemporal = Request.PhysicalApplicationPath + Constants.RUTA_TEMPORAL_SUBIR_IMAGENES_PRODUCTOS;
                RutaTemporal += User.Identity.GetUserId() + FileUpload1.FileName;
                FileUpload1.SaveAs(RutaTemporal);
                LstImagenes.Items.Add(User.Identity.GetUserId() + FileUpload1.FileName);
                Label7.Text = ddlType.SelectedValue;
            }
        }

        protected void DelImg_Click(object sender, EventArgs e)
        {
            //Solo vamos a quitar la imagen del listado. 
            LstImagenesBorrar.Items.Add(LstImagenes.SelectedItem);
            LstImagenes.Items.Remove(LstImagenes.SelectedItem);
        }


        // Eventos Alta, Edición y Eliminación de productos
        protected void AltaProducto_Click(object sender, EventArgs e)
        {
            int nuevoId = 0;
            // Alta del producto
            Product product = new Product()

            {
                Name = txtNombre.Text,
                Description = txtDescripcion.Text,
                Price = double.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Section_Id = int.Parse(ddlSeccion.SelectedValue),

            };


            if (!ComprobarProducto())
            {
                Product nuevoProducto = new Product();
                ProductManager.Add(product);
                ProductManager.Context.SaveChanges();
                nuevoProducto = ProductManager.GetByName(product.Name);
                nuevoId = nuevoProducto.Id;


            }


            //Alta de las imágenes asociadas.

            ImgProduct imgProduct = new ImgProduct();

            foreach (ListItem fichero in LstImagenes.Items)
            {
                string NombreCopia = DateTime.Now.Year.ToString() + "_" +
                                     DateTime.Now.Month.ToString() + "_" +
                                     DateTime.Now.Day.ToString() + "_" +
                                     DateTime.Now.Hour.ToString() + "_" +
                                     DateTime.Now.Minute.ToString() + "_" +
                                     DateTime.Now.Second.ToString() + "_" +
                                     DateTime.Now.Millisecond.ToString() +
                                     User.Identity.GetUserId() +
                                     Path.GetExtension(fichero.Text);

                File.Copy(Request.PhysicalApplicationPath + Constants.RUTA_TEMPORAL_SUBIR_IMAGENES_PRODUCTOS + fichero.Text, Request.PhysicalApplicationPath + Constants.DESTINO_IMAGENES_PRODUCTOS + NombreCopia);

                imgProduct.FileName = NombreCopia;
                imgProduct.Product_Id = nuevoId;

                ImgManager.Add(imgProduct);
                ImgManager.Context.SaveChanges();


            }
            Response.Redirect("ProductCreate");
        }
        protected void EditarProducto_Click(object sender, EventArgs e)
        {



            if (!ComprobarProducto(int.Parse(ddlProductos.SelectedValue)))
            {

                //Producto seleccinado 
                Product productSelect = new Product();
                productSelect = ProductManager.GetById(int.Parse(ddlProductos.SelectedValue));
                productSelect.Name = txtNombre.Text;
                productSelect.Description = txtDescripcion.Text;
                productSelect.Price = Double.Parse(txtPrecio.Text);
                productSelect.Stock = int.Parse(txtStock.Text);
                productSelect.Section_Id = int.Parse(ddlSeccion.SelectedValue);
                //Salvamos los datos en la tabla Products
                ProductManager.Context.SaveChanges();



                //Imágenes
                bool cambios = false;

                //1º Borramos las que ya no se quieren
                foreach (ListItem archivoBorrar in LstImagenesBorrar.Items)
                {
                    ImgProduct imgProduct = new ImgProduct();
                    imgProduct = ImgManager.GetByName(archivoBorrar.Text);
                    ImgManager.Remone(imgProduct);
                    cambios = true;
                }
                if (cambios)
                    ImgManager.Context.SaveChanges();


                //2º Añadir las nuevas imágenes
                cambios = false;
                List<ImgProduct> list = new List<ImgProduct>();
                list = ImgManager.GetByProductId(productSelect.Id).AsEnumerable().ToList();

                foreach (ListItem archivoAdd in LstImagenes.Items)
                {
                    //ImgProduct imgProduct = new ImgProduct();
                    //imgProduct = ImgManager.GetByName(archivoAdd.Text);
                    bool existe = false;
                    foreach (ImgProduct imgP in list)
                    {
                        if (imgP.FileName == archivoAdd.Text)
                        {
                            existe = true;
                            break;
                        }

                    }
                    if (!existe)
                    {
                        ImgProduct NewImgProduct = new ImgProduct();

                        string NombreCopia = DateTime.Now.Year.ToString() + "_" +
                                                DateTime.Now.Month.ToString() + "_" +
                                                DateTime.Now.Day.ToString() + "_" +
                                                DateTime.Now.Hour.ToString() + "_" +
                                                DateTime.Now.Minute.ToString() + "_" +
                                                DateTime.Now.Second.ToString() + "_" +
                                                DateTime.Now.Millisecond.ToString() +
                                                User.Identity.GetUserId() +
                                                Path.GetExtension(archivoAdd.Text);

                        File.Copy(Request.PhysicalApplicationPath + Constants.RUTA_TEMPORAL_SUBIR_IMAGENES_PRODUCTOS + archivoAdd.Text, Request.PhysicalApplicationPath + Constants.DESTINO_IMAGENES_PRODUCTOS + NombreCopia);

                        NewImgProduct.FileName = NombreCopia;
                        NewImgProduct.Product_Id = productSelect.Id;

                        ImgManager.Add(NewImgProduct);

                        cambios = true;
                    }

                }

                if (cambios)
                    ImgManager.Context.SaveChanges();



                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<scritp>alert('El producto se actualizo correctamente.');</script>", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Bienvenido: ');", true);
            }
            Response.Redirect("ProductCreate");


        }
        protected void EliminarProducto_Click(object sender, EventArgs e)
        {
            //Product proDel = new Product();
            //proDel = ProductManager.GetById(int.Parse(ddlProductos.SelectedValue));
            //ProductManager.Remone(proDel);
            ProductManager.Remone(ProductManager.GetById(int.Parse(ddlProductos.SelectedValue)));
            ProductManager.Context.SaveChanges();

        }

        // Evento del botón LimpiarCajas
        protected void btnLimpiarCajas_Click(object sender, EventArgs e)
        {
            limpiarCajas(false);
        }


        // Métodos auxiliares
        private bool ComprobarProducto()
        {
            List<Product> listProductos = new List<Product>();
            listProductos = ProductManager.GetBySectionId(int.Parse(ddlSeccion.SelectedValue)).AsEnumerable().ToList();

            bool Registrada = false;

            for (int i = 0; i < listProductos.Count; i++)
            {
                if (listProductos[i].Name == txtNombre.Text)
                {
                    Label2.Text = "Este producto ya está registrado.";
                    txtNombre.Text = "";
                    Registrada = true;
                    break;
                }
            }

            return Registrada;
        }
        private bool ComprobarProducto(int idProducto)
        {
            List<Product> listProductos = new List<Product>();
            listProductos = ProductManager.GetBySectionId(int.Parse(ddlSeccion.SelectedValue)).AsEnumerable().ToList();

            bool Registrada = false;

            for (int i = 0; i < listProductos.Count; i++)
            {
                if ((listProductos[i].Name == txtNombre.Text) && !(listProductos[i].Id == idProducto))
                {

                    Label2.Text = "Este producto ya está registrado.";
                    txtNombre.Text = "";
                    Registrada = true;
                    break;


                }
            }


            return Registrada;
        }
        private void limpiarCajas(bool habilitarListaProducto)
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";

            LstImagenes.Items.Clear();

            //ddlProductos.Text = "";
            ddlProductos.Enabled = habilitarListaProducto;

            AltaProducto.Enabled = true;
            EditarProducto.Enabled=false;
            EliminarProducto.Enabled = false;
        }
        private void borrarImagenesTMP() 
        {
            
            string[] archivos = Directory.GetFiles(Request.PhysicalApplicationPath + Constants.RUTA_TEMPORAL_SUBIR_IMAGENES_PRODUCTOS);

            foreach (string archivo in archivos)
                if (archivo.Contains(User.Identity.GetUserId()))
                    File.Delete(archivo);


          
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            borrarImagenesTMP();
        }

       
    }
}