using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _2015_02_03_Integration_Styles
{
	[Serializable()]
	public class Stock : ISerializable, IComparable<Stock>
	{
		public DateTime Timestamp;
		public string Company;
		public double Value;
		public double Change;
		public double Week;
		public double Month;
		public double Quarter;
		public double Year;

		public Stock() { }

		public Stock(string company, double value, double change, DateTime timestamp, double week, double month, double quarter, double year)
		{
			Company = company;
			Value = value;
			Change = change;
			Timestamp = timestamp;
			Week = week;
			Month = month;
			Quarter = quarter;
			Year = year;
		}

		public Stock(SerializationInfo info, StreamingContext context)
		{
			Timestamp = (DateTime)info.GetDateTime("Timestamp");
			Company = (string)info.GetString("Company");
			Value = (double)info.GetDouble("Value");
			Change = (double)info.GetDouble("Change");
			Week = (double)info.GetDouble("Week");
			Month = (double)info.GetDouble("Month");
			Quarter = (double)info.GetDouble("Quarter");
			Year = (double)info.GetDouble("Year");
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Timestamp", Timestamp);
			info.AddValue("Company", Company);
			info.AddValue("Value", Value);
			info.AddValue("Change", Change);
			info.AddValue("Week", Week);
			info.AddValue("Month", Month);
			info.AddValue("Quarter", Quarter);
			info.AddValue("Year", Year);
		}

		public int CompareTo(Stock other)
		{
			return Timestamp.CompareTo(other.Timestamp);
		}
	}
}
