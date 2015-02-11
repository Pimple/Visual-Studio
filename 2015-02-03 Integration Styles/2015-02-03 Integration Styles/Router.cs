using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Messaging;

namespace _2015_02_03_Integration_Styles
{
	class Router
	{
		protected MessageQueue inQueue;
		protected MessageQueue outQueue1;
		protected MessageQueue outQueue2;

		protected bool toggle = false;

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
			if (IsConditionFulfilled())
				outQueue1.Send(message);
			else
				outQueue2.Send(message);
			mq.BeginReceive();
		}

		protected bool IsConditionFulfilled()
		{
			toggle = !toggle;
			return toggle;
		}
	}
}
