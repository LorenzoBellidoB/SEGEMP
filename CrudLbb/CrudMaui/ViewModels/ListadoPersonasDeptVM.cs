using BL;
using CrudMaui.Models;
using DAL;
using EjercicioU10.ViewModels.Utilidades;
using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrudMaui.ViewModels
{
    public class ListadoPersonasDeptVM: INotifyPropertyChanged
    {
        #region Atributos
        private PersonaDept personaSeleccionada;
        private List<ClsPersona> listadoPersonas;
        private List<PersonaDept> listadoPersonasDept;
        private DelegateCommand crearCommand;
        private DelegateCommand refrescarCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;

        #endregion

        #region Propiedades
        public PersonaDept PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set {crearCommand.RaiseCanExecuteChanged(); eliminarCommand.RaiseCanExecuteChanged(); editarCommand.RaiseCanExecuteChanged(); NotifyPropertyChanged("PersonaSeleccionada"); personaSeleccionada = value; }
        }

        public List<PersonaDept> ListadoPersonasDept 
        { 
            get { return listadoPersonasDept; } 
        }

        public List<ClsPersona> ListadoPersonas
        {
            get { return listadoPersonas; }
        }

        public DelegateCommand CrearCommand
        {
            get { return crearCommand; }
        }

        public DelegateCommand EliminarCommand
        {
            get { return eliminarCommand; }
        }

        public DelegateCommand EditarCommand
        {
            get { return editarCommand; }
        }

        public DelegateCommand RefrescarCommand
        {
            get { return refrescarCommand; }
        }
        #endregion

        #region Constructores
        public ListadoPersonasDeptVM()
        {
            refresh();
            crearCommand = new DelegateCommand(crearCommand_Executed, crearCommand_CanExecute);
            eliminarCommand = new DelegateCommand(eliminarCommand_Executed, eliminarCommand_CanExecute);
            editarCommand = new DelegateCommand(editarCommand_Executed, editarCommand_CanExecute);
            refrescarCommand = new DelegateCommand(refresh);
        }

        #endregion

        #region Metodos
        public void refresh()
        {
            // se llena la lista (List) con la lista completa de la BL
            listadoPersonas = ClsListadosBl.ListadoCompletoPersonasBl();
            listadoPersonasDept = new List<PersonaDept>();
            // se crea una lista de departamentos
            List<ClsDepartamento> listaDept = ClsListadosBl.ListadoCompletoDepartamentosBl();

            foreach (ClsPersona persona in listadoPersonas)
            {
                PersonaDept personaNombreDept = new PersonaDept(persona, listaDept);
                listadoPersonasDept.Add(personaNombreDept);
            }
            NotifyPropertyChanged(nameof(ListadoPersonasDept));
        }
        #endregion

        #region Command
        private async void crearCommand_Executed()
        {
            await Shell.Current.GoToAsync("///CrearPersona");
        }

        private bool crearCommand_CanExecute()
        {
            bool res = true;

            return res;
        }

        private async void eliminarCommand_Executed()
        {
            // Muestra una confirmación antes de eliminar
            bool confirmacion = await Application.Current.MainPage.DisplayAlert("Confirmar eliminación", "¿Estás seguro de que quieres eliminar a " + personaSeleccionada.Nombre + " " + PersonaSeleccionada.Apellidos + "?", "Sí", "No");

            if (confirmacion)
            {
                listadoPersonas.Remove(personaSeleccionada);
                ClsServiciosBl.deletePersonaBl(personaSeleccionada.Id);
                personaSeleccionada = null;
                refresh();
            }
        }

        private bool eliminarCommand_CanExecute()
        {
            bool res = false;

            if (PersonaSeleccionada != null)
            {
                res = true;
            }

            return res;
        }

        private async void editarCommand_Executed()
        {
            Dictionary<string, object> diccionarioMandar = new Dictionary<string, object>();

            diccionarioMandar.Add("Persona", PersonaSeleccionada);

            await Shell.Current.GoToAsync("///EditarPersona", diccionarioMandar);
        }

        private bool editarCommand_CanExecute()
        {
            bool res = false;

            if(personaSeleccionada != null)
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
