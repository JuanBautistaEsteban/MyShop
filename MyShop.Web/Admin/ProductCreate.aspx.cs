using MyShop.Application;
using MyShop.CORE;
using MyShop.DAL;
using MyShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop.Web.Admin
{
    public partial class ProductCreate : System.Web.UI.Page
    {
        // Creamos un manager generico
        GenericManager<Area> AreaManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationDbContext contextDB = new ApplicationDbContext();
            AreaManager = new GenericManager<Area>(contextDB);


            if (!IsPostBack)
            {
                List<Area> list = new List<Area>();
                list = AreaManager.GetAll().AsEnumerable().ToList();

                ddlType.DataSource = list;
                ddlType.DataTextField = "Description";
                ddlType.DataValueField = "Id";
                ddlType.DataBind();

            }

            



           

            if (IsPostBack)
            {
                Label7.Text = ddlType.SelectedValue  ;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(FileUpload1 .HasFile)
            {
                string nombre = System.IO.Path.GetFullPath(FileUpload1.FileName);
                ListBox1.Items.Add(nombre);
                Label7.Text = ddlType.SelectedValue;
            }
        }

        protected void ddlType_TextChanged(object sender, EventArgs e)
        {
            Label7.Text=ddlType.Text;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            //Product product = new Product()
            //{
            //    Name = txtNombre.Text,
            //    Description = txtDescripcion.Text,
            //    Price = double.Parse (txtPrecio.Text),
            //    Stock=int.Parse (txtStock.Text),
            //    Section_Id

            //}

        }
    }
}