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
        /// <summary>
        /// ajoute une date afin de la rendre le chauffeur indisponible pour toute autre livraison ce même jour.
        /// </summary>
        /// <param name="ajout">la date à ajouter</param>
        public void ajoutDateCalendrier(DateTime ajout)
        {
            calendrier.Add(ajout);
        }

        /// <summary>
        /// indique si le chauffeur est disponible pour un jour donné
        /// </summary>
        /// <param name="date">le jour à verifier</param>
        /// <returns>True si disponible False sinon</returns>
        public bool disponibiliteChauffeur(DateTime date)
        {
            return !calendrier.Contains(date);
        }

    }
}
