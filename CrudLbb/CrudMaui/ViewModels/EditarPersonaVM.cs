using BL;
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
    public class clsEditarPersonaVM : INotifyPropertyChanged
    {
        private int idPersona;
        private ClsPersona personaEditada;

        public ClsPersona PersonaEditada
        {
            get { return personaEditada; }
            set
            {
                personaEditada = value;
                NotifyPropertyChanged("PersonaEditada");
            }
        }


        public clsEditarPersonaVM()
        {

        }

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));

        }
        #endregion

        #region Metodos

        private async void EnviarCommand_Executed()
        {
            Dictionary<string, object> diccionarioMandar = new Dictionary<string, object>();

            ClsServiciosBl.updatePersonaBl(personaEditada);

            diccionarioMandar.Add("Persona", PersonaEditada);

            await Shell.Current.GoToAsync("///Personas", diccionarioMandar);
        }

        private bool EnviarCommand_CanExecute()
        {
            bool res = false;

            if (personaEditada != null)
            {
                res = true;
            }

            return res;
        }

        #endregion
    }
}
