using System.Collections.Generic;

namespace Core.Entities
{
    public class EnemyFactory
    {
        private Dictionary<int, EnemyStats> _factory;

        public void Initialize(Enemies enemies, int level)
        {
            _factory = new Dictionary<int, EnemyStats>()
            {
                {level, enemies.EnemyList[level]}
            };
        }

        public EnemyStats GetInstance(int level)
        {
            return _factory[level];
        }
    }
}