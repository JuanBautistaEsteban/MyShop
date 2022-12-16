using Microsoft.AspNet.Identity.EntityFramework;
using MyShop.CORE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Añadimos las listas persistentes de la base de datos

        /// <summary>
        /// Colección persistente de Tarjetas
        /// </summary>
        public DbSet <Card> Cards { get; set; }

        /// <summary>
        /// Colección persistente de Direcciones
        /// </summary>
        public DbSet<Home> Homes { get; set; }

        /// <summary>
        /// Colección persistente de Áreas.
        /// </summary>
        public DbSet <Area> Areas { get; set; }

        /// <summary>
        /// Colección persistente de Secciones
        /// </summary>
        public DbSet <Section> Sections { get; set; }

        /// <summary>
        /// Colección persistente de Productos
        /// </summary>
        public DbSet <Product> Products { get; set; }

        /// <summary>
        /// Colección persistente de Imagenes de Productos.
        /// </summary>
        public DbSet <ImgProduct> ImgProducts { get; set; }



    }
}
