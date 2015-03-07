using System;
using System.Diagnostics;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _2015_02_03_Integration_Styles
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Dow Jones   17,729.21   -0.53% down     09/02/2015
			 * 0.4% Stock price increasing
			 * 0.0% Stock price unchanged
			 * 0.7% Stock price increasing
			 * 12.2% Stock price increasing
			 * 
			 * NASDAQ-100	4,216.09	0.0% Stock price unchanged	07:01:18
			 * -0.3% Stock price decreasing
			 * 0.1% Stock price increasing
			 * 1.0% Stock price increasing
			 * 17.7% Stock price increasing
			 * 
			 * NASDAQ Composite	4,726.01	0.0% Stock price unchanged	07:01:18
			 * 0.0% Stock price unchanged
			 * 0.5% Stock price increasing
			 * 1.6% Stock price increasing
			 * 13.9% Stock price increasing
			 * 
			 * S&P 500	2,046.74	-0.42% down	09/02/2015
			 * -0.2% Stock price decreasing
			 * 0.1% Stock price increasing
			 * 0.4% Stock price increasing
			 * 13.7% Stock price increasing
			 */
			Stock dowJones = new Stock("Dow Jones", 17729.21, -0.53, new DateTime(2015, 02, 09), 0.4, 0.0, 0.7, 12.2);
			Stock nasdaq100 = new Stock("NASDAQ-100", 4216.09, 0.0, new DateTime(2015, 02, 10, 07, 01, 18), -0.3, 0.1, 1.0, 17.7);
			Stock nasdaqComposite = new Stock("NASDAQ Composite", 4726.01, 0.0, new DateTime(2015, 02, 10, 07, 01, 18), 0.0, 0.5, 1.6, 13.9);
			Stock sp500 = new Stock("S&P 500", 2046.74, -0.42, new DateTime(2015, 02, 09), -0.2, 0.1, 0.4, 13.7);

			MessageQueue messageQueue = null;
			MessageQueue outQueue1 = null;
			MessageQueue outQueue2 = null;
			if (MessageQueue.Exists(@".\Private$\TestIn"))
			{
				messageQueue = new MessageQueue(@".\Private$\TestIn");
				messageQueue.Label = "TestIn";
			}
			else
			{
				MessageQueue.Create(@".\Private$\TestIn");
				messageQueue = new MessageQueue(@".\Private$\TestIn");
				messageQueue.Label = "TestIn";
			}
			if (MessageQueue.Exists(@".\Private$\TestOut1"))
			{
				outQueue1 = new MessageQueue(@".\Private$\TestOut1");
				outQueue1.Label = "TestOut1";
			}
			else
			{
				MessageQueue.Create(@".\Private$\TestOut1");
				outQueue1 = new MessageQueue(@".\Private$\TestOut1");
				outQueue1.Label = "TestOut1";
			}
			if (MessageQueue.Exists(@".\Private$\TestOut2"))
			{
				outQueue2 = new MessageQueue(@".\Private$\TestOut2");
				outQueue2.Label = "TestOut2";
			}
			else
			{
				MessageQueue.Create(@".\Private$\TestOut2");
				outQueue2 = new MessageQueue(@".\Private$\TestOut2");
				outQueue2.Label = "TestOut2";
			}

			Router router = new Router(messageQueue, outQueue1, outQueue2);
			try
			{
				messageQueue.Send(dowJones, dowJones.Company);
				messageQueue.Send(nasdaq100, nasdaq100.Company);
				messageQueue.Send(nasdaqComposite, nasdaqComposite.Company);
				messageQueue.Send(sp500, sp500.Company);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error[1]: " + ex.Message);
			}

			// Console.ReadLine();
		}
	}
}
