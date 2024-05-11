using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Ville
    {
        string nom;
        int codePostal;
        List<Arete> voisins;

        internal string Nom { get => nom; }
        internal int CodePostal { get => codePostal; }
        internal List<Arete> Voisins { get => voisins; }

        internal Ville(string nom, int codePostal)
        {
            this.nom = nom;
            this.codePostal = codePostal;
            voisins = new List<Arete>();
        }

        internal void AjouterVoisin(Ville voisin, int poids_km, int poids_temps)
        {
            voisins.Add(new Arete(voisin, poids_km, poids_temps));
        }

        public override string ToString()
        {
            return nom + ", Code postal : " + codePostal;
        }
    }
}
