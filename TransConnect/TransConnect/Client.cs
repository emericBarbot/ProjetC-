using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    public class Client : Personne
    {
        decimal solde;
        internal decimal Solde { get => solde; }

        internal Client(string nom, string prenom, string numeroSS, string adressePostale, string adresseMail, string telephone, DateTime dateNaissance, decimal solde) : base(nom, prenom, numeroSS, adressePostale, adresseMail, telephone, dateNaissance)
        {
            this.solde = solde;
        }
    }
}
