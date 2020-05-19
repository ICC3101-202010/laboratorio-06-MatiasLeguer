using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_MatiasLeguer
{
    [Serializable]
    public class Division
    {
        protected string nombreDiv;
        protected string zona = "Division";
        protected List<Area> listaArea = new List<Area>();
        protected List<Departamento> listaDep = new List<Departamento>();
        protected List<Seccion> listaSec = new List<Seccion>();
        protected List<Bloque> listaBloque = new List<Bloque>();

        public string NombreDiv { get => nombreDiv; }
        public string ZonaDiv { get => zona; }
        public List<Area> ListaArea { get => listaArea; set => listaArea = value; }
        public List<Departamento> ListaDep { get => listaDep; set => listaDep = value; }
        public List<Seccion> ListaSec { get => listaSec; set => listaSec = value; }
        public List<Bloque> ListaBloque { get => listaBloque; set => listaBloque = value; }

        public Division(string nombreDiv)
        {
            this.nombreDiv = nombreDiv;
        }
        public Division()
        {
            this.nombreDiv = "Matias Leguer";
        }
    }
}
