using System.Collections.Generic;
using UnityEngine;

namespace Core.Entities
{
    [CreateAssetMenu(fileName = "new Enemy", menuName = "Enemies")]
    public class Enemies : ScriptableObject
    {
        [SerializeField] private List<EnemyStats> _enemyList;
        public List<EnemyStats> EnemyList => _enemyList;
    }
}