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

        private List<ClsPersona> listadoPersonas = new List<ClsPersona>();
        #endregion

        #region Propiedades
        public String Estado { get { return estado; } set { estado = value;} }

        public String EstadoDesc { get { return estado; } set { estado = value; } }


        public DelegateCommand ConectarCommand
        {
            get { return conectarCommand; }
            set { conectarCommand = value; }
        }

        public DelegateCommand DesconectarCommand
        {
            get { return desconectarCommand; }
            set { desconectarCommand = value; }
        }

        public List<ClsPersona> ListadoPersonas
        {
            get
            {
                listadoPersonas = ListadoDal.ListadoCompletoDal();

                return listadoPersonas;
            }
        }
        #endregion

        #region Contructores

        public ConexionVM() 
        {
            ConectarCommand = new DelegateCommand(ConectarCommand_Executed, ConectarCommand_CanExecute);
            DesconectarCommand = new DelegateCommand(DesconectarCommand_Executed, DesconectarCommand_CanExecute);
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

            }
            catch (Exception ex)
            {
                estado = "Error";
            }
            finally
            {
                conexion.Close();
                NotifyPropertyChanged("Estado");
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

            }
            catch (Exception ex)
            {
                estado = "Error";
            }
            finally
            {
                conexion.Close();
                NotifyPropertyChanged("Estado");
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
