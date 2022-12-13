using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.CORE
{
    /// <summary>
    /// Entidad de dominio Áreas
    /// </summary>
    public class Area

    {
        /// <summary>
        /// Identificador del Área
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripción del Área
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Listado de secciones de cada área.
        /// </summary>
        public virtual List<Section > Sections { get; set; }

    }
}
