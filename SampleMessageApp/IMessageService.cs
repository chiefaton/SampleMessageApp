using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMessageApp
{
    public interface IMessageService
    {
        void SendMessage(string message);

        void ReadInbox();

        void ReadOutbox();

        void DeleteMessage(int messageIndex, bool isFromInbox);

    }
}
