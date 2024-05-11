using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Route
    {
        public string destination;
        public int distance;
        public TimeSpan duree;

        public Route(string destination, int distance, TimeSpan duree)
        {
            this.destination = destination;
            this.distance = distance;
            this.duree = duree;
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public TimeSpan Duree
        {
            get { return duree; }
            set { duree = value; }
        }

     }
}
