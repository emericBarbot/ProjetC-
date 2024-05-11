internal List<Ville> TrajetPlusCourt(Ville depart, Ville arrivee)
{
    List<Ville> villesVisitees = new List<Ville>();
    List<Ville> villesNonVisitees = new List<Ville>();
    Dictionary<Ville, Ville> predecesseurs = new Dictionary<Ville, Ville>();
    Dictionary<Ville, int> distances = new Dictionary<Ville, int>();

    villesNonVisitees.Add(depart);
    distances.Add(depart, 0);

    while (villesNonVisitees.Count > 0)
    {
        Ville villeCourante = villesNonVisitees.OrderBy(v => distances[v]).First();
        villesNonVisitees.Remove(villeCourante);
        villesVisitees.Add(villeCourante);

        foreach (Livraison livraison in livraisons)
        {
            if (livraison.VilleDepart == villeCourante)
            {
                if (!villesVisitees.Contains(livraison.VilleArrivee))
                {
                    villesNonVisitees.Add(livraison.VilleArrivee);
                    if (!distances.ContainsKey(livraison.VilleArrivee))
                    {
                        distances.Add(livraison.VilleArrivee, int.MaxValue);
                    }
                    if (distances[villeCourante] + 1 < distances[livraison.VilleArrivee])
                    {
                        distances[livraison.VilleArrivee] = distances[villeCourante] + 1;
                        predecesseurs[livraison.VilleArrivee] = villeCourante;
                    }
                }
            }
        }
    }

    List<Ville> trajet = new List<Ville>();
    Ville ville = arrivee;
    while (ville != depart)
    {
        trajet.Add(ville);
        ville = predecesseurs[ville];
    }
    trajet.Add(depart);
    trajet.Reverse();

    return trajet;
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