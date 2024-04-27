using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Graphe
    {
        List<Ville> villes;

        internal List<Ville> Villes { get => villes; }

        internal Graphe()
        {
            villes = new List<Ville>();
        }
        internal Graphe(List<Ville> villes)
        {
            this.villes = villes;
        }

        internal void AjouterVille(Ville ville)
        {
            villes.Add(ville);
        }
        internal void AjouterArete(Ville ville1, Ville ville2, int poids_km, int poids_temps)
        {
            ville1.AjouterVoisin(ville2, poids_km, poids_temps);
        }
        internal void AfficherGraphe()
        {
            foreach (var ville in villes)
            {
                Console.WriteLine(ville);
                foreach (var voisin in ville.Voisins)
                {
                    Console.WriteLine($"  -> {voisin.Destination} ({voisin.Poids_km}) ({voisin.Poids_temps})");
                }
            }
        }
    }
}
