using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    public abstract class Vehicule
    {
        string marque, immatriculation;
        int annee;
        DateTime dateAchat, dernierControl;

        internal string Marque { get => marque; }
        internal string Immatriculation { get => immatriculation; }
        internal int Annee { get => annee; }
        internal DateTime DateAchat { get => dateAchat; }
        internal DateTime DernierControl { get => dernierControl; }
    }
}