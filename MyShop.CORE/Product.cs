using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.CORE
{

    /// <summary>
    /// Entidad de dominio Productos
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Denominación del producto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripción del produto
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Precio de venta
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Stock del producto en el almacén
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Sección del producto
        /// </summary>
        public Section section { get; set; }

        /// <summary>
        /// Identificar de la seccion del producto
        /// </summary>

        [ForeignKey ("section")]
        public int Section_Id { get; set; }

    }
}
