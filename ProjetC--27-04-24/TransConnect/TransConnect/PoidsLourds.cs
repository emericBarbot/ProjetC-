using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class PoidsLourds:Vehicule
    {
        double volume;
        string matieresTransportes;
        public PoidsLourds(string marque, string immatriculation, int annee, DateTime dateAchat, DateTime dernierControle, double volume, string matieresTransportes) : base(marque, immatriculation, annee, dateAchat, dernierControle)
        {
            this.volume = volume;
            this.matieresTransportes = matieresTransportes;

        }
        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        public string MatieresTransportes
        {
            get { return matieresTransportes; }
            set { matieresTransportes = value; }
        }

    }
}
