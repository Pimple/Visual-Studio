﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _2015_03_03_Mandatory_Exercise
{
	public class Subscriber
	{
		protected MessageQueue inQueue;
		protected MessageQueue outQueue1;
		protected MessageQueue outQueue2;

		public Subscriber(MessageQueue inQueue)
		{
			this.inQueue = inQueue;
			inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
			inQueue.BeginReceive();
		}

		private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
		{
			MessageQueue mq = (MessageQueue)source;
			Message message = mq.EndReceive(asyncResult.AsyncResult);

			message.Formatter = new XmlMessageFormatter(new Type[] { typeof(Stock) });
			Stock stock = (Stock)message.Body;

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
