using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_MatiasLeguer
{
    [Serializable]
    public class Seccion : Division
    {
        protected Persona person;
        protected string zonaS = "Seccion";

        public string ZonaS { get => zona; }
        public Persona Encargado { get => person; }
        public Seccion(Persona person, string nombreDiv) : base(nombreDiv)
        {
            this.person = person;
        }
        public Seccion() : base()
        {
            this.person = new Persona("Corina", "Machado", "20522345-5", zonaS);
        }
    }
}
