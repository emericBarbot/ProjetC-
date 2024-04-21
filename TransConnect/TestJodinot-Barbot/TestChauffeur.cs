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

        [TestMethod]
        public void TestAjoutChauffeur()
        {


        }

        [TestMethod]
        public void TestAttributionTauxHoraireParGrille()
        {

            DateTime dateEmbauchePlusDeUnAn = DateTime.Now.AddYears(-2);
            DateTime dateEmbauchePlusDeTroisAns = DateTime.Now.AddYears(-4);
            DateTime dateEmbauchePlusDeCinqAns = DateTime.Now.AddYears(-6);

            Chauffeur chauffeurPlusDeUnAn = new Chauffeur("Test", "Test", "Test", "Testt", "TeTestom", "Test", DateTime.Now, "Test", 12, dateEmbauchePlusDeUnAn);
            Chauffeur chauffeurPlusDeTroisAns = new Chauffeur("Test", "Test", "Test", "Testt", "TeTestom", "Test", DateTime.Now, "Test", 12, dateEmbauchePlusDeTroisAns);
            Chauffeur chauffeurPlusDeCinqAns = new Chauffeur("Test", "Test", "Test", "Testt", "TeTestom", "Test", DateTime.Now, "Test", 12, dateEmbauchePlusDeCinqAns);

            Assert.AreEqual(12.60, chauffeurPlusDeUnAn.AttributionTauxHoraireParGrille(), 0.01);
            Assert.AreEqual(13.20, chauffeurPlusDeTroisAns.AttributionTauxHoraireParGrille(), 0.01);
            Assert.AreEqual(14.40, chauffeurPlusDeCinqAns.AttributionTauxHoraireParGrille(), 0.01);
        }

}
}