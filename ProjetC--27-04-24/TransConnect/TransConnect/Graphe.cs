using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Graphe
    {
        Dictionary<string, HashSet<Route>> routesDepuisVille = new Dictionary<string, HashSet<Route>>();

        internal Graphe()
        {
            routesDepuisVille = new Dictionary<string, HashSet<Route>>();
        }
        

        internal void AjoutRoute(string villeDepart, string villeArrivee, TimeSpan duree, int distance)
        {
            if (!routesDepuisVille.ContainsKey(villeDepart))
            {
                routesDepuisVille[villeDepart] = new HashSet<Route>();
            }
            if (!routesDepuisVille.ContainsKey(villeArrivee))
            {
                routesDepuisVille[villeArrivee] = new HashSet<Route>();
            }
            routesDepuisVille[villeArrivee].Add(new Route(villeDepart, distance, duree));
            routesDepuisVille[villeDepart].Add(new Route(villeArrivee, distance, duree));
        }











        /// <summary>
        /// Algorithme de Dijkstra 
        /// </summary>
        /// <param name="villeDepart"></param>
        /// <param name="villeArrivee"></param>
        /// <returns>distance minimale entre deux villes, liste des villes à parcourir dans l'ordre </returns>
        public (int, List<string>) CalculDistanceEtChemin(string villeDepart, string villeArrivee)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            Dictionary<string, string> previous = new Dictionary<string, string>();
            List<KeyValuePair<string, int>> queue = new List<KeyValuePair<string, int>>();

            foreach (string ville in routesDepuisVille.Keys)
            {
                if (ville == villeDepart)
                {
                    distances[ville] = 0;
                    queue.Add(new KeyValuePair<string, int>(ville, 0));
                }
                else
                {
                    distances[ville] = int.MaxValue;
                }
            }

            while (queue.Count > 0)
            {
                var smallestPair = queue.OrderBy(x => x.Value).First();
                queue.Remove(smallestPair);
                string smallest = smallestPair.Key;

                if (smallest == villeArrivee)
                {

                    List<string> chemin = ReconstituerChemin(previous, villeArrivee, villeDepart);
                    return (distances[smallest], chemin);
                }

                foreach (var neighbor in routesDepuisVille[smallest])
                {
                    int alt = distances[smallest] + neighbor.Distance;
                    if (alt < distances[neighbor.Destination])
                    {
                        distances[neighbor.Destination] = alt;
                        queue.Add(new KeyValuePair<string, int>(neighbor.Destination, alt));
                        previous[neighbor.Destination] = smallest;
                    }
                }
            }


            return (distances[villeArrivee], new List<string>());
        }


        private List<string> ReconstituerChemin(Dictionary<string, string> previous, string villeDepart, string villeArrivee)
        {
            List<string> chemin = new List<string>();
            string current = villeArrivee;

            while (current != villeDepart)
            {
                chemin.Add(current);
                current = previous[current];
            }
            chemin.Add(villeDepart); 
            chemin.Reverse(); 

            return chemin;
        }



        /// <summary>
        /// Algorithme de Dijkstra 
        /// </summary>
        /// <param name="villeDepart"></param>
        /// <param name="villeArrivee"></param>
        /// <returns>durée minimale et liste des villes à parcourir dans l'ordre</returns>
        public (int, List<string>) CalculDureeMinimaleEtChemin(string villeDepart, string villeArrivee)
        {
            Dictionary<string, TimeSpan> durees = new Dictionary<string, TimeSpan>();
            Dictionary<string, string> previous = new Dictionary<string, string>();
            List<KeyValuePair<string, TimeSpan>> queue = new List<KeyValuePair<string, TimeSpan>>();
            foreach (string ville in routesDepuisVille.Keys)
            {
                if (ville == villeDepart)
                {
                    durees[ville] = TimeSpan.Zero;
                    queue.Add(new KeyValuePair<string, TimeSpan>(ville, TimeSpan.Zero));
                }
                else
                {
                    durees[ville] = TimeSpan.MaxValue;
                }
            }

            while (queue.Count > 0)
            {
                var smallestPair = queue.OrderBy(x => x.Value).First();
                queue.Remove(smallestPair);
                string smallest = smallestPair.Key;

                if (smallest == villeArrivee)
                {
                    List<string> chemin = ReconstituerChemin(previous, villeDepart, villeArrivee);
                    return ((int)durees[smallest].TotalMinutes, chemin);
                }

                foreach (var neighbor in routesDepuisVille[smallest])
                {
                    TimeSpan alt = durees[smallest] + neighbor.Duree;
                    if (alt < durees[neighbor.Destination])
                    {
                        durees[neighbor.Destination] = alt;
                        queue.Add(new KeyValuePair<string, TimeSpan>(neighbor.Destination, alt));
                        previous[neighbor.Destination] = smallest;
                    }
                }
            }

            return ((int)durees[villeArrivee].TotalMinutes, new List<string>());
        }




    }


}
}
