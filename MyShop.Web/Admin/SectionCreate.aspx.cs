using MyShop.Application;
using MyShop.CORE;
using MyShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShop.Web.Admin
{
    public partial class SectionCreate : System.Web.UI.Page
    {
        // Creamos un manager generico para recuperar las Áreas que estén registradas
        GenericManager<Area> AreaManager = null;

        // Creamos un manager genérico para almacenar la sección
        SectionManager  SectionManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationDbContext contextDB = new ApplicationDbContext();

            AreaManager = new GenericManager<Area>(contextDB);
            SectionManager = new SectionManager (contextDB);

            if (!IsPostBack)
            {
                List<Area> list = new List<Area>();
                list = AreaManager.GetAll().AsEnumerable().ToList();

                ddlType.DataSource = list;
                ddlType.DataTextField = "Description";
                ddlType.DataValueField = "Id";
                ddlType.DataBind();

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Section section = new Section()
            {
                Name = txtNombre.Text,
                Area_Id = int.Parse(ddlType.SelectedValue)
            };

            //Vamos a comprobar que este registro no este ya almacenado

            List<Section> ListSections = new List<Section>();
            ListSections = SectionManager.GetByAreaId(int.Parse(ddlType.SelectedValue)).AsEnumerable().ToList();

            bool Registrada = false;

            for(int i = 0; i < ListSections.Count; i++)
            {
                if(ListSections[i].Name == txtNombre.Text)
                {
                    Label2.Text = "Esa sección ya está registrada.";
                    txtNombre.Text = "";
                    Registrada = true;
                    break;
                }
            }

            if (!Registrada)
            {
                SectionManager.Add(section);
                SectionManager.Context.SaveChanges();
                Response.Redirect("SectionCreate");
            }
           

        }
    }
}