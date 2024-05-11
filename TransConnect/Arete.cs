using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Arete
    {
        Ville destination;
        int poids_km;
        int poids_temps;

        internal Ville Destination { get => destination; }
        internal int Poids_km { get => poids_km; }
        internal int Poids_temps { get => poids_temps; }

        internal Arete(Ville destination, int poids_km, int poids_temps)
        {
            this.destination = destination;
            this.poids_km = poids_km;
            this.poids_temps = poids_temps;
        }
    }
}
