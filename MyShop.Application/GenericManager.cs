using MyShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application
{
    /// <summary>
    /// Clase genérica para el resto de los manager específicos de cada entidad.
    /// </summary>
    /// <typeparam name="T">Entidad</typeparam>
    public class GenericManager<T>
        where T : class

    {
        /// <summary>
        /// Propiedad que almacenará el contexto de datos. Se podrá consultar desde cualquier parte de la aplicación, pero solo se podrá
        /// asignar valor desde aquí.
        /// </summary>
        public ApplicationDbContext Context { get; private set; }

        /// <summary>
        /// Constructor de la clase GenericManager.
        /// </summary>
        /// <param name="context">Contexto de datos.</param>
        public GenericManager(ApplicationDbContext context)
        {
            Context = context;
        }   

        /// <summary>
        /// Añade una entidad del contexto de datos.
        /// </summary>
        /// <param name="entidad">Entidad a añadir.</param>
        /// <returns>Entidad añadida.</returns>
        public T Add(T entidad)
        {
            return Context .Set<T>().Add(entidad);
        }

        /// <summary>
        /// Borra una entidad del contexto de datos.
        /// </summary>
        /// <param name="entidad">Entidad a borrar</param>
        /// <returns>Entidad borrada.</returns>
        public T Remone(T entidad)
        {
            return Context.Set<T>().Remove(entidad);
        }

        /// <summary>
        /// Obtiene una entidad por sus posibles claves.
        /// </summary>
        /// <param name="claves">Claves del objeto.</param>
        /// <returns>Entidad si es encontrada</returns>
        public T GetById(object[] claves)
        {
            // El método find busca la entidad utilizando todas las posibles claves que tenga la tabla
            return Context.Set<T>().Find(claves);
        }

        //Vamos a sobreescribie el método GetById pero usando solo una clave int
        /// <summary>
        /// Obtiene una entidad por su clave Id
        /// </summary>
        /// <param name="Id">Identificador</param>
        /// <returns>Entidad si es encontrada</returns>
        public T GetById(int Id)
        {
            // Llamamos al método GetById que tiene la busqueda. Como hay que pasarle un array de objetos
            // creamos uno nuevo con el Id como único elemento, con lo que realizará la busqueda con 
            // solo esa clave.
            return GetById(new object[] { Id });
        }

        // Sobreescribimos el método GetById pero usando solo una clave string
        /// <summary>
        /// Obtener una entidad por su clave Id
        /// </summary>
        /// <param name="Id">Identificador</param>
        /// <returns>Entidad si es encontrada</returns>
        public T GetById(string Id)
        {
            // En este caso en lugar de llamar al primer método GetById, llamamos directamente al método
            // find del contexto de datos y le pasamos un nuevo array de object con el Id como único
            // elemento.
            return (T)Context.Set<T>().Find(new object[] { Id });
        }

        /// <summary>
        /// Obtiene todas la entidades de un tipo especificas
        /// </summary>
        /// <returns>Lista de todas esas entidades (por ejemplo incidencias)</returns>
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

    }
}
