using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class CamionBenne:PoidsLourds
    {
        int nbBennes;
        bool presenceGrue;

        public CamionBenne(string marque, string immatriculation, int annee, DateTime dateAchat, DateTime dernierControle, double volume, string matieresTransportes, int nbBennes,bool presenceGrue) : base(marque, immatriculation, annee, dateAchat, dernierControle, volume, matieresTransportes)
        {
            this.nbBennes = nbBennes;
            this.presenceGrue = presenceGrue;
        }
        public int NbBennes
        {
            get { return NbBennes; }
            set { nbBennes = value; }
        }
        public bool PresenceGrue
        {
            get { return presenceGrue; }
            set { presenceGrue = value; }
        }
    }
}
