using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsListadoCochesDal
    {
        public static List<ClsMarca> ObtenerMarcasDal()
        {
            List<ClsMarca> listadoMarcas = new List<ClsMarca>();

            listadoMarcas.Add(new ClsMarca(1, "Audi"));
            listadoMarcas.Add(new ClsMarca(2, "Mercedes"));
            listadoMarcas.Add(new ClsMarca(3, "Peugeot"));
            listadoMarcas.Add(new ClsMarca(4, "Renault"));
            listadoMarcas.Add(new ClsMarca(5, "Seat"));

            return listadoMarcas;
        }

        public static List<ClsModelo> ObtenerModelosDal(int idMarca) {
            
            List<ClsModelo> listadoModelos = new List<ClsModelo>();

            listadoModelos.Add(new ClsModelo(1, "A1", 1));
            listadoModelos.Add(new ClsModelo(2, "A3", 1));
            listadoModelos.Add(new ClsModelo(3, "A4", 1));
            listadoModelos.Add(new ClsModelo(4, "Q5", 1));
            listadoModelos.Add(new ClsModelo(5, "Benz", 2));
            listadoModelos.Add(new ClsModelo(6, "Vito", 2)); 

            for (int i = 0; i < listadoModelos.Count; i++)
            {
                if (listadoModelos[i].IdMarca != idMarca)
                {
                    listadoModelos.RemoveAt(i);
                    i--;
                }
            }


            return listadoModelos;        
        }

    }
}
