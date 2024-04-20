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

        public Vehicule(string marque, string immatriculation, int annee, DateTime dateAchat, DateTime dernierControle)
        {
            this.marque = marque;
            this.immatriculation = immatriculation;
            this.annee = annee;
            this.dateAchat = dateAchat;
            this.dernierControl = dernierControle;

        }

        internal string Marque { get => marque; }
        internal string Immatriculation { get => immatriculation; }
        internal int Annee { get => annee; }
        internal DateTime DateAchat { get => dateAchat; }
        internal DateTime DernierControl { get => dernierControl; }
    }
}
