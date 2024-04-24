using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TransConnect
{
    internal class Employe : Personne
    {
        string poste, salaire;
        DateTime dateEmbauche;
        List<Employe> subordonnes;
        Employe manager;

        internal string Poste { get => poste; }
        internal string Salaire { get => salaire; }
        internal DateTime DateEmbauche { get => dateEmbauche; }
        internal List<Employe> Subordonnes { get => subordonnes; }
        internal Employe Manager { get => manager; set { manager = value; } }

        internal Employe(string nom, string prenom, string numeroSS, string adressePostale, string adresseMail, string telephone, DateTime dateNaissance, string poste, string salaire, DateTime dateEmbauche, List<Employe> subordonnes, Employe manager) : base(nom, prenom, numeroSS, adressePostale, adresseMail, telephone, dateNaissance)
        {
            this.poste = poste;
            this.salaire = salaire;
            this.dateEmbauche = dateEmbauche;
            this.subordonnes = subordonnes;
            this.manager = manager;
        }
        //CEO
        internal Employe(string nom, string prenom, string numeroSS, string adressePostale, string adresseMail, string telephone, DateTime dateNaissance, string poste, string salaire, DateTime dateEmbauche) : base(nom, prenom, numeroSS, adressePostale, adresseMail, telephone, dateNaissance)
        {
            this.poste = poste;
            this.salaire = salaire;
            this.dateEmbauche = dateEmbauche;
            this.subordonnes = new List<Employe>();
            this.manager = null;
        }
        internal void AjouterSubordonne(Employe subordonne)
        {
            subordonnes.Add(subordonne);
        }
        internal void SupprimerSubordonne(Employe subordonne)
        {
            subordonnes.Remove(subordonne);
        }
        internal override void ModifierEmail(string adresseMail)
        {
            AdresseMail = adresseMail;
        }
        internal override void ModifierAdressePostale(string adressePostale)
        {
            AdressePostale = adressePostale;
        }
        internal override void ModifierTelephone(string telephone)
        {
            Telephone = telephone;
        }
        public override string ToString()
        {
            return $"{Nom} {Prenom} - {Poste}";
        }
    }
}
