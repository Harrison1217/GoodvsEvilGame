using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodVsEvil
{
    public class StoryMode
    {
        CharactorRepository charactorRepo = new CharactorRepository();
        VillianRepository villianRepo = new VillianRepository();
        public void run()
        {
            InitialPrompt();
        }
        public void InitialPrompt()
        {
            Console.WriteLine("Welcome Player");
            Console.ReadLine();

        }
    }
}
