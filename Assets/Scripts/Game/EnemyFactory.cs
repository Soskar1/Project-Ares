using System.Collections.Generic;
using UnityEngine;

namespace Core.Entities
{
    public class EnemyFactory
    {
        //private Dictionary<int, BaseEnemy> _factory;

        //public void Initialize(Enemies enemies, int level)
        //{
        //    _factory = new Dictionary<int, BaseEnemy>()
        //    {
        //        {level, GetInstance(enemies.EnemyList[level])}
        //    };
        //}

        //public BaseEnemy GetInstance(int level)
        //{
        //    return _factory[level];
        //}

        //private BaseEnemy GetInstance(EnemyStats stats)
        //{
        //    BaseEnemy instance = Pool<BaseEnemy>.pool.Get();
        //    instance.Initialize(stats);
        //    return instance;
        //}

        public BaseEnemy GetInstance()
        {
            return Pool<BaseEnemy>.pool.Get();
        }
    }
}