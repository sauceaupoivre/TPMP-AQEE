using CoupeDuMonde.classes;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoupeDuMonde
{
    /// <summary>
    /// Logique d'interaction pour Pari.xaml
    /// </summary>
    public partial class Bet_Page : Page
    {
        List<CommonBet> Liste = new List<CommonBet>();
        List<SpecialBet> Liste_defis = new List<SpecialBet>();
		public Bet_Page()
        {
            InitializeComponent();
            list.ItemsSource = MainWindow.betcl;
            liste_defis.ItemsSource = MainWindow.betsp;
		}

        private void btn_addbet_Click(object sender, RoutedEventArgs e)
        {
            main.Opacity = 0.5;
            main.IsEnabled = false;
            edit_bet.IsEnabled = false;
            edit_bet.Opacity = 0.5;
            add_bet.Visibility = Visibility.Visible;
        }

        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {


            add_bet.Visibility = Visibility.Hidden;
            main.Visibility = Visibility.Visible;
            main.IsEnabled = true;
            main.Opacity = 100;
            edit_bet.IsEnabled = true;
            edit_bet.Opacity = 100;
        }

        private void btn_defis_Click(object sender, RoutedEventArgs e)
        {
            main.Opacity = 0.5;
            main.IsEnabled = false;
            edit_bet.IsEnabled = false;
            edit_bet.Opacity = 0.5;
            add_challenge.Visibility = Visibility.Visible;
        }

        private void btn_annuler_challenge_Click(object sender, RoutedEventArgs e)
        {

            add_challenge.Visibility = Visibility.Hidden;
            main.Visibility = Visibility.Visible;
            main.IsEnabled = true;
            main.Opacity = 100;
            edit_bet.IsEnabled = true;
            edit_bet.Opacity = 100;
        }

        private void btn_create_bet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nom = txtbox_libelle.Text;
                DateTime date = Convert.ToDateTime(tb_dates.Text);
                int point = Convert.ToInt32(txtbox_point.Text);
                bool cool = IsEliminatoire.IsEnabled;
                //CommonBet z = new CommonBet(nom, point, date);
                CommonBet z = new CommonBet(nom, point, date, cool);
                //Liste.Add(z);
                MainWindow.betcl.Add(z);
                list.Items.Refresh();
                //list.ItemsSource = Liste;
                list.Items.Refresh();
                add_bet.Visibility = Visibility.Hidden;
                main.Visibility = Visibility.Visible;
                main.IsEnabled = true;
                main.Opacity = 100;
                edit_bet.IsEnabled = true;
                edit_bet.Opacity = 100;
            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}

		}

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem as Bet != null)
            {
                var i = Convert.ToString((list.SelectedItem as Bet).Heading);
                txtbox_equipe.Text = i;
                var w = Convert.ToString((list.SelectedItem as Bet).MaxPoints);
                txtbox_points.Text = w;
                var z = Convert.ToString((list.SelectedItem as Bet).DeadLine);
                bt_date.Text = z;
               
            }
            else
            {
                MessageBox.Show("Aucune valeur Sélectionné");
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            list.Visibility = Visibility.Visible;
            list.IsEnabled = true;
            liste_defis.Visibility = Visibility.Hidden;
            liste_defis.IsEnabled = false;
            list.Opacity = 1;
            liste_defis.Opacity = 0;
            list.Items.Refresh();
            edit_challenge.Visibility = Visibility.Hidden;
            edit_challenge.IsEnabled = false;
            edit_bet.Visibility = Visibility.Visible;
            edit_bet.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            list.Visibility = Visibility.Hidden;
            list.IsEnabled = false;
            liste_defis.Visibility = Visibility.Visible;
            liste_defis.IsEnabled = true;
            list.Opacity = 0;
            liste_defis.Opacity = 1;
            edit_bet.Visibility = Visibility.Hidden;
            edit_bet.IsEnabled = false;
            edit_challenge.Visibility = Visibility.Visible;
            edit_challenge.IsEnabled = true;
            liste_defis.Items.Refresh();
        }

        private void btn_valider_defis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime d = Convert.ToDateTime(txt_bts.Text);
                string a = txt_libelle.Text;
                int point = Convert.ToInt32(txt_point.Text);
                int tranch = Convert.ToInt32(txt_tranche.Text);
                int ecart = Convert.ToInt32(txt_ecart.Text);
                //  SpecialBet z = new SpecialBet(a,point,d,"s",tranch,ecart);
                SpecialBet p = new SpecialBet(a, point, d, tranch, ecart);
                //Liste_defis.Add(z);
                //liste_defis.ItemsSource = Liste_defis;
                MainWindow.betsp.Add(p);

                liste_defis.Items.Refresh();
                add_challenge.Visibility = Visibility.Hidden;
                main.Visibility = Visibility.Visible;
                main.IsEnabled = true;
                main.Opacity = 100;
                edit_bet.IsEnabled = true;
                edit_bet.Opacity = 100;
            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
		}

        private void Liste_defis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (liste_defis.SelectedItem as SpecialBet != null)
            {
                var a = Convert.ToString((liste_defis.SelectedItem as Bet).Heading);
                txtbox_libelle1.Text = a;
                var b = Convert.ToString((liste_defis.SelectedItem as Bet).MaxPoints);
                txtbox_pointpossible.Text = b;
                var c = Convert.ToString((liste_defis.SelectedItem as SpecialBet).Penalty);
                txtbox_tranche.Text = c;
                var y = Convert.ToString((liste_defis.SelectedItem as SpecialBet).Gap);
                txtbox_ecrat.Text = y;
                var f = Convert.ToString((liste_defis.SelectedItem as Bet).DeadLine);
                tbx_date.Text = f;
            }
            else
            {
                MessageBox.Show("Aucune valeur Sélectionné");
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    if (list.SelectedItem != null)
                    {
                        (list.SelectedItem as Bet).Heading = txtbox_equipe.Text;
                        (list.SelectedItem as Bet).MaxPoints = Convert.ToInt32(txtbox_points.Text);
                        (list.SelectedItem as Bet).DeadLine = Convert.ToDateTime(bt_date.Text);
                        MessageBox.Show("Modifications apportée");

                        list.Items.Refresh();
                    }
                    else if (liste_defis.SelectedItem != null)
                    {
                        (liste_defis.SelectedItem as SpecialBet).Heading = txtbox_libelle1.Text;
                        (liste_defis.SelectedItem as SpecialBet).MaxPoints = Convert.ToInt32(txtbox_pointpossible.Text);
                        (liste_defis.SelectedItem as SpecialBet).Penalty = Convert.ToInt32(txtbox_tranche.Text);
                        (liste_defis.SelectedItem as SpecialBet).Gap = Convert.ToInt32(txtbox_ecrat.Text);
                        (liste_defis.SelectedItem as SpecialBet).DeadLine = Convert.ToDateTime(tbx_date.Text);
                        MessageBox.Show("Modifications apportée");

                        liste_defis.Items.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }
	}
}
