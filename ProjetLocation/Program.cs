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

            VoitureService voiture = new VoitureService();
            VoitureDTO v = new VoitureDTO();

            int n = voiture.DeleteVoiture(2);
            //List<VoitureDTO> liste = voiture.GetAllVoitures();

            Console.WriteLine(n);
            Console.Read();
        }

       
    }
}
