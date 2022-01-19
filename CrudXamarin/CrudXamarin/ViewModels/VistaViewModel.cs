
using Entidades;
using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CrudXamarin.ViewModels
{
    public class VistaViewModel : INotifyPropertyChanged
    {
            List<clsPersona> personas;
            clsPersona personaSeleccionada;
            Command comandoBoton;
            PersonasBl personasBl;

        public VistaViewModel()
        {
           // comandoBoton = new Command(execute(), canExecute());
            personasBl = new PersonasBl();
        }

  
            public clsPersona PersonaSeleccionada
                {
                    get => personaSeleccionada; set
                    {
                        personaSeleccionada = value;
                        OnPropertyChanged("personaSeleccionada");
                        
                    }
                }

                public Command ComandoBoton { get => comandoBoton; set => comandoBoton = value; }
        public List<clsPersona> Personas { get => personas; set => personas = value; }



        // se podria arreglar con un boolen



        /// <summary>
        /// si nop hay ningun cambio, no esta activo
        /// </summary>
        /// <returns></returns>
        public bool canExecute()
            {

                return true;
            }

            async public void execute()
            {
                Personas = await personasBl.getPersonas();
                OnPropertyChanged("Personas");
        }



            public event PropertyChangedEventHandler PropertyChanged;

            bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
            {
                if (Object.Equals(storage, value))
                    return false;

                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

