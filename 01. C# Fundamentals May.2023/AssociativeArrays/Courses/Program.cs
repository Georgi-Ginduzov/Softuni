namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" : ");
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                if (!courses.ContainsKey(input[0]))
                {
                    courses[input[0]] = new List<string>
                    {
                        input[1]
                    };
                }
                else
                {
                    courses[input[0]].Add(input[1]);
                }
                input = Console.ReadLine().Split(" : ");
            }

            foreach (var course in courses)
            {
                Console.WriteLine(course.Key + ": " + course.Value.Count);
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }

        }
    }
}