using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.CORE
{

    /// <summary>
    /// Entidad de dominio Domicilios
    /// </summary>
    public class Home
    {
        /// <summary>
        /// Identificador de cada domilicio
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Dirección del usuario
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Localidad
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Provincia
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Código Postal
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// País
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Usuario de la dirección
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Identificador del usuario de la dirección
        /// </summary>

        [ForeignKey("User")]
        public string User_Id { get; set; }
    }
}
