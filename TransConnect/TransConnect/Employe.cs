using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    public class Employe : Personne
    {
        string poste;
        double salaire;
        DateTime dateEmbauche;
        public List<Employe> listeSubordonnes=new List<Employe>();


        internal string Poste { get => poste; }
        internal double Salaire { get => salaire; }
        internal DateTime DateEmbauche { get => dateEmbauche; }

        internal Employe(string nom, string prenom, string numeroSS, string adressePostale, string adresseMail, string telephone, DateTime dateNaissance, string poste, double salaire, DateTime dateEmbauche) : base(nom, prenom, numeroSS, adressePostale, adresseMail, telephone, dateNaissance)
        {
            this.poste = poste;
            this.salaire = salaire;
            this.dateEmbauche = dateEmbauche;
        }
        public void ajoutSubordonné(Employe nouveauEmploye)
        {
            listeSubordonnes.Add(nouveauEmploye);
        }

    }
}
