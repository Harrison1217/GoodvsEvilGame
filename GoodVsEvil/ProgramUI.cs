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
            Console.WriteLine($"\nSo you are {charactor.charactorName}\n");
            Console.ReadLine();
            Console.WriteLine($"We need a name for your oppenent. Please give us a name for them...");
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
                              $"Attack Power:50-100\n");
            Console.ReadLine();
            RunGame();
        }
        private void RunGame()
        {
            Console.WriteLine($"Now that we have you and your oppents Name.\n" +
                              $"Please Select an Option\n" +
                              $"1) Player and Villian Details\n" +
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
            while (charactor.isAlive == true)
            {
                Console.WriteLine($"\nSelect an option\n" +
                                  $"1) Attck\n" + 
                                  $"2) Heal Self\n");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    int VillianDamageTaken = charactorRepo.CalculateDamage(charactor.minDamage, charactor.MaxkDamage) - villianRepo.CalculateDefense(charactor.minDefense, charactor.MaxDefense);
                    villian.villianHealth -= VillianDamageTaken;
                    int CharactorDamageTaken = villianRepo.CalculateDamage(villian.minDamage, villian.MaxkDamage) - charactorRepo.CalculateDefense(charactor.minDefense, charactor.MaxDefense);
                    charactor.healthPoints -= CharactorDamageTaken;
                    Console.WriteLine($"{charactor.charactorName} took {CharactorDamageTaken} damage \n" +
                                      $"{villian.villianName} took: {VillianDamageTaken}\n" +
                                      $"{charactor.charactorName}'s Health:{charactor.healthPoints}\n" +
                                      $"{villian.villianName}'s Health: {villian.villianHealth}");
                    Console.ReadLine();
                }
                else if (option == 2)
                {
                    charactorRepo.CharactorHeal();
                    Console.WriteLine($"Healed Self for 100 points.\n" +
                                      $"{charactor.charactorName}'s Health:{charactor.healthPoints}");
                }
               

                if (villian.villianHealth <= 0)
                {
                    EndGame();
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
