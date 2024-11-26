using BL;
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
    /*public class ListadoPersonasVM: INotifyPropertyChanged
    {
        #region Atributos
        private List<ClsPersona> listadoPersonas = new List<ClsPersona>();
        private DelegateCommand eliminarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand refrescarCommand;
        private ClsPersona personaSeleccionada;
        #endregion

        #region Propiedades
        public List<ClsPersona> ListadoPersonas
        {
            get
            {
                return listadoPersonas;
            }
        }

        public DelegateCommand EliminarCommand
        {
            get
            {
                return eliminarCommand;
            }
        }

  
        public DelegateCommand EditarCommand
        {
            get
            {
                return editarCommand;
            }
        }

        public DelegateCommand RefrescarCommand
        {
            get
            {
                return refrescarCommand;
            }
        }

        public ClsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set { personaSeleccionada = value; eliminarCommand.RaiseCanExecuteChanged(); editarCommand.RaiseCanExecuteChanged(); refrescarCommand.RaiseCanExecuteChanged(); NotifyPropertyChanged("PersonaSeleccionada"); }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ListadoPersonasVM()
        {
            try
            {
                // Inicializa la lista de personas obtenida del negocio
                listadoPersonas = new List<ClsPersona>(ClsListadosBl.ListadoCompletoPersonasBl());

                // Inicializa los comandos
                eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
                editarCommand = new DelegateCommand(EditarCommand_Executed, EditarCommand_CanExecute);
                refrescarCommand = new DelegateCommand(RefrescarCommand_Executed, RefrescarCommand_CanExecute);
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                ex.Message.ToString();
            }
        }

        /// <summary>
        /// Constructor con parámetro de persona seleccionada
        /// </summary>
        /// <param name="personaSeleccionada">Persona seleccionada</param>
        public ListadoPersonasVM(ClsPersona personaSeleccionada)
        {
            try
            {
                // Inicializa la lista de personas obtenida del negocio
                listadoPersonas = new List<ClsPersona>(ClsListadosBl.ListadoCompletoPersonasBl());
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                ex.Message.ToString();
            }
        }
        #endregion

        #region Notify
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Notifica el cambio de una propiedad
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Métodos
        private async void EditarCommand_Executed()
        {
            Dictionary<string, object> diccionarioMandar = new Dictionary<string, object>();

            diccionarioMandar.Add("Persona", PersonaSeleccionada);

            await Shell.Current.GoToAsync("///EditarPersona", diccionarioMandar);
        }

        private bool EditarCommand_CanExecute()
        {
            bool res = false;

            if(personaSeleccionada != null)
            {
                res = true;
            }

            return res;
        }

        private async void EliminarCommand_Executed()
        {
            // Muestra una confirmación antes de eliminar
            bool confirmacion = await Application.Current.MainPage.DisplayAlert("Confirmar eliminación","¿Estás seguro de que quieres eliminar a " + personaSeleccionada.Nombre + " " + PersonaSeleccionada.Apellidos + "?","Sí", "No");

            if (confirmacion)
            {
                listadoPersonas.Remove(personaSeleccionada);
                ClsServiciosBl.deletePersonaBl(personaSeleccionada.Id);
                personaSeleccionada = null;
            }
        }

        private bool EliminarCommand_CanExecute()
        {
            bool res = false;

            if (personaSeleccionada != null)
            {
                res = true;
            }

            return res;
        }

        private async void RefrescarCommand_Executed()
        {
            listadoPersonas = new List<ClsPersona>(ClsListadosBl.ListadoCompletoPersonasBl());
            NotifyPropertyChanged("ListadoPersonas");
        }

        private bool RefrescarCommand_CanExecute()
        {
            bool res = true;

            return res;
        }
        #endregion
    }*/
}
