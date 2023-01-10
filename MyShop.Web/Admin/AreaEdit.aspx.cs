using MyShop.Application;
using MyShop.CORE;
using MyShop.DAL;
using MyShop.Web.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        List<Area> list = new List<Area>();

        protected void Page_Load(object sender, EventArgs e)
        {
            context = new ApplicationDbContext();
            areaManager = new GenericManager<Area>(context);

            if (!IsPostBack) {
                            
                //List<Area> list = new List<Area>();
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

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            //Creamos un objeto de tipo Area y le asignamos el valor de la propiedad.
            Area area = new Area()
            {
                Description = txtNombre.Text,
            };

            if(!ComprobarArea())
            {
                areaManager.Add(area);
                areaManager.Context.SaveChanges();
                Response.Redirect("AreaEdit");
            }

        }

        

        private bool ComprobarArea()
        {
            bool Registrada = false;

            for (int i=0; i<list.Count; i++)
            {
                if(list[i].Description  == txtNombre .Text)
                {
                    Label2.Text = "Esa área ya está registrada.";
                    txtNombre.Text = "";
                    Registrada = true;
                    break;
                }
            }
            return Registrada;
        }
    }
}