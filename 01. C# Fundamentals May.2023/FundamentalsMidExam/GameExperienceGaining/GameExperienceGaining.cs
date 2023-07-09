namespace GameExperienceGaining
{
    internal class GameExperienceGaining
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int countOfBattles;

            while (!int.TryParse(Console.ReadLine(), out countOfBattles))
            {
            }

            double[] experiencePerBattle = new double[countOfBattles];
            bool isCollected = false;
            for (int i = 0; i < countOfBattles; i++)
            {
                double currentExperience;

                while (!double.TryParse(Console.ReadLine(), out currentExperience))
                {

                }

                experiencePerBattle[i] = currentExperience;
            }
            double totalExperience = experiencePerBattle[0];

            for (int i = 1; i < countOfBattles; i++)
            {

                if ((i + 1) % 15 == 0) // every 15th battle
                {
                    experiencePerBattle[i] = experiencePerBattle[i] + (experiencePerBattle[i] * 0.05);
                    totalExperience += experiencePerBattle[i];
                }
                else if ((i + 1) % 3 == 0) // every third
                {
                    experiencePerBattle[i] = experiencePerBattle[i] + (experiencePerBattle[i] * 0.15);
                    totalExperience += experiencePerBattle[i];
                }
                else if ((i + 1) % 5 == 0) // every fifth
                {
                    experiencePerBattle[i] = experiencePerBattle[i] - (experiencePerBattle[i] * 0.1);
                    totalExperience += experiencePerBattle[i];
                }
                else
                {
                    totalExperience += experiencePerBattle[i];
                }

                if (totalExperience >= neededExperience && isCollected == false)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {i + 1} battles.");
                    isCollected = true;
                }
            }
            if (totalExperience < neededExperience)
            {
                double needToCollect = neededExperience - totalExperience;
                Console.WriteLine($"Player was not able to collect the needed experience, {needToCollect:F2} more needed.");
            }
        }
    }    }