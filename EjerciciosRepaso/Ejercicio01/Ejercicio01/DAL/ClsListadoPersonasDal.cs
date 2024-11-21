using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsListadoPersonasDal
    {
        private static List<ClsPersona> listadoPersonas = new List<ClsPersona>()
        {
            new ClsPersona() { Id = 1, Nombre = "Pepe", Apellido = "Perez", FechaNacimiento = DateTime.Parse("01/01/2010") },
            new ClsPersona() { Id = 2, Nombre = "Juan", Apellido = "Gomez", FechaNacimiento = DateTime.Parse("01/01/2005") },
            new ClsPersona() { Id = 3, Nombre = "Paco", Apellido = "Garcia", FechaNacimiento = DateTime.Parse("03/11/2003") },
            new ClsPersona() { Id = 4, Nombre = "Pedro", Apellido = "Gomez", FechaNacimiento = DateTime.Parse("01/01/2000") }
        };
        
        /// <summary>
        /// Obtiene el listado de personas completas
        /// Pre: Ninguna
        /// Post: El listado puede ser nulo
        /// </summary>
        /// <returns>Devuelve un listado de personas</returns>
        public static List<ClsPersona> obtenerPersonasDal()
        {
            return listadoPersonas;
        }

    }
}
