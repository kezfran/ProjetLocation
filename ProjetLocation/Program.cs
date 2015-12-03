using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetLocation.dao;
using ProjetLocation.dto;
using ProjetLocation.service.implementations;

namespace ProjetLocation
{
    static class Program
    {
       
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //VoitureService voitureService = new VoitureService();
            //VoitureDTO v = new VoitureDTO();

            MembreService membre = new MembreService();
            MembreDTO m = new MembreDTO();

            m.email = "af.net";
            m.adresse = "23 rue jka";
            m.nbLocation = 0;
            m.nom = "af";
            m.telephone = "5141234567";



            Console.WriteLine();
            Console.Read();
        }

       
    }
}
