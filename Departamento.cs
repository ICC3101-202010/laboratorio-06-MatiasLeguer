using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_MatiasLeguer
{
    [Serializable]
    public class Departamento : Division
    {
        protected string zonaD = "Departamento";
        protected Persona person;

        public string ZonaDep { get => zona; }
        public Persona Encargado { get => person; }

        public Departamento(Persona person, string nombreDiv) : base(nombreDiv)
        {
            this.person = person;
        }
        public Departamento() : base()
        {
            this.person = new Persona("Francisco", "Ruiz-Tagle", "19067881-2", zonaD);
        }
    }
}
