namespace CustomThreeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nameAdress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] nameAndDrunk = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] nameAndBank = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> nameAndAdress = new($"{nameAdress[0]} {nameAdress[1]}", nameAdress[2], string.Join(" ", nameAdress[3..]));
            Console.WriteLine(nameAndAdress);
            if (nameAndDrunk[2] == "drunk")
            {
                Threeuple<string, int, bool> drunkOrNot =
                    new(nameAndDrunk[0], int.Parse(nameAndDrunk[1]), true);
                Console.WriteLine(drunkOrNot);
            }
            else 
            {
                Threeuple<string, int, bool> drunkOrNot =
                    new(nameAndDrunk[0], int.Parse(nameAndDrunk[1]), false);
                Console.WriteLine(drunkOrNot);
            }
            Threeuple<string, double, string> bankBallance = new(nameAndBank[0], double.Parse(nameAndBank[1]), nameAndBank[2]);
            Console.WriteLine(bankBallance);

        }
    }
}