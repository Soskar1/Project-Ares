using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Entities
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<BaseEnemy> _enemyList;
        [SerializeField] private Enemies _enemies;
        [SerializeField] private Vector2 _firstPoint;
        [SerializeField] private Vector2 _secondPoint;
        [SerializeField] private float _delay;

        private EnemyFactory _enemyFactory;

        private EnemyPool _enemyPool;
        private BulletPool _bulletPool;
        private EffectsPool _effectsPool;

        private bool _timerStarted = false;

        private void Update()
        {
            if (_timerStarted == true)
                return;

            _timerStarted = true;
            StartCoroutine(Timer.Start(_delay, () => { Spawn(TakeEnemy()); _timerStarted = false; }));
        }

        public void Initialize(EnemyPool enemyPool, BulletPool bulletPool, EffectsPool effectsPool)
        {
            _enemyFactory = new EnemyFactory();
            _enemyFactory.Initialize(_enemies, SceneManager.GetActiveScene().buildIndex);

            _enemyPool = enemyPool;
            _bulletPool = bulletPool;
            _effectsPool = effectsPool;
        }

        private void Spawn(BaseEnemy enemy)
        {
            EnemyStats stats = _enemyFactory.GetInstance(enemy.ID, SceneManager.GetActiveScene().buildIndex);
            BaseEnemy enemyInstance = _enemyPool.Get(enemy);
            enemyInstance.Initialize(stats, _enemyPool, _bulletPool, _effectsPool);
            enemyInstance.transform.position = TakeRandomPosition();
        }

        private Vector2 TakeRandomPosition()
        {
            float x = Random.Range(_firstPoint.x, _secondPoint.x);
            float y = Random.Range(_firstPoint.y, _secondPoint.y);
            return new Vector2(x, y);
        }

        private BaseEnemy TakeEnemy()
        {
            BaseEnemy rngEnemy = _enemyList[0];

            float rng = Random.Range(0, 100);
            foreach (BaseEnemy enemy in _enemyList)
                if (rng <= enemy.SpawnFrequency)
                    rngEnemy = enemy;

            return rngEnemy;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            Gizmos.DrawLine(_firstPoint, new Vector2(_secondPoint.x, _firstPoint.y));
            Gizmos.DrawLine(new Vector2(_secondPoint.x, _firstPoint.y), _secondPoint);
            Gizmos.DrawLine(_secondPoint, new Vector2(_firstPoint.x, _secondPoint.y));
            Gizmos.DrawLine(new Vector2(_firstPoint.x, _secondPoint.y), _firstPoint);
        }
    }
}