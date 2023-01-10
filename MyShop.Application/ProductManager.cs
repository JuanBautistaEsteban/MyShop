using MyShop.CORE;
using MyShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application

{
    /// <summary>
    /// Manager de productos
    /// </summary>
    public class ProductManager : GenericManager<Product >
    {
        public ProductManager(ApplicationDbContext context) : base(context)
        { }

        //Creamos un método que devuelva todas los productos  que ha registrado de una sección, utilizando el Id de sección.

        /// <summary>
        /// Método que devuelve todos los producto de una sección.
        /// </summary>
        /// <param name="sectionId">Id de la sección.</param>
        /// <returns>Todos los productos de una sección.</returns>
        public IQueryable<Product> GetBySectionId(int sectionId)
        {
            return Context.Products .Where(e => e.Section_Id  == sectionId);
        }

        public Product GetByName(string nombre)
        {
            return Context.Products .First(e => e.Name == nombre);
        }
    }
}
