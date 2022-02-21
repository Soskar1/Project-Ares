using Core.Weapons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Entities
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemies _enemies;
        [SerializeField] private Vector2 _firstPoint;
        [SerializeField] private Vector2 _secondPoint;
        [SerializeField] private float _delay;
        private EnemyFactory _enemyFactory;
        private Pool<BaseEnemy> _enemyPool;
        private Pool<BaseBullet> _bulletPool;

        private bool _timerStarted = false;

        private void Update()
        {
            if (_timerStarted == true)
                return;

            _timerStarted = true;
            StartCoroutine(Timer.Start(_delay, () => { Spawn(); _timerStarted = false; }));
        }

        public void Initialize(Pool<BaseEnemy> enemyPool, Pool<BaseBullet> bulletPool)
        {
            _enemyFactory = new EnemyFactory();
            _enemyFactory.Initialize(_enemies, SceneManager.GetActiveScene().buildIndex);

            _enemyPool = enemyPool;
            _bulletPool = bulletPool;
        }

        private void Spawn()
        {
            EnemyStats stats = _enemyFactory.GetInstance(SceneManager.GetActiveScene().buildIndex);
            BaseEnemy enemy = _enemyPool.GetObjectFromPool();
            enemy.Initialize(stats, _enemyPool, _bulletPool);
            enemy.transform.position = TakeRandomPosition();
        }

        private Vector2 TakeRandomPosition()
        {
            float x = Random.Range(_firstPoint.x, _secondPoint.x);
            float y = Random.Range(_firstPoint.y, _secondPoint.y);
            return new Vector2(x, y);
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