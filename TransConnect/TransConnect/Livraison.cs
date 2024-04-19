using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    public class Livraison
    {
        Ville villeDepart, villeArrivee;
        DateTime dateDepart, dateArrivee;
        Employe chauffeur;
        Vehicule vehicule;

        internal Ville VilleDepart { get => villeDepart; }
        internal Ville VilleArrivee { get => villeArrivee; }
        internal DateTime DateDepart { get => dateDepart; }
        internal DateTime DateArrivee { get => dateArrivee; }
        internal Employe Chauffeur { get => chauffeur; }
        internal Vehicule Vehicule { get => vehicule; }

        internal Livraison(Ville villeDepart, Ville villeArrivee, DateTime dateDepart, DateTime dateArrivee, Employe chauffeur, Vehicule vehicule)
        {
            this.villeDepart = villeDepart;
            this.villeArrivee = villeArrivee;
            this.dateDepart = dateDepart;
            this.dateArrivee = dateArrivee;
            this.chauffeur = chauffeur;
            this.vehicule = vehicule;
        }
    }
}
