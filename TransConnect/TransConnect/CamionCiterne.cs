using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class CamionCiterne:PoidsLourds
    {
        string typeCuve;

        public CamionCiterne(string marque, string immatriculation, int annee, DateTime dateAchat, DateTime dernierControle, double volume,string matieresTransportes, string typeCuve) : base(marque, immatriculation, annee, dateAchat, dernierControle, volume, matieresTransportes)
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
