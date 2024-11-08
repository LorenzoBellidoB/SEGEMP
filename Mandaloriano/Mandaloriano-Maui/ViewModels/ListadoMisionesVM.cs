
using BL;
using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mandaloriano_Maui.ViewModels
{

    public class ListadoMisionesVM: INotifyPropertyChanged
    {
        #region Atributos
        private List<ClsMision> listadoMisiones;
        private ClsMision mision;
        private Boolean visible;
        private Boolean visiblePicker;
        #endregion

        #region Propiedades
        public List<ClsMision> ListaMisiones 
        {
            get { return listadoMisiones; }
            set { listadoMisiones = value; }
        }
        public ClsMision Mision 
        {
            get { return mision; 
            }
            set { mision = value;
                NotifyPropertyChanged("Mision");
            }
        }

        public Boolean Visible {
            get { return visible; }

            
        }

        public Boolean VisiblePicker
        {
            get { return !visible; }


        }
        #endregion

        public ListadoMisionesVM()
        {
            try
            {
                ListaMisiones = ClsAcceso.ListadoCompletoMisionesBl();
            }
            catch (HourException h)
            {
                visible = true;
                NotifyPropertyChanged("Visible");
                NotifyPropertyChanged("VisiblePicker");
            }
            
        }

        public ListadoMisionesVM(int id): this() 
        {
            Mision = ClsAcceso.MisionSelectedBl(id);
        }

        

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        //

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
