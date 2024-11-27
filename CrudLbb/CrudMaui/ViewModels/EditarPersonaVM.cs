using BL;
using CrudMaui.Models;
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
    [QueryProperty(nameof(PersonaEditada), "Persona")]
    public class EditarPersonaVM : INotifyPropertyChanged
    {
        #region Atributos
        private PersonaDept personaEditada;
        private List<ClsDepartamento> listadoDepartamentos;
        private ClsDepartamento departamentoSeleccionado;
        private DelegateCommand guardarCommand;
        #endregion

        #region Propiedades
        public PersonaDept PersonaEditada
        {
            get { return personaEditada; }
            set
            {
                personaEditada = value;
                NotifyPropertyChanged("PersonaEditada");
            }
        }

        public List<ClsDepartamento> ListadoDepartamentos 
        { 
            get { return listadoDepartamentos; } 
        }
        public ClsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set { departamentoSeleccionado = value; NotifyPropertyChanged("DepartamentoSeleccionado");}
        }

        public DelegateCommand GuardarCommand
        {
            get { return guardarCommand; }
        }
        #endregion

        #region Constructor
        public EditarPersonaVM()
        {
            departamentoSeleccionado = new ClsDepartamento();
            listadoDepartamentos = new List<ClsDepartamento>(ClsListadosBl.ListadoCompletoDepartamentosBl());
            guardarCommand = new DelegateCommand(guardarCommand_Executed, guardarCommand_CanExecute);
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

        #region Commands

        private async void guardarCommand_Executed()
        {
            if (departamentoSeleccionado.Id != 0)
            {
                personaEditada.IdDepartamento = departamentoSeleccionado.Id;
            }
            else
            {
                personaEditada.IdDepartamento = PersonaEditada.IdDepartamento;
            }
            

            int row = ClsServiciosBl.updatePersonaBl(personaEditada);

            if (row > 0)
            {
                await Shell.Current.GoToAsync("///Personas");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se ha podido insertar la persona", "Aceptar");
            }
        }

        private bool guardarCommand_CanExecute()
        {
            bool res = false;

            if (departamentoSeleccionado != null || PersonaEditada.IdDepartamento != 0)
            {
                res = true;
            }

            return res;
        }

        #endregion
    }
}
