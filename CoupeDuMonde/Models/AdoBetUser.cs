using CoupeDuMonde.classes;
using CoupeDuMonde.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CoupeDuMonde.Models
{
    public class AdoBetUser : Ado
    {
        public static List<BetUser> GetAll()
        {
            List <BetUser> betsusers = new List<BetUser>();
            Ado.open();
            SqlCommand command = new SqlCommand("SELECT * FROM parisusers");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                betsusers.Add(new BetUser(Convert.ToInt32(reader["iduser"]), Convert.ToInt32(reader["idpari"]), Convert.ToInt32(reader["bet"])));
            }

            reader.Close();
            Ado.close();

            return betsusers;
        }
        

    }
}
