using CoupeDuMonde.classes;
using CoupeDuMonde.Models;
using CoupeDuMonde.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CoupeDuMonde
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     
    public partial class MainWindow 
    {
        //LA FONCTION SAVE SE TROUVE DANS APP.xaml.cs

        public static List<Classroom> cl = new List<Classroom>();
        public static List<User> us = new List<User>();
        public static List<Bet> be = new List<Bet>();
        public static List<CommonBet> betcl = new List<CommonBet>();
        public static List<SpecialBet> betsp = new List<SpecialBet>();
        public MainWindow()
        {
           InitializeComponent();
            cl = AdoClassroom.GetAll();
            us = AdoUser.GetAll();
            betcl = AdoBet.GetAllCl();
            betsp = AdoBet.GetAllSb();
            foreach (CommonBet b in betcl)
            {
                be.Add(b);
            }
            foreach(SpecialBet c in betsp)
            {
                be.Add(c);
            }

            //IEnumerable<Bet> query = be.OrderBy(a => a.Id);
            //LINQ ORDER BY
            var orderById = from b in be
                                orderby b.Id
                                select b;
            be = null;
            be = orderById.ToList();

            //CALCUL des points des classes
            foreach (Classroom c in MainWindow.cl)
            {
                foreach (User u in c.Users)
                {
                    c.ClassPoints = c.ClassPoints + u.Points;
                }
            }

            this.Content = new Home_Page();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ado.open();
                MessageBox.Show("Connexion réussi");


            }
            catch
            {
                MessageBox.Show("Erreur de lors de la connexion");
            }
        }

        private void BtnPari_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Bet_Page();

        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new User_Page();

        }

        private void BtnClassement_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Classement();

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Home_Page();
        }

        private void Btn_Test_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Test();

        }

    }
}
