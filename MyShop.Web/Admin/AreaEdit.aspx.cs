using MyShop.Application;
using MyShop.CORE;
using MyShop.DAL;
using MyShop.Web.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop.Web.Admin
{
    public partial class AreaEdit : System.Web.UI.Page
    {
        // Ahora creamos un contexto de base de datos, que se lo pasaremos al constructor del GenericManager<Area>
        ApplicationDbContext context = null;
        GenericManager<Area> areaManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            context = new ApplicationDbContext();
            areaManager = new GenericManager<Area>(context);

            if (!IsPostBack) {
                            
                List<Area> list = new List<Area>();
                list = areaManager.GetAll().AsEnumerable().ToList();

                ddlAreas.DataSource = list;
                ddlAreas.DataTextField = "Description";
                ddlAreas.DataValueField = "Id";
                ddlAreas.DataBind();

                ddlAreas.SelectedIndex = 0;

            }
            

        }

        //public IQueryable <Area > GetAll()
        //{
            
        //    return areaManager.GetAll();
           

        //}

        

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Request.Form["confirm_value"] == "Yes")
            {
                Area areaborrada = areaManager.Remone(areaManager.GetById(int.Parse(ddlAreas.SelectedValue)));
                
                areaManager.Context.SaveChanges();
                Response.Redirect("AreaEdit");
            }
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty (txtNombre.Text))
            {
                Area area = areaManager.GetById(int.Parse(ddlAreas.SelectedValue));
                area.Description = txtNombre.Text;
                areaManager.Context.SaveChanges();
                Response.Redirect("AreaEdit");
            }
            
        }

        //private void datosSeleccionados()
        //{
            
        //    Label4.Text = ddlAreas.SelectedValue;
        //    Label5.Text = ddlAreas.SelectedItem.Text;
        //    txtId .Value = ddlAreas.SelectedValue;
        //    txtDescripcion .Value = ddlAreas.SelectedItem.Text;
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string confirmValue = Request.Form["confirm_value"];
        //    if (confirmValue == "Yes")
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
        //    }
        //    else
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
        //    }
        //}
    }
}