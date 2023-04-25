using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CoupeDuMonde.Models
{
	public class Ado
	{
		public static SqlConnection conn;
		public static void open()
		{
			conn = new SqlConnection();
			conn.ConnectionString = "";
			conn.Open();
		}
		public static void close()
		{
			conn.Close();
		}


		public static void insert()
		{
			open();

			SqlCommand cmd = new SqlCommand("INSERT INTO TableName (FirstColumn) VALUES (@1)");
			cmd.Connection = conn;
			cmd.Parameters.Add(new SqlParameter("1", 10));
			cmd.ExecuteNonQuery();

			close();
		}
	}
}