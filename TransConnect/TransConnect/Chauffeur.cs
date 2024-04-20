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
        double tauxHoraire;
        
        public Chauffeur(string nom,string prenom, string numeroSS, string adressePostale, string adresseMail,string telephone, DateTime dateNaissance,string poste, double salaire, DateTime dateEmbauche): base(nom, prenom, numeroSS, adressePostale, adresseMail, telephone, dateNaissance, poste, salaire, dateEmbauche)
        {
            this.tauxHoraire = AttributionTauxHoraireParGrille();
        }



        /// <summary>
        /// attribu un salaire 
        /// </summary>
        /// <returns>taux horaire du chauffeur</returns>
        public double AttributionTauxHoraireParGrille()
        {
            TimeSpan ancienneete = DateTime.Now - DateEmbauche;
            double salaireBase = 12;
            int annees = ancienneete.Days / 365;
            double tauxHoraire;
            if (annees < 1)
            {
                tauxHoraire = salaireBase;
            }
            else if (annees < 3)
            {
                tauxHoraire = salaireBase * 1.05; 
            }
            else if (annees < 5)
            {
                tauxHoraire = salaireBase * 1.10; 
            }
            else
            {
                tauxHoraire = salaireBase * 1.20; 
            }

            return tauxHoraire;


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
