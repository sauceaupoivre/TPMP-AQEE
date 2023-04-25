using CoupeDuMonde.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.DirectoryServices;
using System.Configuration;

namespace CoupeDuMonde.Models
{
    public class AdoUser : Ado
    {
        public static string GetCurrentDomainPath()
        {
            //DirectoryEntry de = new DirectoryEntry("LDAP://RootDSE");
            //return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString();
            return "";
        }

        public static List<User> GetAll()
        {
            List<Classroom> classrooms=AdoClassroom.GetAll();
            List<User> users = new List<User>();
            Ado.open();
            SqlCommand command = new SqlCommand("SELECT * FROM users");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id =Convert.ToInt32(reader["idpromotion"]);
                /*foreach (Classroom classroom in classrooms)
                {
                    if (classroom.Id==id)
                    {
                        User user = new User(Convert.ToString(reader["name"]), Convert.ToString(reader["lastname"]), Convert.ToString(reader["username"]), Convert.ToString(reader["email"]), Convert.ToInt32(reader["isplayer"]));
                        classroom.AddUser(user);
                        users.Add(user);
                    }
                }*/
                Classroom p = CoupeDuMonde.MainWindow.cl.Where(c => c.Id == id).First();
                User user = new User(Convert.ToString(reader["name"]), Convert.ToString(reader["lastname"]), Convert.ToString(reader["username"]), Convert.ToString(reader["email"]), Convert.ToInt32(reader["isplayer"]));
                if (reader["points"] != null || reader["points"] != DBNull.Value)
                {
                    user.Points = Convert.ToInt32(reader["points"]);
                }
                p.AddUser(user);
                users.Add(user);
            }
            
            reader.Close();
            Ado.close();

            return users;
        }

       
    }


    
}
