using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_MatiasLeguer
{
    [Serializable]
    public class Persona
    {
        private string nombreP;
        private string apellidoP;
        private string rut;
        private string cargo;

        public string NombreP { get => nombreP; }
        public string ApellidoP { get => apellidoP; }
        public string RUT { get => rut; }
        public string Cargo { get => cargo; }

        public Persona(string nombreP, string apellidoP, string rut, string cargo)
        {
            this.nombreP = nombreP;
            this.apellidoP = apellidoP;
            this.rut = rut;
            this.cargo = cargo;
        }


    }
}
