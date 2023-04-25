using CoupeDuMonde.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Data;
using System.Data.Common;

namespace CoupeDuMonde.Models
{
    internal class AdoBet : Ado
    {
        /*
        public static List<Bet> GetAll()
        {
            List<Bet> bet = new List<Bet>();
            Ado.open();
            SqlCommand command = new SqlCommand("SELECT * FROM paris");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // bets.Add(new SpecialBet(Convert.ToInt32(reader["id"]), Convert.ToString(reader["heading"]), Convert.ToInt32(reader["maxpoints"]), Convert.ToDateTime(reader["deadline"]), Convert.ToInt32(reader["score"]), Convert.ToString(reader["discriminant"]), Convert.ToBoolean(reader["isdeathmatch"], Convert.ToInt32(reader["penalty"]), Convert.ToInt32(reader["gap"]))));
                bet.Add(new Bet(Convert.ToInt32(reader["id"]), Convert.ToString(reader["heading"]), Convert.ToInt32(reader["maxpoints"]), Convert.ToDateTime(reader["deadline"]), Convert.ToString(reader["discriminant"])));
            }

            reader.Close();
            Ado.close();

            return bet;
        }*/

        // pour les spéciaux
        public static List<SpecialBet> GetAllSb()
        {
            List<SpecialBet> betsp = new List<SpecialBet>();
            Ado.open();
            SqlCommand command = new SqlCommand("SELECT * FROM paris Where discriminant like 'S%'");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                   // bets.Add(new SpecialBet(Convert.ToInt32(reader["id"]), Convert.ToString(reader["heading"]), Convert.ToInt32(reader["maxpoints"]), Convert.ToDateTime(reader["deadline"]), Convert.ToInt32(reader["score"]), Convert.ToString(reader["discriminant"]), Convert.ToBoolean(reader["isdeathmatch"], Convert.ToInt32(reader["penalty"]), Convert.ToInt32(reader["gap"]))));
                        betsp.Add(new SpecialBet(Convert.ToInt32(reader["id"]),Convert.ToString(reader["heading"]), Convert.ToInt32(reader["maxpoints"]), Convert.ToDateTime(reader["deadline"]), Convert.ToString(reader["discriminant"]), Convert.ToInt32(reader["penalty"]), Convert.ToInt32(reader["gap"])));
            }

            reader.Close();
            Ado.close();

            return betsp;
        }
        // pour les classiques
        public static List<CommonBet> GetAllCl()
        {
            List<CommonBet> betcl = new List<CommonBet>();
            Ado.open();
            SqlCommand command = new SqlCommand("SELECT * FROM paris Where discriminant like 'C%'");
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                    // bets.Add(new SpecialBet(Convert.ToInt32(reader["id"]), Convert.ToString(reader["heading"]), Convert.ToInt32(reader["maxpoints"]), Convert.ToDateTime(reader["deadline"]), Convert.ToInt32(reader["score"]), Convert.ToString(reader["discriminant"]), Convert.ToBoolean(reader["isdeathmatch"], Convert.ToInt32(reader["penalty"]), Convert.ToInt32(reader["gap"]))));
                        betcl.Add(new CommonBet(Convert.ToInt32(reader["id"]), Convert.ToString(reader["heading"]), Convert.ToInt32(reader["maxpoints"]), Convert.ToDateTime(reader["deadline"]), Convert.ToString(reader["discriminant"]), Convert.ToBoolean(reader["isdeathmatch"])));
            }

            reader.Close();
            Ado.close();

            return betcl;
        }
    }
}
