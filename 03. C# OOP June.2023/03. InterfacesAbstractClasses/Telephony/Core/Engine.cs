using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer) 
        { 
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string[] inputNumbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputWebsites = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable phone = null;
            IBrowsable smartphone = new Smartphone();

            foreach (string number in inputNumbers)
            {
                if (number.Length == 7)
                {
                    phone = new StationaryPhone();
                }
                else if (number.Length == 10)
                {
                    phone = new Smartphone();
                }

                try
                {
                    writer.WriteLine(phone.Call(number));
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (string url in inputWebsites)
            {
                try
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
