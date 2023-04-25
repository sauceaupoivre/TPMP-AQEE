using CoupeDuMonde.classes;
using CoupeDuMonde.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClosedXML.Excel;
using CoupeDuMonde.Classes;
using static System.Net.WebRequestMethods;
using System.Security.AccessControl;
using System.Security.Principal;
using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace CoupeDuMonde
{
    /// <summary>
    /// Logique d'interaction pour Classement.xaml
    /// </summary>
    public partial class Classement : Page
    {
        public System.Windows.SizeToContent SizeToContent { get; set; }

        List<User> AddedPlayers = new List<User>();
        List<User> BestPlayersList = new List<User>();
        List<Classroom> BestpromosList = new List<Classroom>();

        public Classement()
        {
            InitializeComponent();
            datagrid_classroom.ItemsSource = MainWindow.cl; 
            DataGrid_AllPlayers.ItemsSource = MainWindow.us;

            var BestPlayers = (from user in MainWindow.us
                        orderby user.Points descending
                        select user).Take(10);
            foreach(User user1 in BestPlayers)
            {
                BestPlayersList.Add(user1);
            }
            Datagrid_GlobalRanking.ItemsSource = BestPlayersList;

            var BestPromos = (from classroom in MainWindow.cl
                              orderby classroom.ClassPoints descending
                              select classroom).Take(10);
            foreach (Classroom c in BestPromos)
            {
                BestpromosList.Add(c);
            }
            Datagrid_ClassRanking.ItemsSource = BestpromosList;
        }
      
        private void Btn_AddClassroom_Click(object sender, RoutedEventArgs e)
        {
            Grid_Rank.IsEnabled = false; //La GRID De toute la page
            Grid_Rank.Opacity = 0.5 ;
            Grid_AddClassroom.Visibility = Visibility.Visible; //La GRID d'ajout d'une promotion
        }
        private void Btn_UpdateClassroom_Click(object sender, RoutedEventArgs e)
        {
            Grid_Rank.IsEnabled = false; //La GRID De toute la page
            Grid_Rank.Opacity = 0.5;
            TextBox_UpdatePromoName.Text = Convert.ToString((datagrid_classroom.SelectedItem as Classroom).Name);

            Grid_UpdateClassroom.Visibility = Visibility.Visible;
        }
        private void Btn_CancelUpdateClassroom_Click(object sender, RoutedEventArgs e)
        {
            Grid_Rank.IsEnabled = true;
            Grid_Rank.Opacity = 1;
            Grid_UpdateClassroom.Visibility = Visibility.Collapsed;
        }
        private void TextBox_UpdatePromoName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string previousClassName = Convert.ToString((datagrid_classroom.SelectedItem as Classroom).Name);
            if (TextBox_UpdatePromoName.Text != null && TextBox_UpdatePromoName.Text != previousClassName)
            {
                Btn_SaveUpdateClassroom.IsEnabled = true;
            }
        }

        private void Btn_CancelClassroom_Click(object sender, RoutedEventArgs e)
        {
            Grid_Rank.IsEnabled = true;
            Grid_Rank.Opacity = 1;
            Grid_AddClassroom.Visibility = Visibility.Collapsed;
        }
        private void TextBox_PromoName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Btn_SaveClassroom.IsEnabled = true;
        }

        private void DataGrid_AllPlayers_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Btn_AddPlayers.IsEnabled = true;
        }

        private void Btn_AddPlayers_Click(object sender, RoutedEventArgs e)
        {
            var Query =
                from user in AddedPlayers
                where user == (DataGrid_AllPlayers.SelectedItem as User)
                select user;
           
            if(Query.Count() > 0)
            {
                MessageBox.Show("Ce joueur est déja dans la liste");
            }
            else
            {
                AddedPlayers.Add(DataGrid_AllPlayers.SelectedItem as User);
            }
            Datagrid_AddedPlayers.ItemsSource = AddedPlayers;
            Datagrid_AddedPlayers.Items.Refresh();
        }

        private void Btn_SaveClassroom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBox_PromoName.Text != "")
                {
                    Classroom c;

                    if (AddedPlayers.Count() > 0)
                    {
                        c = new Classroom(MainWindow.cl.Count() + 1,TextBox_PromoName.Text, AddedPlayers);
                        foreach (User player in AddedPlayers)
                        {
                            player.Classroom = c;
                        }
                    }
                    else
                    {
                        
                        c = new Classroom(MainWindow.cl.Count()+1,TextBox_PromoName.Text);
                    }
                    MainWindow.cl.Add(c);
                    AddedPlayers.Clear();
                    Datagrid_AddedPlayers.Items.Refresh();

                    TextBox_PromoName.Text = "";

                    datagrid_classroom.Items.Refresh();

                    Grid_Rank.IsEnabled = true;
                    Grid_Rank.Opacity = 1;
                    Grid_AddClassroom.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Veuillez saisir un nom de promotion");
                }
            }
            catch 
            {
                MessageBox.Show("Erreur");
            }
        }
        private void Btn_SaveUpdateClassroom_Click(object sender, RoutedEventArgs e)
        {
            string className = TextBox_UpdatePromoName.Text;
            (datagrid_classroom.SelectedItem as Classroom).Name = className;
            
            datagrid_classroom.Items.Refresh();
            Grid_Rank.IsEnabled = true;
            Grid_Rank.Opacity = 1;
            Grid_UpdateClassroom.Visibility = Visibility.Collapsed;

        }

        private void datagrid_classroom_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Btn_DeleteClassroom.IsEnabled = true;
            Btn_UpdateClassroom.IsEnabled = true;
        }

        private void Btn_DeleteClassroom_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Etes vous sur ?", "Attention", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if ((datagrid_classroom.SelectedItem as Classroom).Users.Count>0)
                {
                    MessageBox.Show("Erreur, vous ne pouvez pas supprimer une promotion contenant des joueurs");
                }
                else
                {
                    MainWindow.cl.Remove(datagrid_classroom.SelectedItem as Classroom);
                    datagrid_classroom.Items.Refresh();
                }
            }
        }

        //EXPORT Global Ranking
        private void Btn_ExportGlobal_Click(object sender, RoutedEventArgs e)
        {
            ListToDataTable converter = new ListToDataTable();
            DataTable dt = converter.ToDataTable(BestPlayersList);
            
            string now = DateTime.Now.ToString("dd-MM-yy");

            using (XLWorkbook wb = new XLWorkbook())
            {
                string MainPath = System.IO.Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                string SavePath = MainPath + "Export_Meilleurs_Joueurs_" + now +".xlsx";
                
                try
                {
                    wb.Worksheets.Add(dt, "Export_Meilleurs_Joueurs");
                    wb.SaveAs(SavePath);
                    MessageBox.Show("Exporté avec succès vers "+MainPath);
                }
                catch
                {
                    MessageBox.Show("Erreur, vous n'avez pas les permissions requises, vous devez lancer le programme en mode admin");
                }
             }
        }

        private void Btn_ExportClassrooms_Click(object sender, RoutedEventArgs e)
        {
            ListToDataTable converter = new ListToDataTable();
            DataTable dt = converter.ToDataTable(BestpromosList);

            string now = DateTime.Now.ToString("dd-MM-yy");

            using (XLWorkbook wb = new XLWorkbook())
            {
                string MainPath = System.IO.Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                string SavePath = MainPath + "Export_Meilleurs_Promos_" + now + ".xlsx";

                try
                {
                    wb.Worksheets.Add(dt, "Export_Meilleurs_Promos");
                    wb.SaveAs(SavePath);
                    MessageBox.Show("Exporté avec succès vers " + MainPath);
                }
                catch
                {
                    MessageBox.Show("Erreur, vous n'avez pas les permissions requises, vous devez lancer le programme en mode admin");
                }
            }
        }

       
    }
}
