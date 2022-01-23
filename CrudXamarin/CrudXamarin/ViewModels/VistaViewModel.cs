
using Entidades;
using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using MvvmHelpers.Commands;

namespace CrudXamarin.ViewModels
{
    public class VistaViewModel : INotifyPropertyChanged
    {
            List<clsPersona> personas;
            clsPersona personaSeleccionada;
            Xamarin.Forms.Command comandoMostrar;
            DelegateCommand comandoMostrar2;
            AsyncCommand comandoBorrar;
            PersonasBl personasBl;

        public VistaViewModel()
        {
            comandoMostrar = new Xamarin.Forms.Command( async() => await executeMostrar());
            comandoBorrar = new AsyncCommand(async () => await executeBorrar() /*can execute*/);
            personasBl = new PersonasBl();
            personas = new List<clsPersona>();
        }

    
        public clsPersona PersonaSeleccionada
                {
                    get => personaSeleccionada; set
                    {
                        personaSeleccionada = value;
                        OnPropertyChanged("personaSeleccionada");
                    }
                }

        public List<clsPersona> Personas { get => personas; set { personas = value; OnPropertyChanged("Personas"); } }

        public Xamarin.Forms.Command ComandoMostrar { get => comandoMostrar; set => comandoMostrar = value; }

        // se podria arreglar con un boolen

        /// <summary>
        /// si nop hay ningun cambio, no esta activo
        /// </summary>
        /// <returns></returns>
      
        private async Task executeBorrar()
        {
           await personasBl.borrarPersona(personaSeleccionada.Id);
        }

        public bool canExecuteBorrar()
        {
            return personaSeleccionada != null;
        }

        //public async Task<List<clsPersona>> getPersonas()

        public bool canExecuteMostar()
        {
            return true;
        }

        public async Task executeMostrar()
            {
                Personas = await personasBl.getPersonas();
                OnPropertyChanged("Personas");
              }


            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }


    /**
 {
    public class ViewModelList : clsVMBase
    {
        #region propiedades privadas
        bool indicatorState;
        DelegateCommand cargarLista;
        DelegateCommand borrarPersona;
        List<clsPersona> listadoPersonas;
        clsPersona personaSeleccionada;
        GestoraPersonasApiBL gestora ;
        #endregion
        #region propiedades publicas
        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set { listadoPersonas = value; NotifyPropertyChanged("ListadoPersonas"); } }
        public clsPersona PersonaSeleccionada { get => personaSeleccionada; set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); } }

        public DelegateCommand CargarLista { get { return cargarLista = new DelegateCommand(CargarLista_Execute, CargarLista_CanExecute); } }
        public DelegateCommand BorrarPersona { get { return borrarPersona = new DelegateCommand(BorrarPersona_Execute, BorrarPersona_CanExecute); } }

        public bool IndicatorState { get => indicatorState; set { indicatorState = value; NotifyPropertyChanged("Indicator"); } }

        #region constructor
        public ViewModelList() 
        {
            listadoPersonas = new List<clsPersona>();
            gestora = new GestoraPersonasApiBL();
            indicatorState = false;
        }
        #endregion
        #region
        private bool BorrarPersona_CanExecute()
        {
            return /*personaSeleccionada != null true;
        }

private async void BorrarPersona_Execute()
{
    HttpStatusCode httpStatus = new HttpStatusCode();
    bool response = await Application.Current.MainPage.DisplayAlert("Borrar", "Seguro?", "yes", "no");
    //TODO preguntar antes de borrar y notificar borrado correcto
    if (response)
    {
        IndicatorState = true;
        httpStatus = await gestora.BorrarPersonaBL(personaSeleccionada.Id);
        CargarListaPersonas();
        IndicatorState = false;
        if (httpStatus == HttpStatusCode.OK)
        {
            await Application.Current.MainPage.DisplayAlert("Joya", "Ta Joya", "Perfe");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Cagaste", $"Codigo de error{httpStatus}", "Catxis");
        }
    }
}
#endregion
#endregion
#region CargarLista
private bool CargarLista_CanExecute()
{
    return true;
}

private void CargarLista_Execute()
{
    IndicatorState = true;
    CargarListaPersonas();
    IndicatorState = false;
}

private async void CargarListaPersonas()
{
    ListadoPersonas = await gestora.ListadoCompletoBL();
}
        #endregion
    }
}
     */
    }

