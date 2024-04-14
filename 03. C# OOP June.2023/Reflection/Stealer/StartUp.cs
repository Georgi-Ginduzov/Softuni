namespace Stealer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string classToInvestigate = "Stealer.Hacker";
            string[] fields = new string[2];
            fields[0] = "username";
            fields[1] = "password";

            //string result = spy.StealFieldInfo(classToInvestigate, fields);
            string result = spy.AnalyzeAccessModifiers(classToInvestigate);
            Console.WriteLine(result);
        }
    }
}
