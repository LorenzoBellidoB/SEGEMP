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

        #endregion

        #region Propiedades
        public PersonaDept PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set {crearCommand.RaiseCanExecuteChanged(); NotifyPropertyChanged("PersonaSeleccionada"); personaSeleccionada = value; }
        }

        public List<PersonaDept> ListadoPersonasDept 
        { 
            get { return listadoPersonasDept; } 
            set { listadoPersonasDept = value; } 
        }

        public List<ClsPersona> ListadoPersonas
        {
            get { return listadoPersonas; }
            set { listadoPersonas = value; }
        }

        public DelegateCommand CrearCommand
        {
            get { return crearCommand; }
        }
        #endregion

        #region Constructores
        public ListadoPersonasDeptVM()
        {
            refresh();
            crearCommand = new DelegateCommand(crearCommand_Executed, crearCommand_CanExecute);
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
            bool res = false;

            if (PersonaSeleccionada == null)
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
