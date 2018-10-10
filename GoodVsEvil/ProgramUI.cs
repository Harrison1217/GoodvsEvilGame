using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodVsEvil
{
    public class ProgramUI
    {
        CharactorRepository charactorRepo = new CharactorRepository();
        VillianRepository villianRepo = new VillianRepository();
        public void run()
        {
            InitialPrompt();
        }
        public void InitialPrompt()
        {
            var villian = villianRepo.VillianDetail();
            
            Console.WriteLine("Welcome Player");
            Console.ReadLine();
            Console.WriteLine("What is your name Player?");
            string name = Console.ReadLine();
            charactorRepo.CreateCharactor(name);
            var charactor = charactorRepo.CharactorDetail();
            Console.WriteLine($"Enter Villians Name");
            string villianName = Console.ReadLine();
            villianRepo.CreateVillian(villianName);
            RunGame();
        }
        private void DisplayPlayerandVillianDetail()
        {
            var charactor = charactorRepo.CharactorDetail();
            var villian = villianRepo.VillianDetail();
            Console.WriteLine($"Charactor Name:{charactor.charactorName}\n" + 
                              $"Health:1000\n" +
                              $"Defense: 25-50\n" +
                              $"Attack Power:50-100\n\n" + 
                              $"Villian Name:{villian.villianName}\n" + 
                              $"Health:1000\n" +
                              $"Defense: 25-50\n" +
                              $"Attack Power:50-100\n\n" +
                              $"Hit Enter\n");
            Console.ReadLine();
            RunGame();
        }
        private void RunGame()
        {
            var charactor = charactorRepo.CharactorDetail();
            var villian = villianRepo.VillianDetail();
            Console.WriteLine($"Please Select an Option\n" +
                              $"1) {charactor.charactorName} and {villian.villianName} Fight Details\n" +
                              $"2) Fight\n");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                DisplayPlayerandVillianDetail();
            }
            else if (option == 2)
            {
                BeginFight();
            }

        }

        private void BeginFight()
        {
            
            var charactor = charactorRepo.CharactorDetail();
            var villian = villianRepo.VillianDetail();
            while (charactor.isAlive == true | villian.isAlive == true)
            {
                Console.WriteLine($"\nSelect an option\n" +
                                  $"1) Attck\n" + 
                                  $"2) Heal Self\n" + 
                                  $"3) Kill Shot\n");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    int VillianDamageTaken = charactorRepo.CalculateDamage(charactor.minDamage, charactor.MaxkDamage) - villianRepo.CalculateDefense(charactor.minDefense, charactor.MaxDefense);
                    villian.villianHealth -= VillianDamageTaken;
                    int CharactorDamageTaken = villianRepo.CalculateDamage(villian.minDamage, villian.MaxkDamage) - charactorRepo.CalculateDefense(charactor.minDefense, charactor.MaxDefense);
                    charactor.healthPoints -= CharactorDamageTaken;
                    Console.WriteLine($"{charactor.charactorName} took {CharactorDamageTaken} damage \n" +
                                      $"{villian.villianName} took: {VillianDamageTaken} damage\n" +
                                      $"{charactor.charactorName}'s Health:{charactor.healthPoints}\n" +
                                      $"{villian.villianName}'s Health: {villian.villianHealth}\n" +
                                      $"Hit Enter");
                    Console.ReadLine();
                }
                else if (option == 2)
                {
                    charactorRepo.CharactorHeal();
                    Console.WriteLine($"Healed Self for 100 points.\n" +
                                      $"{charactor.charactorName}'s Health:{charactor.healthPoints}");
                    villian.villianHealth += 50;
                    Console.WriteLine($"{villian.villianName} has healed themself for 50 points.\n" +
                                      $"{villian.villianName}'s Health:{villian.villianHealth}\n" + 
                                      $"Hit Enter");
                    Console.ReadLine();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Kill Shot Activated...Hit for 300 points");
                    villian.villianHealth -= 300;
                }
               

                if (villian.villianHealth <= 0)
                {
                    villian.isAlive = false;
                    Round2();
                }

                if (charactor.healthPoints <= 0)
                {
                    charactor.isAlive = false;
                }
            }
            Console.WriteLine("You Have Lost. Hit Enter.");
            Console.ReadLine();
            Console.Clear();
            InitialPrompt();
        }
        private void Round2()
        {
            var charactor = charactorRepo.CharactorDetail();
            var villian = villianRepo.VillianDetail();
            Console.Clear();
            Console.WriteLine($"Well Well {charactor.charactorName}.Looks like you completed round one.\n" +
                              $"Lets take a look at where your at health wise right now.\n" +
                              $"--------------------------------------------------------------------------\n" +
                              $"--------------------------------------------------------------------------\n" +
                              $"{charactor.charactorName} Detil\n" + 
                              $"Health Points: {charactor.healthPoints}\n" +
                              $"Well thats not going to work....Lets add a 1000 to that...\n");
            Console.ReadLine();
            charactor.healthPoints += 1000;
            Console.WriteLine($"Ok {charactor.charactorName}, we the high councle have decided that before we can give you \n" + 
                              $"access to our world we need to test your fighting skills once more\n" + 
                              $"Beat your enemy and the story will begin.\n" +
                              $"Fail and start all over my friend...Hit Enter");
            villian.villianHealth = 1000;
            Console.ReadLine();
            Console.Clear();
            while (charactor.isAlive == true | villian.isAlive == true)
            {
                Console.WriteLine($"\nSelect an option\n" +
                                  $"1) Attck\n" +
                                  $"2) Heal Self\n" +
                                  $"3) Kill Shot\n");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    int VillianDamageTaken = charactorRepo.CalculateDamage(charactor.minDamage, charactor.MaxkDamage) - villianRepo.CalculateDefense(charactor.minDefense, charactor.MaxDefense);
                    villian.villianHealth -= VillianDamageTaken;
                    int CharactorDamageTaken = villianRepo.CalculateDamage(villian.minDamage, villian.MaxkDamage) - charactorRepo.CalculateDefense(charactor.minDefense, charactor.MaxDefense);
                    charactor.healthPoints -= CharactorDamageTaken;
                    Console.WriteLine($"{charactor.charactorName} took {CharactorDamageTaken} damage \n" +
                                      $"{villian.villianName} took: {VillianDamageTaken} damage\n" +
                                      $"{charactor.charactorName}'s Health:{charactor.healthPoints}\n" +
                                      $"{villian.villianName}'s Health: {villian.villianHealth}\n" +
                                      $"Hit Enter");
                    Console.ReadLine();
                }
                else if (option == 2)
                {
                    charactorRepo.CharactorHeal();
                    Console.WriteLine($"Healed Self for 100 points.\n" +
                                      $"{charactor.charactorName}'s Health:{charactor.healthPoints}");
                    villian.villianHealth += 50;
                    Console.WriteLine($"{villian.villianName} has healed themself for 50 points.\n" +
                                      $"{villian.villianName}'s Health:{villian.villianHealth}\n" +
                                      $"Hit Enter");
                    Console.ReadLine();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Kill Shot Activated...Hit for 300 points");
                    villian.villianHealth -= 300;
                }


                if (villian.villianHealth <= 0)
                {
                    villian.isAlive = false;
                    storyMode();
                }

                if (charactor.healthPoints <= 0)
                {
                    charactor.isAlive = false;
                }
            }
            Console.WriteLine("You Have Lost. Hit Enter.");
            Console.ReadLine();
            Console.Clear();
            InitialPrompt();
        }
        private void storyMode()
        {
            var charactor = charactorRepo.CharactorDetail();
            var villian = villianRepo.VillianDetail();
            Console.WriteLine($"Welcome to Story Mode {charactor.charactorName}");
            Console.ReadLine();
            Console.WriteLine($"Well Im quite suprised that you made it through two rounds.\n" +
                              $" Did not think you had it in you...Anyways" + 
                              $"Well inorder for you to be able to make it through the next area you'll need some gold. \n" + 
                              $"Its not much but it should at least get you around the city for a few days until you can find wokr.");
            Console.ReadLine();
            charactor.Gold = 100;
            Console.WriteLine("Player is given 100 gold by Old Man ");
            Console.ReadLine();
            Console.WriteLine($"Ok {charactor.charactorName} Head east to the city, youll find a man named todd their. \n" +
                              $"He will be your guid while in the city. So I advise asking him as many questions as possible. Good Luck on your journey");
            Console.ReadLine();
            City();
            EndGame();
        }

        private void City()
        {
            var charactor = charactorRepo.CharactorDetail();
            var villian = villianRepo.VillianDetail();
            Console.Clear();
            Console.WriteLine($"Welcome {charactor.charactorName}\n" +
                              $"Im Todd, You were told about me from the old Man...\n" +
                              $"Thats right he told you to ask me questions and Ill have the Answer for you...\n" +
                              $"Well Whats your Question?\n" +
                              $"------------------------------ \n" +
                              $"1) What is my Purpose? \n" +
                              $"2) What can visit?\n" +
                              $"3) Enter The City");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine($"Well Your Here to Quest. Find Gold, Fight Monsters, Join A Guild, Become a legend in the land...\n" +
                                  $"In every city their are quests for you to find. Do this by approching people and talking with them.");
            }
            else if (choice == 2)
            {
                Console.WriteLine($"Here is a list of the Know Locations around the Area...\n" +
                  $"(**) Means Current Location\n" +
                  $"The City ** \n" +
                  $"Small Town \n" +
                  $"River Front \n" +
                  $"Mountains \n" +
                  $"Ocean Harbor \n" +
                  $"You can Travel To one of these loctions listed. Many more to discover");
                Console.ReadLine();
            }              
        }

        private void EndGame()
        {
            var charactor = charactorRepo.CharactorDetail();
            var villian = villianRepo.VillianDetail();
            Console.WriteLine($"Congratulations You have Defeted {villian.villianName} \n" +
                              $"Good luck {charactor.charactorName}");
            Console.ReadLine();
            Console.Clear();
            InitialPrompt();
        }
    }
}
