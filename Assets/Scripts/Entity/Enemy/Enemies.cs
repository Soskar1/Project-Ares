using System.Collections.Generic;
using UnityEngine;

namespace Core.Entities
{
    [CreateAssetMenu(fileName = "new Enemy", menuName = "Enemies")]
    public class Enemies : ScriptableObject
    {
        [SerializeField] private List<EnemyStats> _straightLineEnemies;
        [SerializeField] private List<EnemyStats> _caravan;
        public List<EnemyStats> StraightLineEnemies => _straightLineEnemies;
        public List<EnemyStats> Caravan => _caravan;
    }
}