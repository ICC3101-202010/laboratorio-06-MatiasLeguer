using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_MatiasLeguer
{
    [Serializable]
    public class Empresa
    {
        private string nameCompany;
        private string rutCompany;
        private int opcion;
        private List<Division> listaDivision = new List<Division>();
        public Empresa(string nameCompany, string rutCompany) 
        {
            this.nameCompany = nameCompany;
            this.rutCompany = rutCompany;
        }

        public string NameCompany { get => nameCompany; }
        public string RutCompany { get => rutCompany; }
        public List<Division> ListaDivision { get => listaDivision; set => listaDivision = value; }
        public int Opcion { get => opcion; set => opcion = value; }

    }
}
