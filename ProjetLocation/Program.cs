using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetLocation.dao;
using ProjetLocation.dto;

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
            Application.Run(new Form1());

            //MembreDAO membreDAO = new MembreDAO();
            //MembreDTO m = new MembreDTO();
            //m.idMembre = 1;
            //m.nom = "Franz";
            //m.telephone = "5142345678";
            //m.email = "franz.net";
            //m.adresse = "13 rue Bj";
            //m.nbLocation = 4;

            //int n = membreDAO.Add(m);
            //m = membreDAO.Read(3);
            //int n = membreDAO.Update(m);
            //Console.WriteLine();
            //Console.Read();
        }

       
    }
}
