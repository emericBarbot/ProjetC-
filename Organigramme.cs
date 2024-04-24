using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnect
{
    internal class Organigramme
    {
        Employe chef;
        internal Employe Chef { get => chef; }

        internal Organigramme(Employe chef)
        {
            this.chef = chef;
        }
        internal void AddManager(Employe manager, Employe newManager)
        {
            manager.Subordonnes.Add(newManager);
            newManager.Manager = manager;
        }

        internal void AfficherOrganigramme()
        {
            AfficherRecursif(Chef, 0);
        }

        internal void AfficherRecursif(Employe employe, int niveau)
        {
            if (employe == null)
                return;

            Console.WriteLine($"{new string(' ', niveau * 4)}{employe.Nom} - {employe.Poste}");

            foreach (var subordonne in employe.Subordonnes)
            {
                AfficherRecursif(subordonne, niveau + 1);
            }
        }

        public void SupprimerEmploye(Employe manager)
        {
            if (manager == null || manager == Chef)
            {
                Console.WriteLine("Impossible de supprimer le chef de l'organigramme.");
                return;
            }

            SupprimerEmployeRecursif(Chef, manager);
        }
        private void SupprimerEmployeRecursif(Employe employe, Employe manager)
        {
            if (employe == null)
                return;

            // Vérifier si le manager est un subordonné de l'employé actuel
            if (employe.Subordonnes.Contains(manager))
            {
                // Retirer le manager de la liste des subordonnés
                employe.Subordonnes.Remove(manager);

                // Réassigner les subordonnés du manager à l'employé actuel
                foreach (var subordonne in manager.Subordonnes)
                {
                    employe.Subordonnes.Add(subordonne);
                }

                // Retirer les subordonnés du manager
                manager.Subordonnes.Clear();

                return;
            }

            // Parcourir récursivement les subordonnés de l'employé actuel
            foreach (var subordonne in employe.Subordonnes)
            {
                SupprimerEmployeRecursif(subordonne, manager);
            }
        }

        //Affichage de l'organigramme avec des rectangles pour chaque employé et les liens entre eux
        internal void AffichageOrganigramme(Employe root, int level = 0)
        {
            if (root == null)
                return;

            Console.WriteLine($"{new string(' ', level * 4)}{root.Nom} - {root.Poste}");

            foreach (var subordinate in root.Subordonnes)
            {
                AffichageOrganigramme(subordinate, level + 1);
            }
        }
    }
}
