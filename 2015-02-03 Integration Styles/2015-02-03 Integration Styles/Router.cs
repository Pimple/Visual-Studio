using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Messaging;
using System.Diagnostics;

namespace _2015_02_03_Integration_Styles
{
	class Router
	{
		protected MessageQueue inQueue;
		protected MessageQueue outQueue1;
		protected MessageQueue outQueue2;

		public Router(MessageQueue inQueue, MessageQueue outQueue1, MessageQueue outQueue2)
		{
			this.inQueue = inQueue;
			this.outQueue1 = outQueue1;
			this.outQueue2 = outQueue2;
			inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
			inQueue.BeginReceive();
		}

		private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
		{
			MessageQueue mq = (MessageQueue)source;
			Message message = mq.EndReceive(asyncResult.AsyncResult);
			
			message.Formatter = new XmlMessageFormatter(new Type[] { typeof(Stock) });
			Stock stock = (Stock) message.Body;

			try
			{
				string company = stock.Company;
				if (company.Contains("NASDAQ"))
					outQueue1.Send(stock, stock.Company);
				else
					outQueue2.Send(stock, stock.Company);
				mq.BeginReceive();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error[2]: " + ex.Message);
			}
		}
	}
}
