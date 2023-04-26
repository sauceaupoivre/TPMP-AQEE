using CoupeDuMonde.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.DirectoryServices;
using System.Windows;


namespace CoupeDuMonde.Models
{
    public class AdoClassroom : Ado
    {

        public static string GetCurrentDomainPath()
        {
            try

            { 
                DirectoryEntry Ldap = new DirectoryEntry("LDAP://SISRbest.local","SLAMAmaury","chefadmin321%");
                return "LDAP://SISRbest.local" + Ldap.Properties["defaultNamingContext"][0].ToString();
                
            }
            catch (Exception Ex)

            {

                Console.WriteLine(Ex.Message);
                return "";

            }

        }

        public static List<Classroom> GetAll()
        {
            List<Classroom> classrooms = new List<Classroom>();
            Ado.open();
            SqlCommand command = new SqlCommand("SELECT * FROM promotions");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                classrooms.Add(new Classroom(Convert.ToInt32(reader["id"]),Convert.ToString(reader["name"])));
            }

            reader.Close();
            Ado.close();

            return classrooms;
        }
        public static void AddPromotion(Classroom classroom)
        {
            MainWindow.cl.Add(classroom);
        }


    }
}
