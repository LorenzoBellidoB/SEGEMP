using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClsListadoCochesBl
    {
        public static List<ClsMarca> ObtenerMarcasBl()
        {
            List<ClsMarca> listadoMarcas = new List<ClsMarca>();

            listadoMarcas = ClsListadoCochesDal.ObtenerMarcasDal();

            return listadoMarcas;
        }

        public static List<ClsModelo> ObtenerModelosBl()
        {
            List<ClsModelo> listadoModelos = new List<ClsModelo>();

            listadoModelos = ClsListadoCochesDal.ObtenerModelosDal();

            return listadoModelos;
        }
    }
}
