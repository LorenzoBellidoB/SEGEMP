using BL;
using EjercicioU10.ViewModels.Utilidades;
using ENT;
using Microsoft.IdentityModel.Tokens;
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
        private string nombre;
        private string apellidos;
        private string foto;
        private string direccion;
        private string telefono;
        private DateTime fechaNacimiento;
        private int idDepartamento;
        private ClsPersona persona = new ClsPersona();
        private List<ClsDepartamento> listadoDepartamentos;
        private ClsDepartamento departamentoSeleccionado;
        private DelegateCommand guardarCommand;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; guardarCommand.RaiseCanExecuteChanged(); }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; guardarCommand.RaiseCanExecuteChanged(); }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; guardarCommand.RaiseCanExecuteChanged(); }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; guardarCommand.RaiseCanExecuteChanged(); }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; guardarCommand.RaiseCanExecuteChanged();  }
        }

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; guardarCommand.RaiseCanExecuteChanged(); }
        }
        public ClsPersona Persona
        {
            get { return persona; }
            set { persona = value; guardarCommand.RaiseCanExecuteChanged(); }
        }
        public List<ClsDepartamento> ListadoDepartamentos
        {
            get { return listadoDepartamentos; }
        }
        public ClsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set { departamentoSeleccionado = value; guardarCommand.RaiseCanExecuteChanged(); NotifyPropertyChanged("DepartamentoSeleccionado"); }
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
                persona.Nombre = nombre;
                persona.Apellidos = apellidos;
                persona.Foto = foto;
                persona.Direccion = direccion;
                persona.Telefono = telefono;
                persona.FechaNacimiento = fechaNacimiento;

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

            if(nombre != null && apellidos != null && direccion != null && telefono != null && departamentoSeleccionado.Id != 0)
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
