using SampleMessageApp;
class Program
{
    static void Main(string[] args)
    {
        MessageService messageService = new MessageService();

        while (true)
        {
            Console.WriteLine("1. Send message");
            Console.WriteLine("2. Read inbox");
            Console.WriteLine("3. Read outbox");
            Console.WriteLine("4. Delete message from inbox");
            Console.WriteLine("5. Delete message from outbox");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice:");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter message to send:");
                        string messageToSend = Console.ReadLine();
                        messageService.SendMessage(messageToSend);
                        break;
                    case 2:
                        messageService.ReadInbox();
                        break;
                    case 3:
                        messageService.ReadOutbox();
                        break;
                    case 4:
                        Console.WriteLine("Enter index of message to delete from inbox:");
                        int inboxMessageIndex;
                        if (int.TryParse(Console.ReadLine(), out inboxMessageIndex))
                        {
                            messageService.DeleteMessage(inboxMessageIndex, true);
                        }
                        else
                        {
                            Console.WriteLine("Invalid message index.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter index of message to delete from outbox:");
                        int outboxMessageIndex;
                        if (int.TryParse(Console.ReadLine(), out outboxMessageIndex))
                        {
                            messageService.DeleteMessage(outboxMessageIndex, false);
                        }
                        else
                        {
                            Console.WriteLine("Invalid message index.");
                        }
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid option number.");
            }

            Console.WriteLine();
        }
    }
}