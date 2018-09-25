using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodVsEvil
{
    public class CharactorRepository
    {
        Random rnd = new Random();
        private Charactor _charactor;
        public void CreateCharactor(string name)
        {
            _charactor = new Charactor
            {
                charactorName = name,
                minDamage = 50,
                MaxkDamage = 200, 
                minDefense = 25,
                MaxDefense = 50,
                healthPoints = 1000,
                isAlive = true
            };
        }
        public Charactor CharactorDetail()
        {
            return _charactor;
        }
        public void CharactorHeal()
        {
            _charactor.healthPoints += 100;
        }
        public int CalculateDamage(int min, int max) => rnd.Next(_charactor.minDamage, _charactor.MaxkDamage);
        public int CalculateDefense(int min, int max) => rnd.Next(_charactor.minDefense, _charactor.minDefense);
    }
}
