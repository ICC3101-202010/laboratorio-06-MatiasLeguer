using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_MatiasLeguer
{
    [Serializable]
    public class Area : Division
    {
        protected Persona person;
        protected string zonaA = "Area";

        public string ZonaA { get => zona; }
        public Persona Encargado { get => person; }


        public Area(Persona person, string nombreDiv) : base(nombreDiv)
        {
            this.person = person;
        }
        public Area() : base()
        {
            this.person = new Persona("Diego", "Pinochet", "20546678-9", zonaA);

        }
    }
}
