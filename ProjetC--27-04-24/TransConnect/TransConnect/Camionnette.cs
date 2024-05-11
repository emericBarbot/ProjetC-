using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Camionnette:Vehicule
    {
        string usage;
        public Camionnette(string marque, string immatriculation, int annee, DateTime dateAchat, DateTime dernierControle, string usage) : base(marque, immatriculation, annee, dateAchat, dernierControle)
        {
            this.usage = usage;
        }
        public string Usage
        {
            get { return usage; }
            set { usage = value; }
        }
    }
}
