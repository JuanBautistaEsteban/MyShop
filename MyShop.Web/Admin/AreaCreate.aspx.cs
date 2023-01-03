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
    public partial class AreaCreate : System.Web.UI.Page
    {
        // Creamos un manager generico
        GenericManager <Area> AreaManager = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            //Creamos el contexto de la BBDD, que se lo pasaremos al constructor del manager definido
            ApplicationDbContext context = new ApplicationDbContext();
            AreaManager = new GenericManager<Area> (context);

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Creamos un objeto de tipo Area y le asignamos el valor de la propiedad.
            Area area = new Area()
            {
                Description = txtNombreArea.Text,
            };

            //Vamos a comprobar que este registro no este ya almacenado

            List<Area> ListAreas = new List<Area>();
            ListAreas = AreaManager.GetAll().AsEnumerable().ToList();

            bool registrada = false;

            for(int i = 0; i < ListAreas.Count; i++)
            {
                if (ListAreas[i].Description == txtNombreArea.Text)
                {
                    Label2.Text = "Esa área ya está registrada.";
                    txtNombreArea.Text = "";
                    registrada = true;
                    break;

                }
            }

            if (!registrada)
            {
                AreaManager.Add(area);
                AreaManager.Context.SaveChanges();
                Response.Redirect("AreaCreate");
            }
            
        }
    }
}