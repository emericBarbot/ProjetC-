using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TransConnect
{
    [TestClass]
    public class TestChauffeur

    {
        Chauffeur chauffeur1 = new Chauffeur("emeric", "Dupont", "123456789", "123 porte de l eglise", "emeric@example.com",
                                       "555-1234", new DateTime(1980, 5, 15), "Driver", 50000.0, new DateTime(2020, 1, 1));
        Chauffeur chauffeur2 = new Chauffeur("jean", "Simon", "123456789", "123 porte de l eglise", "emeric@example.com",
                                       "555-1234", new DateTime(1980, 5, 15), "Driver", 50000.0, new DateTime(2020, 1, 2));
        HashSet<DateTime> calendrier = new HashSet<DateTime>(new DateTime[] { new DateTime(2020, 1, 2) });
        
        
        [TestMethod]
        public void TestDiponibiliteChauffeur()
        {
            Assert.AreEqual(chauffeur1.disponibiliteChauffeur(new DateTime(2020, 1, 2)), false);
            Assert.AreEqual(chauffeur2.disponibiliteChauffeur(new DateTime(2020, 1, 2)), true);

        }
        public void TestAjoutChauffeur()
        {


        }
    }
}