using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    public class Commande
    {
        Client clientCommande;
        string villeDepart;
        string villeArrivee;
        DateTime dateDepart;
        Chauffeur chauffeurCommande;
        Vehicule vehiculeCommande;
        string id;



        public Commande(Client clientCommande, string villeDepart, string villeArrivee, Vehicule vehiculeCommande, Chauffeur chauffeurCommande, DateTime dateDepart)
        {
            this.clientCommande = clientCommande;
            this.villeDepart = villeDepart;
            this.villeArrivee = villeArrivee;
            this.chauffeurCommande = chauffeurCommande;
            this.vehiculeCommande = vehiculeCommande;
            this.id= Guid.NewGuid().ToString();
        }
        public double Prix()
        {

        }
        public Client ClientCommande
        {
            get { return clientCommande; }
            set { clientCommande = value; }
        }

        public string VilleDepart
        {
            get { return villeDepart; }
            set { villeDepart = value; }
        }

        public string VilleArrivee
        {
            get { return villeArrivee; }
            set { villeArrivee = value; }
        }

        public DateTime DateDepart
        {
            get { return dateDepart; }
            set { dateDepart = value; }
        }


        public Chauffeur ChauffeurCommande
        {
            get { return chauffeurCommande; }
            set { chauffeurCommande = value; }
        }

        public Vehicule VehiculeCommande
        {
            get { return vehiculeCommande; }
            set { vehiculeCommande = value; }
        }

        public string Id
        {
            get { return id; }

        }



    }
