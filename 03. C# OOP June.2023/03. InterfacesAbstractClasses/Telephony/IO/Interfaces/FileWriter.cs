namespace Telephony.IO.Interfaces
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            string filePath = "../../../test.txt";

            using StreamWriter sw = new StreamWriter(filePath, true); // important to use using

            sw.WriteLine(line);

        }
    }
}
