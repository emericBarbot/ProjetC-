using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Client : Personne
    {
        decimal solde;
        List<Livraison> livraisons;

        internal decimal Solde { get => solde; }

        internal Client(string nom, string prenom, string numeroSS, string adressePostale, string adresseMail, string telephone, DateTime dateNaissance, decimal solde) : base(nom, prenom, numeroSS, adressePostale, adresseMail, telephone, dateNaissance)
        {
            this.solde = solde;
            livraisons = new List<Livraison>();
        }
        internal void Crediter(decimal montant)
        {
            solde += montant;
        }
        internal void Debiter(decimal montant)
        {
            solde -= montant;
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
        internal void PasserLivraison(Livraison livraison)
        {
            livraisons.Add(livraison);
            solde -= livraison.Coutlivraison();
        }
    }
}