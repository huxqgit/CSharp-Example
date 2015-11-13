using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace Example.MessageQueueTest
{
    public class MessageQueueTT
    {
        MessageQueue queue = null;
        public void Test()
        {
            CreateQueue();
            SendQueue();
            ReadQueue();
        }


        private void SendQueue()
        {
            queue.Formatter = new XmlMessageFormatter(new string[] { "System.Byte" });
            queue.Send("123");
        }

        private void CreateQueue()
        {
            using (var queue = MessageQueue.Create(@".\Private$\123"))
            {                
                queue.Label = "Demo Queue";
                Console.WriteLine("Queue created!");
                Console.WriteLine("Path: {0}", queue.Path);
                Console.WriteLine("FormatName: {0}", queue.FormatName);

                this.queue = queue;
            }
        }

        private void ReadQueue()
        {
            if (MessageQueue.Exists(@".\Private$\123"))
            {
                var queue = new MessageQueue(@".\Private$\123");
                queue.Formatter = new XmlMessageFormatter(new string[] { "System.Byte" });
                Message message = queue.Receive();
                Console.WriteLine(message.Body);
            }
        }
    }
}
