using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.CORE
{
    /// <summary>
    /// Entidad de dominio Tarjeta de Pago
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Identificador de la tarjeta
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Número de la tarjeta
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Fecha de caducidad de la tarjeta
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Código de seguridad de la tarjeta
        /// </summary>
        public int Ccv { get; set; }

        /// <summary>
        /// Usuario dueño de la tarjeta
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Identificador del usuario dueño de la tarjeta
        /// </summary>

        [ForeignKey ("User")]
        public string User_Id { get; set; }

    }
}
