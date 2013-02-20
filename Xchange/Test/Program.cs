using Denolk.XchangeWrapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = "";
            string pass = "";

            XService _XService = XService.Init(user,pass);
			
            var calendar = _XService.GetCalendarList("");
			
            //var events = _XService.GetEventList();
            //var contacts = _XService.GetAddressBook();
            //Console.WriteLine("events:\n" + JsonConvert.SerializeObject(events));
            //Console.WriteLine("contacts:\n" + JsonConvert.SerializeObject(contacts));
        }
    }
}
