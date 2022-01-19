using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Listados
    {

        String cadenaUrl = "https://crudpersonasdefasp.azurewebsites.net/";

        public Listados()
        {


        }

        public async Task<List<clsPersona>> getPersonasDAL() {

            Uri miUri = new Uri($"{cadenaUrl}api/apipersonas");
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            HttpClient miHttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textJsonRespuesta;
            miHttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await miHttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {

                    textJsonRespuesta = await miHttpClient.GetStringAsync(miUri);
                    miHttpClient.Dispose();
                    listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(textJsonRespuesta);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return listadoPersonas;
        }

        public async Task borrarPersona(int idPersona) {
            Uri miUri = new Uri($"{cadenaUrl}api/apipersonas/${idPersona}");
            HttpResponseMessage miCodigoRespuesta;
            string textJsonRespuesta;
            HttpClient miHttpClient = new HttpClient();

            try
            {
                miCodigoRespuesta = await miHttpClient.DeleteAsync(miUri);
            }
            catch (Exception) { }
        }
        //todo comprobar que se haya deleteado
    }
}
