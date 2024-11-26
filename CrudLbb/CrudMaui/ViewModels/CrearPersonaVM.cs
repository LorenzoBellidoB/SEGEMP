using BL;
using EjercicioU10.ViewModels.Utilidades;
using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModels
{
    public class CrearPersonaVM: INotifyPropertyChanged
    {
        #region Atributos
        private ClsPersona persona = new ClsPersona();
        private List<ClsDepartamento> listadoDepartamentos;
        private ClsDepartamento departamentoSeleccionado;
        private DelegateCommand guardarCommand;
        #endregion

        #region Propiedades
        public ClsPersona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        public List<ClsDepartamento> ListadoDepartamentos
        {
            get { return listadoDepartamentos; }
        }
        public ClsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set { departamentoSeleccionado = value; NotifyPropertyChanged("DepartamentoSeleccionado"); }
        }
        public DelegateCommand GuardarCommand
        {
            get { return guardarCommand; }
        }

        #endregion

        #region Constructores
        public CrearPersonaVM()
        {
            persona = new ClsPersona();
            departamentoSeleccionado = new ClsDepartamento();
            listadoDepartamentos = new List<ClsDepartamento>(ClsListadosBl.ListadoCompletoDepartamentosBl());
            guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecute);
        }

        #endregion

        #region Commands

        private async void GuardarCommand_Executed()
        {
            try
            {
                persona.IdDepartamento = departamentoSeleccionado.Id;

                int row = ClsServiciosBl.insertarPersonaBl(persona);
                if (row > 0)
                    {
                        await Shell.Current.GoToAsync("///Personas");
                    }
                else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "No se ha podido insertar la persona", "Aceptar");
                    }       
            }catch (Exception ex)
            {
                //TODO
            }
            
        }
        private bool GuardarCommand_CanExecute()
        {
            bool res = false;

            if(departamentoSeleccionado != null)
            {
                res = true;
            }
            return res;
        }

        #endregion

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
