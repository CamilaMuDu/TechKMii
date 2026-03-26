using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTNLeccion8B.Layer.Entities.PersonaHacienda
{
    public class PersonaHaciendaDatos
    {
        public string nombre { set; get; }
        public string tipoIdentificacion { set; get; }
        public PersonaHaciendaRegimen regimen { set; get; }
        public PersonaHaciendaSituacion situacion { set; get; }
        public List<PersonaHaciendaActividad> actividades { set; get; }

    }
}
