using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsListadosBl
    {
        #region Métodos
        /// <summary>
        /// Funcion que devuelve un listado de misiones según las normas de los Soprano
        /// Pre: Ninguna
        /// Post: El listado devuelto puede ser null
        /// </summary>
        /// <returns>Devuelve un List de tipo ClsMision</returns>
        public static List<ClsMision> obtenerListadoMisionesBl()
        {
            List<ClsMision> listado = ClsListadosDal.obtenerListadoMisionesDal();

            return listado;
        }

        /// <summary>
        /// Funcion que devuelve un listado de candidatos según las normas de los Soprano
        /// Pre: Ninguna
        /// Post: El listado devuelto puede ser null
        /// </summary>
        /// <returns>Devuelve un List de tipo ClsCandidato</returns>
        public static List<ClsCandidato> obtenerListadoCandidatosBl(int idMision)
        {
            List<ClsCandidato> listadoCandidatos = ClsListadosDal.obtenerListadoCandidatosDal(idMision);

            List<ClsMision> listadoMisiones = ClsListadosDal.obtenerListadoMisionesDal();

            List<ClsCandidato> listadoCandidatosFiltrado = new List<ClsCandidato>();

            ClsMision misonSeleccionada = listadoMisiones[idMision - 1];

            bool encontrado = false;

            int i = 0;

            foreach (ClsCandidato cand in listadoCandidatos) 
            { 
                if(misonSeleccionada.Dificultad == 1 || misonSeleccionada.Dificultad == 2)
                {
                    if(cand.Pais == "USA")
                    {
                        listadoCandidatosFiltrado.Add(cand);
                    }
                }
                if(misonSeleccionada.Dificultad == 3)
                {
                    if( cand.Pais == "USA")
                    {
                        if(DateTime.Now.Year - cand.FechaNac.Year >= 40)
                        {
                            listadoCandidatosFiltrado.Add(cand);
                        }
                    }
                }
                if(misonSeleccionada.Dificultad == 4)
                {
                    if (cand.Pais == "Italia")
                    {
                        if (DateTime.Now.Year - cand.FechaNac.Year <= 45)
                        {
                            listadoCandidatosFiltrado.Add(cand);
                        }
                    }
                }
                if (misonSeleccionada.Dificultad == 5)
                {
                    if (cand.Pais == "Italia")
                    {
                        if ((DateTime.Now.Year - cand.FechaNac.Year >= 45) && (DateTime.Now.Year - cand.FechaNac.Year <= 55))
                        {
                            listadoCandidatosFiltrado.Add(cand);
                        }
                    }
                }
            }

            return listadoCandidatosFiltrado;
        }

        /// <summary>
        /// Funcion que devuelve una mision segun su id segun las normas de los Soprano
        /// Pre: El id debe ser mayor a 0
        /// Post: Puede devolver null si el id no está asignado a ninguna mision
        /// </summary>
        /// <param name="id">Número de tipo entero que corresponderá al id de una mision</param>
        /// <returns>Devuelve una mision</returns>
        public static ClsMision buscarMisionPorIdBl(int id)
        {
            ClsMision mision = ClsListadosDal.buscarMisionPorIdDal(id);

            return mision;
        }

        /// <summary>
        /// Funcion que devuelve un candidato segun su id segun las normas de los Soprano
        /// Pre: El id debe ser mayor a 0
        /// Post: Puede devolver null si el id no está asignado a ningun candidato
        /// </summary>
        /// <param name="id">Número de tipo entero que corresponderá al id de un candidato</param>
        /// <returns>Devuelve un candidato</returns>
        public static ClsCandidato buscarCandidatoPorIdBl(int id)
        {
            ClsCandidato candidato = ClsListadosDal.buscarCandidatoPorIdDal(id);

            return candidato;
        }
        #endregion
    }
}
