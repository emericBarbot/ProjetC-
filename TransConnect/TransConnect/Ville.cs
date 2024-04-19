using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    public class Ville
    {
        string nom;
        int codePostal;

        internal string Nom { get => nom; }
        internal int CodePostal { get => codePostal; }

        internal Ville(string nom, int codePostal)
        {
            this.nom = nom;
            this.codePostal = codePostal;
        }
    }
}
