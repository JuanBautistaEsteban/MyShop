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

                CargarSecciones();
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

            //List<Section> ListSections = new List<Section>();
            //ListSections = SectionManager.GetByAreaId(int.Parse(ddlType.SelectedValue)).AsEnumerable().ToList();

            //bool Registrada = false;

            //for(int i = 0; i < ListSections.Count; i++)
            //{
            //    if(ListSections[i].Name == txtNombre.Text)
            //    {
            //        Label2.Text = "Esa sección ya está registrada.";
            //        txtNombre.Text = "";
            //        Registrada = true;
            //        break;
            //    }
            //}



            if (!comprobarRegistro())
            {
                SectionManager.Add(section);
                SectionManager.Context.SaveChanges();
                Response.Redirect("SectionCreate");
            }
        }

        public IQueryable <Section > GetAreaSections()
        {
            return SectionManager.GetByAreaId(int.Parse(ddlType.SelectedValue));
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargarSecciones();

        }

       

        protected void lstBoxSeccionesCreadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label5.Text = lstBoxSeccionesCreadas.SelectedValue;
            Label6.Text = lstBoxSeccionesCreadas.SelectedItem.Text;
            lstBoxSeccionesCreadas.Focus(); 
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (lstBoxSeccionesCreadas.SelectedIndex == -1)
                Label6.Text = "No hay ningún elemento seleccionado";
            else
            {
                Section section = SectionManager.GetById(int.Parse(lstBoxSeccionesCreadas.SelectedValue));
                section.Name = txtNombre.Text;
                SectionManager.Context.SaveChanges();
                Response.Redirect("SectionCreate");
            }
        }


        private void CargarSecciones()
        {
            lstBoxSeccionesCreadas.Items.Clear();

            List<Section> list = new List<Section>();
            list = SectionManager.GetByAreaId(int.Parse(ddlType.SelectedValue)).AsEnumerable().ToList();

            lstBoxSeccionesCreadas.DataSource = list;
            lstBoxSeccionesCreadas.DataTextField = "Name";
            lstBoxSeccionesCreadas.DataValueField = "Id";
            lstBoxSeccionesCreadas.DataBind();
        }


        private bool comprobarRegistro()
        {
            List<Section> ListSections = new List<Section>();
            ListSections = SectionManager.GetByAreaId(int.Parse(ddlType.SelectedValue)).AsEnumerable().ToList();

            bool Registrada = false;

            for (int i = 0; i < ListSections.Count; i++)
            {
                if (ListSections[i].Name == txtNombre.Text)
                {
                    Label2.Text = "Esa sección ya está registrada.";
                    txtNombre.Text = "";
                    Registrada = true;
                    break;
                }
            }

            return Registrada;
        }
    }
}