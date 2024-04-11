//using E04._BorderControl.
using E04._BorderControl.Core.Interfaces;
using E04._BorderControl.IO.Interfaces;
using E04._BorderControl.Models;
using E04._BorderControl.Models.Interfaces;

namespace E04._BorderControl.Core
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
            string[] data;
            List<ICitizen> citizensAndRobots = new();
            List<ICitizen> detained = new();

            while ((data = reader.ReadLine().Split(' '))[0] != "End")
            {
                if (data.Count() == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];

                    citizensAndRobots.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = data[0];
                    string id = data[1];

                    citizensAndRobots.Add(new Robot(model, id));
                }
            }
            ;
            string lastDigitsOfFakeIds = reader.ReadLine();
            foreach (var citizen in citizensAndRobots)
            {
                if (citizen.Id.EndsWith(lastDigitsOfFakeIds))
                {
                    detained.Add(citizen);
                }
            }

            foreach (var detainedCitizen in detained)
            {
                writer.WriteLine(detainedCitizen.Id);
            }
        }        
    }
}
