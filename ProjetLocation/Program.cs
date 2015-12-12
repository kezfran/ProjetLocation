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

            FactureService fact = new FactureService();
            FactureDTO f = new FactureDTO();

            List<FactureDTO> list = fact.FindByEmploye(1);

            Console.WriteLine(list.Count);
            Console.Read();
        }

       
    }
}
