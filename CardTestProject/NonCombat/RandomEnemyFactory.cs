using System;
using System.Collections.Generic;
using System.Text;

namespace CardTestProject.NonCombat
{
    static class RandomEnemyFactory
    {
        public static Enemy GetEnemy()
        {
            int random = new Random().Next(0, 2);
            switch (random)
            {
                case 0:
                    return new Enemy(7,10,"defender");
                case 1:
                    return new Enemy(10,7,"attacker");
                default:
                    return null;
            }
        }
    }
}
