using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            Slots = slots;
            Servers = new List<Server>();
        }

        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount { get => Servers.Count; }

        public void AddServer(Server server)
        {
            if (GetCount < Slots)
            {
                foreach (Server item in Servers)
                {
                    if (item.SerialNumber == server.SerialNumber)
                    {
                        return;
                    }
                }
                Servers.Add(server);
            }
        }

        public bool RemoveServer(string serialNumber)
        {
            foreach (Server server in Servers)
            {
                if (server.SerialNumber == serialNumber)
                {
                    return Servers.Remove(server);
                }
            }
            return false;
        }

        public string GetHighestPowerUsage()
        {
            Server highestPowerUsageServer = Servers[0];
            foreach (Server server in Servers)
            {
                if (server.PowerUsage > highestPowerUsageServer.PowerUsage)
                {
                    highestPowerUsageServer = server;
                }
            }

            return highestPowerUsageServer.ToString().Trim();
        }

        public int GetTotalCapacity() => Servers.Sum(server => server.Capacity);
        
        public string DeviceManager()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{GetCount} servers operating:");
            foreach (Server server in Servers)
            {
                output.AppendLine(server.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
