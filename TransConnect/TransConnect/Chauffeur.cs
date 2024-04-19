using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    public class Chauffeur:Employe
    {
        HashSet<DateTime> calendrier=new HashSet<DateTime>();
        
        public Chauffeur(string nom,string prenom, string numeroSS, string adressePostale, string adresseMail,string telephone, DateTime dateNaissance,string poste, double salaire, DateTime dateEmbauche): base(nom, prenom, numeroSS, adressePostale, adresseMail, telephone, dateNaissance, poste, salaire, dateEmbauche)
        {

        }
        public void ajoutDateCalendrier(DateTime ajout)
        {
            calendrier.Add(ajout);
        }
        public bool disponibiliteChauffeur(DateTime date)
        {
            return !calendrier.Contains(date);
        }

    }
}
