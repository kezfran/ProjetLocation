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

            LocationService location = new LocationService();
            LocationDTO l = new LocationDTO();
            MembreDTO m = new MembreDTO();
            VoitureDTO v = new VoitureDTO();

            //l.IdLocation = 1;
            //m.idMembre = 1;
            //v.idVoiture = 1;

            //l.MembreDTO = m;
            //l.VoitureDTO = v;
            //l.DateLocation = DateTime.Now;
            //l.DateRetour = DateTime.Now;

            l = location.ReadLocation(1);

            Console.WriteLine(l.IdLocation + " " + l.MembreDTO +" " + l.VoitureDTO + " " + l.DateLocation + " " + l.DateRetour);
            Console.Read();
        }

       
    }
}
