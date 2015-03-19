using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _2015_03_03_Mandatory_Exercise
{
	public class TrafficControlCenter
	{
		private Service service;

		public TrafficControlCenter()
		{
			service = new Service(); // Probably singleton. Couldn't be bothered.
			service.OnRadarDataGenerated += ReceiveData;
		}
		public void ReceiveData(RadarServerData radarServerData)
		{
			// ???
		}
	}
	public class InformationCenter
	{
		private Service service;

		public InformationCenter()
		{
			service = new Service(); // Probably singleton. Couldn't be bothered.
			service.OnRadarDataGenerated += ReceiveData;
		}
		public void ReceiveData(RadarServerData radarServerData)
		{
			// ???
		}
	}
	public class Service
	{
		public Action<RadarServerData> OnRadarDataGenerated;

		public RadarServerData GenerateRadarServerData(string airline, string flightnr, string from, 
			string to, string aircraft, int altitude, int speed, int track, double latitude, 
			double longitude, TimeSpan estArrival)
		{
			RadarServerData newData = new RadarServerData(airline, flightnr, from, to, aircraft, 
								altitude, speed, track, latitude, longitude, estArrival);
			OnRadarDataGenerated(newData);
			return newData;
		}
	}
	public class RadarServerData : ISerializable
	{
		public string Airline { get; set; }
		public string Flightnr { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public string Aircraft { get; set; }
		public int Altitude { get; set; }
		public int Speed { get; set; }
		public int Track { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public TimeSpan EstArrival { get; set; }
		
		public RadarServerData(string airline, string flightnr, string from, string to, string aircraft,
								int altitude, int speed, int track, double latitude, double longitude, 
								TimeSpan estArrival)
		{
			Airline = airline;
			Flightnr = flightnr;
			From = from;
			To = to;
			Aircraft = aircraft;
			Altitude = altitude;
			Speed = speed;
			Track = track;
			Latitude = latitude;
			Longitude = longitude;
			EstArrival = estArrival;
		}

		public RadarServerData(SerializationInfo info, StreamingContext context)
		{
			Airline = info.GetString("Airline");
			Flightnr = info.GetString("Flightnr");
			From = info.GetString("From");
			To = info.GetString("To");
			Aircraft = info.GetString("Aircraft");
			Altitude = (int) info.GetInt64("Altitude");
			Speed = (int) info.GetInt64("Speed");
			Track = (int) info.GetInt64("Track");
			Latitude = info.GetDouble("Latitude");
			Longitude = info.GetDouble("Longitude");
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Airline", Airline);
			info.AddValue("Flightnr", Flightnr);
			info.AddValue("From", From);
			info.AddValue("To", To);
			info.AddValue("Aircraft", Aircraft);
			info.AddValue("Altitude", Altitude);
			info.AddValue("Speed", Speed);
			info.AddValue("Track", Track);
			info.AddValue("Latitude", Latitude);
			info.AddValue("Longitude", Longitude);
		}
	}
}
