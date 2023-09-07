namespace StudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>
                    {
                        grade
                    };
                }
                else
                {
                    students[name].Add(grade);
                }

            }

            foreach (var student in students)
            {
                double sumOfGrades = 0;
                foreach (var grade in student.Value)
                {
                    sumOfGrades += grade;
                }

                double averageGrade = (sumOfGrades / student.Value.Count);
                if (averageGrade >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:F2}");
                }
            }
        }
    }
}