using MyShop.CORE;
using MyShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application
{
    public class SectionManager : GenericManager <Section>
    {
        public SectionManager(ApplicationDbContext context) : base(context)
        { }

        // Creamos un método que devuelva todas las secciones de un Área en concreto

        /// <summary>
        /// Mérodo que devuelve todas las secciones registradas relacionadas con un Área.
        /// </summary>
        /// <param name="Area_Id">Identificador del Área</param>
        /// <returns>Todas las secciones de ese Área</returns>
        public IQueryable <Section > GetByAreaId(int Area_Id)
        {
            return Context.Sections .Where (e=> e.Area_Id == Area_Id);
        }
    }
}
