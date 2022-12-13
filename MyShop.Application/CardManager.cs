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
    /// Manager de Tarjetas
    /// </summary>
    public class CardManager : GenericManager <Card>
    {
        public CardManager (ApplicationDbContext context) : base(context)
            { }

        //Creamos un método que devuelva todas las tarjetas que ha registrado un usario, utilizando el Id de usuario.

        /// <summary>
        /// Método que devuelve todas las tarjetas registradas por un usuario.
        /// </summary>
        /// <param name="userId">Id de usuario.</param>
        /// <returns>Todas las tarjetas que ha registrado el usuario.</returns>
        public IQueryable<Card> GetByUserId(string userId)
        {
            return Context.Cards.Where(e => e.User_Id == userId);
        }


    }
}
