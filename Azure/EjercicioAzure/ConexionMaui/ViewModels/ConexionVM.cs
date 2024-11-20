using ConexionMaui.ViewModels.Utilidades;
using DAL;
using DAL.Conexion;
using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConexionMaui.ViewModels
{
    public class ConexionVM: INotifyPropertyChanged
    {
        #region Atributos
        private string estado = "";

        private string estadoDesc = "";

        private DelegateCommand conectarCommand;

        private DelegateCommand desconectarCommand;

        private List<ClsPersona> listadoPersonas;
        #endregion

        #region Propiedades
        public String Estado { get { return estado; }  }

        public String EstadoDesc { get { return estado; }  }


        public DelegateCommand ConectarCommand
        {
            get { return conectarCommand; }
        }

        public DelegateCommand DesconectarCommand
        {
            get { return desconectarCommand; }
        }

        public List<ClsPersona> ListadoPersonas
        {
            get
            {
                return listadoPersonas;
            }
        }
        #endregion

        #region Contructores

        public ConexionVM() 
        {
            conectarCommand = new DelegateCommand(ConectarCommand_Executed, ConectarCommand_CanExecute);
            desconectarCommand = new DelegateCommand(DesconectarCommand_Executed, DesconectarCommand_CanExecute);
        }
        #endregion

        #region Commands
        private async void ConectarCommand_Executed()
        {
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = ClsConexion.ObtenerConexion();
                estado = "Conexion exitosa";
                listadoPersonas = ListadoDal.ListadoCompletoDal();
            }
            catch (Exception ex)
            {
                estado = "Error";
            }
            finally
            {
                conexion.Close();
                NotifyPropertyChanged("Estado");
                NotifyPropertyChanged("ListadoPersonas");
            }
            
        }

        private bool ConectarCommand_CanExecute()
        {
            bool sePuedeConectar = true;


            return sePuedeConectar;
        }

        private async void DesconectarCommand_Executed()
        {
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion = ClsConexion.Desconectar();
                estado = "Conexion cerrada";
                listadoPersonas = null;

            }
            catch (Exception ex)
            {
                estado = "Error";
            }
            finally
            {
                conexion.Close();
                NotifyPropertyChanged("Estado");
                NotifyPropertyChanged("ListadoPersonas");
            }

        }

        private bool DesconectarCommand_CanExecute()
        {
            bool sePuedeConectar = true;


            return sePuedeConectar;
        }
        #endregion

        #region Notify
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }


}
