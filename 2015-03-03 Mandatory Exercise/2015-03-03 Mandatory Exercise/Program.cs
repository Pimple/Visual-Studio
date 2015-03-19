using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2015_03_03_Mandatory_Exercise
{
	public class Program
	{
		private const string connectionString = 
			"Data Source=MUPPETBOX\\SQLEXPRESS;Initial Catalog=\"System Integration\";Integrated Security=True";
		
		public static void Main(string[] args)
		{
			SqlConnection connection = null;
			SqlCommand command = null;
			SqlDataReader reader = null;
			try
			{
				connection = new SqlConnection(connectionString);
				connection.Open();

				while (true)
				{
					command = new SqlCommand("SELECT * FROM [dbo].[Flights]", connection);
					reader = command.ExecuteReader();

					while (reader.Read())
					{
						AirlineData newData = new AirlineAdapter("KLM", "KL1108", "Amsterdam Schipol (AMS)", new TimeSpan(11, 25, 0), new TimeSpan(10, 15, 0), false);
						Console.Out.WriteLine("Added new data.");
					}

					reader.Close();
					Thread.Sleep(10000);
				}
			}
			catch (Exception ex)
			{
				Console.Out.WriteLine(ex.Message);
			}
			finally
			{
				if (connection != null)
					connection.Close();
			}
		}
	}
}
