using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;
using System.Text.Json; //es para no usar el NewtonSoft


namespace TechKMii.Layers.BLL
{
    public class BLLProvincia : IProvinciaBLL
    {
        /// <summary>
        /// Leerlo json de internet acceder https://github.com/lateraluz/Datos y buscar el archivo provincias.json
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        /// <exception cref=""></exception>
        public List<Provincia> GetProvinciaFromInternet()
        {
            Provincia provincia = null;
            string json = "";
            // Leer del App.Config el URL con el Key URLPadron
            string url = ConfigurationManager.AppSettings["URLProvincia"];
            // Creates a GET request to fetch  
            WebRequest request = WebRequest.Create(url);
            // Verb GET
            request.Method = "GET";
            // GetResponse returns a web response containing the response to the request
            using (WebResponse webResponse = request.GetResponse())
            {
                // Reading data
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                json = reader.ReadToEnd();
            }
            // Todas las provincias
            List<Provincia> lista = JsonSerializer.Deserialize<List<Provincia>>(json);
            return lista;
        }
    }

}

