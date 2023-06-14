using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMessageApp
{
    public class MessageService : IMessageService
    {
        private List<string> inbox;

        private List<string> outbox;
        public MessageService()
        {
            inbox = new List<string>();
            outbox = new List<string>();
        }

        public void SendMessage(string message)
        {
            if (inbox.Count >= 5 && outbox.Count >= 3)
            {
                Console.WriteLine("Both inbox and Outbox are full.Cannot send more messages.");
                return;
            }

            if (inbox.Count < 5)
            {
                inbox.Add(message);
                Console.WriteLine("Message sent successfully. Added to Inbox.");
            }

            else if (outbox.Count < 3)
            {
                outbox.Add(message);
                Console.WriteLine("Inbox is full. So the message is Added to the OutBox");
            }
            else
            {
                Console.WriteLine("Inbox and Outbox are full. Cannot send more messages");
            }
        }

        public void ReadInbox()
        {
            if (inbox.Count == 0)
            {
                Console.WriteLine("Inbox is empty.");
                return;
            }

            Console.WriteLine("Inbox messages:");
            foreach (string message in inbox)
            {
                Console.WriteLine(message);
            }
        }

        public void ReadOutbox()
        {
            if (outbox.Count == 0)
            {
                Console.WriteLine("Outbox is empty.");
                return;
            }

            Console.WriteLine("Outbox messages:");
            foreach (string message in outbox)
            {
                Console.WriteLine(message);
            }
        }

        public void DeleteMessage(int messageIndex, bool isFromInbox)
        {
            List<string> messageList = isFromInbox ? inbox : outbox;

            if (messageIndex < 0 || messageIndex >= messageList.Count)
            {
                Console.WriteLine("Invalid message index.");
                return;
            }
            if (isFromInbox)
            {
                inbox.RemoveAt(messageIndex);
                Console.WriteLine("Message deleted from inbox successfully.");

                if (outbox.Count > 0 && inbox.Count < 5)
                {
                    inbox.Add(outbox[0]);
                    outbox.RemoveAt(0);
                    Console.WriteLine("Message moved from outbox to Inbox.");
                }
            }
            else
            {
                outbox.RemoveAt(messageIndex);
                Console.WriteLine("Message deleted from Outbox successfully.");
            }
        }
    }
}
