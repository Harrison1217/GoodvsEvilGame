using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodVsEvil
{
    public class VillianRepository
    {
        Random rnd = new Random();
        private Villian _villian;
        public void CreateVillian(string name)
        {
            _villian = new Villian
            {
                isAlive = true,
                villianName = name,
                villianHealth = 1000,
                minDamage = 50,
                MaxkDamage = 200,
                minDefense = 25,
                MaxDefense = 50,
            };
        }
        public Villian VillianDetail()
        {
            return _villian;
        }
        public int CalculateDamage(int min, int max) => rnd.Next(_villian.minDamage, _villian.MaxkDamage);
        public int CalculateDefense(int min, int max) => rnd.Next(_villian.minDefense, _villian.MaxDefense);
    }
}
