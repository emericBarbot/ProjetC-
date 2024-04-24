using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal abstract class Personne
    {
        string nom, prenom, numeroSS, adressePostale, adresseMail, telephone;
        DateTime dateNaissance;

        internal string Nom { get => nom; }
        internal string Prenom { get => prenom; }
        internal string NumeroSS { get => numeroSS; }
        internal string AdressePostale { get => adressePostale; set { adressePostale = value; } }
        internal string AdresseMail { get => adresseMail; set { adresseMail = value; } }
        internal string Telephone { get => telephone; set { telephone = value; } }
        internal DateTime DateNaissance { get => dateNaissance; }

        internal Personne(string nom, string prenom, string numeroSS, string adressePostale, string adresseMail, string telephone, DateTime dateNaissance)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.numeroSS = numeroSS;
            this.adressePostale = adressePostale;
            this.adresseMail = adresseMail;
            this.telephone = telephone;
            this.dateNaissance = dateNaissance;
        }
        internal abstract void ModifierEmail(string adresseMail);
        internal abstract void ModifierAdressePostale(string adressePostale);
        internal abstract void ModifierTelephone(string telephone);
    }
}
