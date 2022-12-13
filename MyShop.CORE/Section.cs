using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.CORE
{
    /// <summary>
    /// Entidad de dominio Secciones
    /// </summary>
    public class Section
    {
        /// <summary>
        /// Identificador de la sección.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la sección.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Área a la que pertence la sección
        /// </summary>
        public Area Id_Area { get; set; }

        /// <summary>
        /// Identificador del área al que pertenece la sección
        /// </summary>

        [ForeignKey("Id_Area")]
        public int Area_Id { get; set; }
    }
}
