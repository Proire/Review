using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingToInterface
{
    internal class InterfaceDemo
    {
        // Interface 
        public interface ImessageService
        {
            void SendMessage(string address);
        }

        // class implementating interface
        internal class Email : ImessageService
        {
            public void SendMessage(string address)
            {
                Console.WriteLine("Sending Email to {0}", address);
            }
        }

        // class implementating interface
        internal class Sms : ImessageService
        {
            public void SendMessage(string address)
            {
                Console.WriteLine("Sending Sms to {0}", address);
            }
        }

        // static class to hold for static method to implement programming to interface
        internal static class Messageprovider
        {
            public static void Send(ImessageService s, string add)
            {
                s.SendMessage(add);

            }
        }
    }
}
