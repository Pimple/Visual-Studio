using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _2015_03_03_Mandatory_Exercise
{
	public class AirlineData
	{
		public string Airline { get; set; }
		public string Flightnr { get; set; }
		public string Destination { get; set; }
		public TimeSpan Time { get; set; }
		public TimeSpan CheckIn { get; set; }
		public bool CheckInStatus { get; set; }

		public AirlineData() { }

		public AirlineData(string airline, string flightnr, string destination, TimeSpan time, TimeSpan checkIn, bool checkInStatus)
		{
			Airline = airline;
			Flightnr = flightnr;
			Destination = destination;
			Time = time;
			CheckIn = checkIn;
			CheckInStatus = checkInStatus;
		}
	}

	public class AirlineAdapter : AirlineData, ISerializable
	{
		private string connectionString;
		private string table;

		SqlConnection connection = null;
		SqlCommand command = null;
		SqlDataReader reader = null;

		public AirlineAdapter() { }

		public AirlineAdapter(string airline, string flightnr, string destination, 
								TimeSpan time, TimeSpan checkIn, bool checkInStatus)
		{
			Airline = airline;
			Flightnr = flightnr;
			Destination = destination;
			Time = time;
			CheckIn = checkIn;
			CheckInStatus = checkInStatus;

			connectionString = "Data Source=MUPPETBOX\\SQLEXPRESS;Initial Catalog=\"System Integration\";Integrated Security=True";
			
			try
			{
				// Fetch data from database
				connection = new SqlConnection(connectionString);
				connection.Open();
				command = new SqlCommand("SELECT * FROM [dbo].[Flights] WHERE Flightnr = @flightnr", connection);
				command.Parameters.AddWithValue("@flightnr", Flightnr);
				reader = command.ExecuteReader();
				reader.Read();

				Airline = (string) reader["Airline"];
				Flightnr = (string) reader["Flightnr"];
				Destination = (string) reader["Destination"];
				Time = (TimeSpan) reader["Time"];
				CheckIn = (TimeSpan) reader["CheckIn"];
				CheckInStatus = (bool) reader["CheckInStatus"];
				
				reader.Close();

				// Add to MessageQueue
				MessageQueue messageQueue = null;
				if (MessageQueue.Exists(@".\Private$\AirlineData"))
				{
					messageQueue = new MessageQueue(@".\Private$\AirlineData");
					messageQueue.Label = "AirlineData";
				}
				else
				{
					MessageQueue.Create(@".\Private$\AirlineData");
					messageQueue = new MessageQueue(@".\Private$\AirlineData");
					messageQueue.Label = "AirlineData";
				}

				messageQueue.Send(this, Airline + " " + Flightnr);
			}
			catch (Exception ex)
			{
				reader.Close();
				Console.Out.WriteLine("Error(" + Flightnr + "): " + ex.Message);
			}
			finally
			{
				if (connection != null)
					connection.Close();
			}
		}

		public AirlineAdapter(SerializationInfo info, StreamingContext context)
		{
			Airline = info.GetString("Airline");
			Flightnr = info.GetString("Flightnr");
			Destination = info.GetString("Destination");
			Time = new TimeSpan(info.GetInt64("Time"));
			CheckIn = new TimeSpan(info.GetInt64("CheckIn"));
			CheckInStatus = info.GetBoolean("CheckInStatus");
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Airline", Airline);
			info.AddValue("Flightnr", Flightnr);
			info.AddValue("Destination", Destination);
			info.AddValue("Time", Time.Ticks);
			info.AddValue("CheckIn", CheckIn.Ticks);
			info.AddValue("CheckInStatus", CheckInStatus);
		}
	}
}
