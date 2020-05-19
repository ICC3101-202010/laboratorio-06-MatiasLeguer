using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_MatiasLeguer
{
    [Serializable]
    public class Bloque : Division
    {
        protected Persona person;
        protected string zonaBloque = "Bloque";
        protected List<Persona> personal = new List<Persona>(2);

        public Persona Encargado { get => person; }
        public string ZonaBloque { get => zona; }
        public List<Persona> Personal { get => personal; set => personal = value; }

        public Bloque(Persona person, string nombreDiv) : base(nombreDiv)
        {
            this.person = person;
        }

        public Bloque() : base()
        {
            this.person = new Persona("George", "Chammas", "24000234-1", zonaBloque);

        }
        public Bloque(Persona person) : base()
        {
            this.person = person;
        }
    }
}
