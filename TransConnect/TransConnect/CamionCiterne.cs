using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class CamionCiterne
    {
        string typeCuve;

        public CamionCiterne(string marque, string immatriculation, int annee, DateTime dateAchat, DateTime dernierControle, double volume, string typeCuve) : base(marque, immatriculation, annee, dateAchat, dernierControle, volume)
        {
            this.typeCuve = typeCuve;
        }
        public string TypeCuve
        {
            get { return typeCuve; }
            set { typeCuve = value; }
        }
    }
}
