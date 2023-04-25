using CoupeDuMonde.classes;
using CoupeDuMonde.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Page = System.Windows.Controls.Page;

namespace CoupeDuMonde
{
    /// <summary>
    /// Logique d'interaction pour Utilisateurs.xaml
    /// </summary>
    public partial class User_Page : Page
    { 
        public User_Page()
        {
            InitializeComponent();
            list.ItemsSource=MainWindow.us;
            list.Items.Refresh();
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Grid_Creation.IsEnabled = true;
            Grid_Creation.Visibility = Visibility.Visible;
            liste_Aj.ItemsSource = MainWindow.cl;
            Grid_Basic.Opacity = 0.5;
            list.IsEnabled = false;
        }

        private void btn_Cancelled_Click(object sender, RoutedEventArgs e)
        {
            Grid_Creation.Visibility = Visibility.Hidden;
            Grid_Basic.Opacity = 1;
            list.IsEnabled = true;
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBox_FirstName.Text;
            string surname = txtBox_Lastname.Text;
            string email = txtBox_Email.Text;
            string username = txtBox_Username.Text;
            int d;
            // à fixe
            if (checkBox_Player.IsChecked==true){
                d = 1;
            }
            else
            {
                d = 0;
            }
            Random rnd = new Random();
            string password= Convert.ToString(rnd.Next(25345, 99860));
            User t = new User(name,surname,username,email,password,d,0,(liste_Aj.SelectedItem as Classroom));
            if (liste_Aj.SelectedItem as Classroom!=null)
            {
                (liste_Aj.SelectedItem as Classroom).Users.Add(t);
                MainWindow.us.Add(t);
            }
            else
            {
                MessageBox.Show("Pas de classe sélectionnée");
            }
            
            list.ItemsSource = MainWindow.us;
            list.Items.Refresh();
            Grid_Creation.Visibility = Visibility.Hidden;
            Grid_Creation.IsEnabled = false;
            Grid_Basic.Opacity = 1;
            list.IsEnabled = true;
        }

        private void True(object sender, RoutedEventArgs e)
        {

        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Êtes vous sûr ?","Attention", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow.us.Remove(list.SelectedItem as User);
                list.Items.Refresh();
            }       
        }

        private void btn_modif_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem ==null)
            {
                MessageBox.Show("Aucune valeur Sélectionné");
            }
            else
            {
                Grid_Modif.IsEnabled = true;
                Grid_Modif.Visibility = Visibility.Visible;
                liste_Aj.ItemsSource = MainWindow.cl;
                Grid_Basic.Opacity = 0.5;
                list.IsEnabled = false;
                txtBox_FirstNameModif.Text = Convert.ToString((list.SelectedItem as User).Name);
                txtBox_LastnameModif.Text = Convert.ToString((list.SelectedItem as User).LastName);
                txtBox_EmailModif.Text = Convert.ToString((list.SelectedItem as User).Email);
                txtBox_ModifUsername.Text = Convert.ToString((list.SelectedItem as User).UserName);
                if ((list.SelectedItem as User).IsPlayer==1)
                {
                    checkBox_PlayerModif.IsChecked = true;
                }
                liste_AjModif.ItemsSource = MainWindow.cl;
                liste_AjModif.SelectedItem=(list.SelectedItem as User).Classroom;
            }
        }

        private void btn_CancelledModif_Click(object sender, RoutedEventArgs e)
        {
            Grid_Modif.Visibility = Visibility.Hidden;
            Grid_Modif.IsEnabled = false;
            Grid_Basic.Opacity = 1;
            list.IsEnabled = true;
        }

        private void btn_CreateModif_Click(object sender, RoutedEventArgs e)
        {
            string name = txtBox_FirstNameModif.Text;
            string surname = txtBox_LastnameModif.Text;
            string email = txtBox_EmailModif.Text;
            string username = txtBox_ModifUsername.Text;
            int d;
            // à fixe
            if (checkBox_PlayerModif.IsChecked == true)
            {
                d = 1;
            }
            else
            {
                d = 0;
            }
            var i = Convert.ToString((list.SelectedItem as User).Classroom);
            foreach (Classroom u in MainWindow.cl)
            {
                if (u.Name==i)
                {
                    u.Users.Remove(list.SelectedItem as User);
                }
            }
            (list.SelectedItem as User).Classroom = (liste_AjModif.SelectedItem as Classroom);
            (liste_AjModif.SelectedItem as Classroom).Users.Add(list.SelectedItem as User);
            (list.SelectedItem as User).Name = name;
            (list.SelectedItem as User).LastName = surname;
            (list.SelectedItem as User).Email = email;
            (list.SelectedItem as User).UserName = username;
            (list.SelectedItem as User).IsPlayer = d;
            list.ItemsSource = MainWindow.us;
            list.Items.Refresh();
            Grid_Modif.Visibility = Visibility.Hidden;
            Grid_Modif.IsEnabled = false;
            Grid_Basic.Opacity = 1;
            list.IsEnabled = true;
        }
    }
}
