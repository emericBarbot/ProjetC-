using System;
using System.Collections.Generic;
using System.Xml.Linq;


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

            //organigramme.SupprimerEmploye(employe1);

            organigramme.AfficherOrganigramme();

            Console.ReadKey();

            Console.Clear();


            // Initialisation des villes
            List<Ville> villes = InitialisationVilles();

            // Création d'un graphe
            Graphe graphe = new Graphe(villes);

            // Initialisation des arêtes
            graphe = InitialisationAretes(graphe);
            


            // Affichage du graphe
            graphe.AfficherGraphe();

            Console.ReadKey();

            Console.Clear();

            // Interface utilisateur
            InterfaceUtilisateur(organigramme);
            

            
        }
        static int ConvertirTempsEnminutes(string temps)
        {
            string[] elements = temps.Split('h');
            return int.Parse(elements[0]) * 60 + int.Parse(elements[1]);
        }

        // Initialisation des villes depuis csv
        // Csv de forme : Ville;CodePostal
        static List<Ville> InitialisationVilles()
        {
            List<Ville> villes = new List<Ville>();
            string[] lignes = System.IO.File.ReadAllLines("C:\\Users\\bapti\\source\\repos\\TransConnect\\CPostal.csv");
            foreach (var ligne in lignes)
            {
                string[] elements = ligne.Split(';');
                villes.Add(new Ville(elements[0], int.Parse(elements[1])));
            }
            return villes;
        }

        // Initialisation des arêtes depuis csv
        // Csv de forme : Ville1;Ville2;Poids_km;Poids_temps

        static Graphe InitialisationAretes(Graphe graphe)
        {
            string[] lignes = System.IO.File.ReadAllLines("C:\\Users\\bapti\\source\\repos\\TransConnect\\Distances.csv");
            foreach (var ligne in lignes)
            {
                string[] elements = ligne.Split(';');
                Ville ville1 = graphe.Villes.Find(v => v.Nom == elements[0]);
                Ville ville2 = graphe.Villes.Find(v => v.Nom == elements[1]);
                int poids_km = int.Parse(elements[2]);
                int poids_temps = ConvertirTempsEnminutes(elements[3]);
                graphe.AjouterArete(ville1, ville2, poids_km, poids_temps);
            }
            return graphe;
        }

        // Calcul du plus court chemin entre deux villes
        static void PlusCourtChemin(Graphe graphe, Ville depart, Ville arrivee)
        {
            Dictionary<Ville, int> distances = new Dictionary<Ville, int>();
            Dictionary<Ville, Ville> predecesseurs = new Dictionary<Ville, Ville>();
            List<Ville> villesNonVisitees = new List<Ville>();

            foreach (var v in graphe.Villes)
            {
                distances[v] = int.MaxValue;
                predecesseurs[v] = null;
                villesNonVisitees.Add(v);
            }

            distances[depart] = 0;

            while (villesNonVisitees.Count > 0)
            {
                Ville villeCourante = villesNonVisitees.OrderBy(v => distances[v]).First();
                villesNonVisitees.Remove(villeCourante);

                foreach (var voisin in villeCourante.Voisins)
                {
                    if (villesNonVisitees.Contains(voisin.Destination))
                    {
                        int distance = distances[villeCourante] + voisin.Poids_km;
                        if (distance < distances[voisin.Destination])
                        {
                            distances[voisin.Destination] = distance;
                            predecesseurs[voisin.Destination] = villeCourante;
                        }
                    }
                }
            }

            Ville ville = arrivee;
            List<Ville> chemin = new List<Ville>();
            while (ville != null)
            {
                chemin.Add(ville);
                ville = predecesseurs[ville];
            }
            chemin.Reverse();
            Console.WriteLine($"Plus court chemin entre {depart} et {arrivee} :");
            foreach (var v in chemin)
            {
                Console.WriteLine(v);
            }
        }

        // Calcul du plus rapide chemin entre deux villes
        static void PlusRapideChemin(Graphe graphe, Ville depart, Ville arrivee)
        {
            Dictionary<Ville, int> temps = new Dictionary<Ville, int>();
            Dictionary<Ville, Ville> predecesseurs = new Dictionary<Ville, Ville>();
            List<Ville> villesNonVisitees = new List<Ville>();

            foreach (var v in graphe.Villes)
            {
                temps[v] = int.MaxValue;
                predecesseurs[v] = null;
                villesNonVisitees.Add(v);
            }

            temps[depart] = 0;

            while (villesNonVisitees.Count > 0)
            {
                Ville villeCourante = villesNonVisitees.OrderBy(v => temps[v]).First();
                villesNonVisitees.Remove(villeCourante);

                foreach (var voisin in villeCourante.Voisins)
                {
                    if (villesNonVisitees.Contains(voisin.Destination))
                    {
                        int tempsTrajet = temps[villeCourante] + voisin.Poids_temps;
                        if (tempsTrajet < temps[voisin.Destination])
                        {
                            temps[voisin.Destination] = tempsTrajet;
                            predecesseurs[voisin.Destination] = villeCourante;
                        }
                    }
                }
            }

            Ville ville = arrivee;
            List<Ville> chemin = new List<Ville>();
            while (ville != null)
            {
                chemin.Add(ville);
                ville = predecesseurs[ville];
            }
            chemin.Reverse();
            Console.WriteLine($"Plus rapide chemin entre {depart} et {arrivee} :");
            foreach (var v in chemin)
            {
                Console.WriteLine(v);
            }
        }

        // Création d'une interface utilisateur permettant de gérer les employés
        static void InterfaceUtilisateur(Organigramme organigramme)
        {
            Console.WriteLine("Bienvenue dans l'interface de gestion des employés");
            Console.WriteLine("1 - Afficher l'organigramme");
            Console.WriteLine("2 - Ajouter un employé");
            Console.WriteLine("3 - Supprimer un employé");
            Console.WriteLine("4 - Quitter");

            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    organigramme.AfficherOrganigramme();
                    break;
                case "2":
                    Console.WriteLine("Nom : ");
                    string nom = Console.ReadLine().Trim();
                    Console.WriteLine("Prénom : ");
                    string prenom = Console.ReadLine().Trim();
                    Console.WriteLine("Numéro de sécurité sociale : ");
                    string numeroSS = Console.ReadLine().Trim();
                    Console.WriteLine("Adresse postale : ");
                    string adressePostale = Console.ReadLine().Trim();
                    Console.WriteLine("Adresse mail : ");
                    string adresseMail = Console.ReadLine().Trim();
                    Console.WriteLine("Téléphone : ");
                    string telephone = Console.ReadLine().Trim();
                    Console.WriteLine("Date de naissance (format YYYY-MM-DD) : ");
                    DateTime dateNaissance;
                    while (!DateTime.TryParse(Console.ReadLine().Trim(), out dateNaissance))
                    {
                        Console.WriteLine("Format de date invalide. Veuillez réessayer.");
                    }
                    Console.WriteLine("Poste : ");
                    string poste = Console.ReadLine().Trim();
                    Console.WriteLine("Salaire : ");
                    string salaire = Console.ReadLine().Trim();
                    Console.WriteLine("Date d'embauche (format YYYY-MM-DD) : ");
                    DateTime dateEmbauche;
                    while (!DateTime.TryParse(Console.ReadLine().Trim(), out dateEmbauche))
                    {
                        Console.WriteLine("Format de date invalide. Veuillez réessayer.");
                    }
                    // Afficher les managers disponibles
                    Console.WriteLine("Managers disponibles : ");
                    foreach (Employe e in organigramme.Chef.Subordonnes)
                    {
                        Console.WriteLine(e.Nom);
                    }
                    string nomManager = Console.ReadLine();
                    Employe manager = organigramme.TrouverUnEmploye(nomManager);
                    Employe employe = new Employe(nom, prenom, numeroSS, adressePostale, adresseMail, telephone, dateNaissance, poste, salaire, dateEmbauche, new List<Employe>(), manager);
                    organigramme.AddEmploye(manager, employe);
                    
                    break;
                case "3":
                    Console.WriteLine("Nom de l'employé à supprimer : ");
                    string nomEmploye = Console.ReadLine();
                    Employe asupprimer = organigramme.TrouverUnEmploye(nomEmploye);
                    // Afficher le si asupprimer est null
                    if (asupprimer == null)
                    {
                        Console.WriteLine("Employé non trouvé");
                        break;
                    }
                    organigramme.SupprimerEmploye(asupprimer);
                    break;
                case "4":
                    return;
            }
            InterfaceUtilisateur(organigramme);
        }

    }
}