using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class CamionFrigorifique:PoidsLourds
    {
        int nbGroupesElectrogenes;

        public CamionFrigorifique(string marque, string immatriculation, int annee, DateTime dateAchat, DateTime dernierControle, double volume, string matieresTransportes, int nbGroupesElectrogenes) : base(marque, immatriculation, annee, dateAchat, dernierControle, volume, matieresTransportes)
        {
            this.nbGroupesElectrogenes = nbGroupesElectrogenes;
        }

        public int NbGroupesElectrogenes
        {
            get { return nbGroupesElectrogenes; }
            set { nbGroupesElectrogenes = value; }
        }
    }
}
