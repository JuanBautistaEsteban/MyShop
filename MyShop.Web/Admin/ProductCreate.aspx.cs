using MyShop.Application;
using MyShop.CORE;
using MyShop.DAL;
using MyShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        string RutaTemporal =  @"\img\tmp\";

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
                    limpiarCajas();
            }

            if (IsPostBack)
            {
                //Label7.Text = ddlType.SelectedValue;
                //Label9.Text = ddlSeccion.SelectedValue;
                //Label11.Text = ddlProductos.SelectedValue;

            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSecciones();
            CargarProductos();
            if(ddlProductos .Items.Count > 0)
                MostrarDatosProducto();
            else
                limpiarCajas();
        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProductos();
            if (ddlProductos.Items.Count > 0)
                MostrarDatosProducto();
            else
                limpiarCajas();
        }

        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosProducto();
        }

        protected void btnLimpiarCajas_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(FileUpload1 .HasFile)
            {
                

                //string nombre = System.IO.Path.GetFullPath(FileUpload1.FileName);
                RutaTemporal = Request.PhysicalApplicationPath + RutaTemporal ;
                RutaTemporal += FileUpload1.FileName;
                FileUpload1.SaveAs(RutaTemporal);
                LstImagenes.Items.Add(FileUpload1.FileName);
                Label7.Text = ddlType.SelectedValue;
            }
        }

        

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                nuevoProducto = ProductManager.GetByName (product.Name);
                nuevoId = nuevoProducto.Id;

                //Response.Redirect("ProductCreate");
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
                                     Path.GetExtension(fichero.Text);

                File.Copy(Request.PhysicalApplicationPath + RutaTemporal + fichero.Text , Request.PhysicalApplicationPath + @"\img\products\" + NombreCopia);
                imgProduct .FileName = NombreCopia;
                imgProduct.Product_Id = nuevoId;

                ImgManager .Add (imgProduct);
                ImgManager.Context.SaveChanges();

               
            }
            Response.Redirect("ProductCreate");
        }

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
            list=ProductManager.GetBySectionId(int.Parse(ddlSeccion.SelectedValue)).AsEnumerable().ToList();

            ddlProductos.DataSource = list;
            ddlProductos.DataTextField = "Name";
            ddlProductos .DataValueField = "Id";
            ddlProductos.DataBind();
        }

        private void MostrarDatosProducto()
        {
            Product product = new Product();
            product = ProductManager .GetById(int.Parse (ddlProductos.SelectedValue));

            txtNombre.Text = product.Name;
            txtDescripcion.Text = product.Description;
            txtPrecio.Text = product.Price.ToString() ;
            txtStock .Text = product.Stock.ToString() ;

            List<ImgProduct > list = new List<ImgProduct>();
            list = ImgManager.GetByProductId(product.Id).AsEnumerable ().ToList ();

            LstImagenes.DataSource = list;
            LstImagenes.DataTextField = "FileName";
            LstImagenes.DataBind();
        }

        private void limpiarCajas()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        protected void LstImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rutaCargar= Request.PhysicalApplicationPath + @"\img\products\" + LstImagenes.SelectedValue;
            Image1.ImageUrl = rutaCargar;
        }
    }
}