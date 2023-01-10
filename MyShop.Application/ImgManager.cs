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
    /// Manager de imágenes de productos
    /// </summary>
    public class ImgManager : GenericManager <ImgProduct >
    {
        public ImgManager(ApplicationDbContext context) : base(context)
        { }

        //Creamos un método que devuelva todas las imágenes que ha registrado de un producto, utilizando el Id del producto.

        /// <summary>
        /// Método que devuelve todas las imágenes registradas de un producto.
        /// </summary>
        /// <param name="productId">Id del producto.</param>
        /// <returns>Todas las imágenes que ha registrado del producto.</returns>
        public IQueryable<ImgProduct> GetByProductId(int productId)
        {
            return Context.ImgProducts .Where(e => e.Product_Id  == productId);
        }
    }
}
