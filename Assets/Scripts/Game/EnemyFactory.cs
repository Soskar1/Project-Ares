using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class EnemyFactory
    {
        private Dictionary<int, Func<int, EnemyStats>> _factory;

        public void Initialize(Enemies enemies, int level)
        {
            _factory = new Dictionary<int, Func<int, EnemyStats>>()
            {
                {0, (level) => enemies.StraightLineEnemies[level]},
                {1, (level) => enemies.Caravan[level] }
            };
        }

        public EnemyStats GetInstance(int enemyID, int level)
        {
            return _factory[enemyID](level);
        }
    }
}