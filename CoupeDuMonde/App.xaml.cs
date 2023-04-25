using CoupeDuMonde.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Data.SqlClient;
using CoupeDuMonde.classes;

namespace CoupeDuMonde
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //ENVOYER DANS LA BASE LORS DE LA FERMETURE DE L4APPLICATIOn
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //List<> Temporaires pour envoi dans la base
            List<CoupeDuMonde.classes.User> TempSaveUsers = new List<CoupeDuMonde.classes.User>();
            TempSaveUsers = CoupeDuMonde.MainWindow.us;
            List<CoupeDuMonde.classes.Classroom> TempSaveClassrooms = new List<CoupeDuMonde.classes.Classroom>();
            TempSaveClassrooms = CoupeDuMonde.MainWindow.cl;
            List<CoupeDuMonde.classes.Bet> TempSaveBet = new List<CoupeDuMonde.classes.Bet>();
            foreach (CommonBet Super in CoupeDuMonde.MainWindow.betcl)
            {
                TempSaveBet.Add(Super as Bet);
            }
            foreach (SpecialBet Superg in CoupeDuMonde.MainWindow.betsp)
            {
                TempSaveBet.Add(Superg as SpecialBet);
            }
            //TempSaveBet = CoupeDuMonde.MainWindow.be;
            


            Ado.open();

            try
            {
                
                //Supprime toute la base de données
                SqlCommand cmdq = new SqlCommand("DELETE FROM parisusers");
                cmdq.Connection = Ado.conn;
                cmdq.ExecuteNonQuery();
                
                SqlCommand cmdw = new SqlCommand("DELETE FROM paris");
                cmdw.Connection = Ado.conn;
                cmdw.ExecuteNonQuery();
                
                SqlCommand cmd1 = new SqlCommand("DELETE FROM users");
                cmd1.Connection = Ado.conn;
                cmd1.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("DELETE FROM promotions");
                cmd.Connection = Ado.conn;
                cmd.ExecuteNonQuery();
                

                //Reinitialise les incrémentations à 0
                
                SqlCommand cmda = new SqlCommand("DBCC CHECKIDENT(users, RESEED, 0)");
                cmda.Connection = Ado.conn;
                cmda.ExecuteNonQuery();

                SqlCommand cmdt = new SqlCommand("DBCC CHECKIDENT(promotions, RESEED, 0)");
                cmdt.Connection = Ado.conn;
                cmdt.ExecuteNonQuery();
                
                SqlCommand cmdee = new SqlCommand("DBCC CHECKIDENT(paris, RESEED, 0)");
                cmdee.Connection = Ado.conn;
                cmdee.ExecuteNonQuery();
                
                //INSERT LES PROMOTIONS DANS LA BASE
                foreach (CoupeDuMonde.classes.Classroom c in TempSaveClassrooms)
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO promotions (name) VALUES (@1);SELECT @@IDENTITY");
                    cmd2.Connection = Ado.conn;
                    cmd2.Parameters.Add(new SqlParameter("1", c.Name));
                    //cmd2.ExecuteNonQuery();
                    c.Id = Convert.ToInt32(cmd2.ExecuteScalar());
                }

                try
                {
                    //INSERT LES USERS DANS LA BASE
                    foreach (CoupeDuMonde.classes.User u in TempSaveUsers)
                    {
                        SqlCommand cmd3 = new SqlCommand("INSERT INTO users (name,lastname,username,isplayer,idpromotion,points) VALUES (@1,@2,@3,@4,@5,@6)");
                        cmd3.Connection = Ado.conn;
                        cmd3.Parameters.Add(new SqlParameter("1", u.Name));
                        cmd3.Parameters.Add(new SqlParameter("2", u.LastName));
                        cmd3.Parameters.Add(new SqlParameter("3", u.UserName));
                        cmd3.Parameters.Add(new SqlParameter("4", u.IsPlayer));
                        cmd3.Parameters.Add(new SqlParameter("5", u.Classroom.Id));
                        cmd3.Parameters.Add(new SqlParameter("6", u.Points));
                        cmd3.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
                try
                {
                    //INSERT DES PARIS DANS LA BASE
                    foreach (CoupeDuMonde.classes.Bet b in TempSaveBet)
                    {
                        SqlCommand cmd6 = new SqlCommand("INSERT INTO paris (heading,maxpoints,deadline,score,discriminant,isdeathmatch,penalty,gap) VALUES (@1,@2,@3,@4,@5,@6,@7,@8)");
                        cmd6.Connection = Ado.conn;
                        cmd6.Parameters.Add(new SqlParameter("1", b.Heading));
                        cmd6.Parameters.Add(new SqlParameter("2", b.MaxPoints));
                        cmd6.Parameters.Add(new SqlParameter("3", b.DeadLine));
                        cmd6.Parameters.Add(new SqlParameter("4", b.Score));
                        cmd6.Parameters.Add(new SqlParameter("5", b.Discriminant));
                        cmd6.Parameters.Add(new SqlParameter("6", b.IsDeathMatch));
                        cmd6.Parameters.Add(new SqlParameter("7", b.Penalty));
                        cmd6.Parameters.Add(new SqlParameter("8", b.Gaps));
                        cmd6.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.ToString());
            }

            Ado.close();
        }
    }
}
