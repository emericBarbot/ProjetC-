using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Route
    {
        public Ville ville1;
        public Ville ville2;
        public int distance;
        public TimeSpan duree;

        public Route(Ville ville1, Ville ville2, int distance, TimeSpan duree)
        {
            this.ville1 = ville1;
            this.ville2 = ville2;
            this.distance = distance;
            this.duree = duree;
        }
        public Ville Ville1
        {
            get { return ville1; }
            set { ville1 = value; }
        }
        public Ville Ville2
        {
            get { return ville2; }
            set { ville2 = value; }
        }
            

     }
}
