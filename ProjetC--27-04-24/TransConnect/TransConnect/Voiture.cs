using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    public class Voiture: Vehicule
    {
        int nbPassagers;

        public Voiture(string marque, string immatriculation, int annee, DateTime dateAchat, DateTime dernierControle, int nbPassagers): base(marque, immatriculation, annee, dateAchat, dernierControle)
        {
            this.nbPassagers = nbPassagers;
        }
        public int NbPassagers
        {
            get { return nbPassagers; }
            set { nbPassagers = value; }
        }

    }
}
