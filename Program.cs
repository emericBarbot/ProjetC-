using System;
using System.Collections.Generic;


namespace TransConnect
{
    class Program
    {
        static void Main()
        {
            // Création de quelques employés
            Employe ceo = new Employe(
                nom: "Dupont",
                prenom: "Jean",
                numeroSS: "1234567890123",
                adressePostale: "10 rue de la Paix",
                adresseMail: "jean.dupont@example.com",
                telephone: "0123456789",
                dateNaissance: new DateTime(1980, 5, 15),
                poste: "Manager",
                salaire: "5000€",
                dateEmbauche: new DateTime(2005, 8, 10),
                subordonnes: new List<Employe>(),
                manager: null
            );

            Employe employe1 = new Employe(
                nom: "Martin",
                prenom: "Alice",
                numeroSS: "2345678901234",
                adressePostale: "15 avenue des Champs-Élysées",
                adresseMail: "alice.martin@example.com",
                telephone: "0234567890",
                dateNaissance: new DateTime(1990, 10, 20),
                poste: "Développeur",
                salaire: "4000€",
                dateEmbauche: new DateTime(2010, 3, 25),
                subordonnes: new List<Employe>(),
                manager: null
            );

            Employe employe2 = new Employe(
                nom: "Durand",
                prenom: "Paul",
                numeroSS: "3456789012345",
                adressePostale: "25 rue de la Liberté",
                adresseMail: "paul.durand@example.com",
                telephone: "0345678901",
                dateNaissance: new DateTime(1985, 8, 8),
                poste: "Chef de projet",
                salaire: "4500€",
                dateEmbauche: new DateTime(2008, 6, 18),
                subordonnes: new List<Employe>(),
                manager: null
            );

            Employe employe3 = new Employe(
                nom: "Lefevre",
                prenom: "Sophie",
                numeroSS: "4567890123456",
                adressePostale: "30 rue de la République",
                adresseMail: "sophie.lefevre@example.com",
                telephone: "0456789012",
                dateNaissance: new DateTime(1995, 12, 5),
                poste: "Chef de projet IT",
                salaire: "4000€",
                dateEmbauche: new DateTime(2015, 9, 30),
                subordonnes: new List<Employe>(),
                manager: null
            );
            // Ajout des subordonnés au manager
            ceo.Subordonnes.Add(employe3);
            employe3.Subordonnes.Add(employe2);
            employe3.Subordonnes.Add(employe1);

            // Creation d'un organigramme
            Organigramme organigramme = new Organigramme(ceo);

            organigramme.AfficherOrganigramme();

            organigramme.SupprimerEmploye(employe1);

            organigramme.AfficherOrganigramme();

            // Initialisation des villes
            InitialisationDistances();

            // Affichage des villes
            List<Ville> villes = InitialisationVilles();
            foreach (Ville ville in villes)
            {
                Console.WriteLine(ville);
            }

            // Affichage du graphe
            Graphe graphe = new Graphe();
            graphe.AjouterVille(new Ville("Paris", 75));
            graphe.AjouterVille(new Ville("Lyon", 69));
            graphe.AjouterVille(new Ville("Marseille", 90));
            graphe.AjouterVille(new Ville("Toulouse", 89));
            graphe.AjouterVille(new Ville("Bordeaux", 12));

            graphe.TrajetPlusCourt(new Ville("Paris", 75), new Ville("Marseille", 90));
            // Afficher le trajet le plus court
            foreach (Ville ville in graphe.TrajetPlusCourt(new Ville("Paris", 75), new Ville("Marseille", 90)))
            {
                Console.WriteLine(ville);
            }
        }

        static void InitialisationDistances()
        {
            string file = "C:\\Users\\bapti\\source\\repos\\TransConnect\\Distances.csv";


            // Vérifier si le fichier existe
            if (File.Exists(file))
            {
                // Lire toutes les lignes du fichier
                string[] lines = File.ReadAllLines(file);

                // Parcourir les lignes
                foreach (string line in lines)
                {
                    // Diviser la ligne en colonnes en utilisant une virgule comme séparateur
                    string[] columns = line.Split(';');

                    // Accéder aux données individuelles dans chaque colonne
                    string villeDepart = columns[0];
                    string villeArrivee = columns[1];
                    int distance = int.Parse(columns[2]);
                    string duree = columns[3];

                    // Utiliser les données comme nécessaire
                    Console.WriteLine($"Ville de départ : {villeDepart}, Ville d'arrivée : {villeArrivee}, Distance : {distance}, Durée : {duree}");
                }
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas.");
            }
        }
        static List<Ville> InitialisationVilles()
        {
            string file = "C:\\Users\\bapti\\source\\repos\\TransConnect\\CPostal.csv";
            List<Ville> villes = new List<Ville>();

            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    
                    string[] values = line.Split(';');

                    string nom = values[0];
                    int codePostal = Convert.ToInt32(values[1]);

                    villes.Add(new Ville(nom, codePostal));
                }
            }
            return villes;
        }
    }   
}