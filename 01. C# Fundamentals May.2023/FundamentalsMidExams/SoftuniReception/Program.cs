namespace SoftuniReception
{
    public class Program
    {
        static void Main(string[] args)
        {
            int studentsPerEmployeePerHour = 0;
            
            for (int i = 0; i < 3; i++)
            {
                studentsPerEmployeePerHour += int.Parse(Console.ReadLine());
            }

            double studentsCount = int.Parse(Console.ReadLine());
            /*
            double time = Math.Ceiling(studentsCount / studentsPerEmployeePerHour);
            double restTime = Math.Ceiling(time / 4);

            if (time < 4)
            {
                restTime -= 1;
            }*/



            int time = 0;
            while (studentsCount > 0)
            {
                studentsCount -= studentsPerEmployeePerHour;
                time++;
                if (time % 4 == 0)
                {
                    time++;
                }
            }

             Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
