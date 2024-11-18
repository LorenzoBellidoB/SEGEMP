using ConexionMaui.ViewModels.Utilidades;
using DAL.Conexion;
using ENT;
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
        private string estado = "";

        private string estadoDesc = "";

        private DelegateCommand conectarCommand;

        public String Estado { get { return estado; } set { estado = value;} }

        public String EstadoDesc { get { return estado; } set { estado = value; } }


        public DelegateCommand ConectarCommand
        {
            get { return conectarCommand; }
            set { conectarCommand = value; }
        }

        public ConexionVM() 
        {
            ConectarCommand = new DelegateCommand(ConectarCommand_Executed, ConectarCommand_CanExecute);
        }

        private async void ConectarCommand_Executed()
        {
            Conexion conexion = new Conexion();

            try
            {
                conexion.ObtenerConexion();
                estado = "Conexion exitosa";

            }
            catch (Exception ex)
            {
                estado = "Error";
            }
            finally
            {
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
            Conexion conexion = new Conexion();

            try
            {
                conexion.ObtenerConexion();
                estado = "Conexion exitosa";

            }
            catch (Exception ex)
            {
                estado = "Error";
            }
            finally
            {
                NotifyPropertyChanged("Estado");
            }

        }

        private bool DesconectarCommand_CanExecute()
        {
            bool sePuedeConectar = true;


            return sePuedeConectar;
        }



        #region Notify
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }


}
