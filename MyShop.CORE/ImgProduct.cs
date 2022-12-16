using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.CORE
{
    /// <summary>
    /// Entidad de dominio Imagenes de Productos
    /// </summary>
    public class ImgProduct
    {
        /// <summary>
        /// Identificador de la imágen
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del fichero
        /// </summary>
        public string FileName { get; set; }   

        /// <summary>
        /// Producto al que representa la imagen
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Identificador del producto al que representa la imagen.
        /// </summary>
        [ForeignKey ("Product")]
        public int Product_Id { get; set; }

    }
}
