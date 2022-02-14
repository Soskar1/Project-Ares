using UnityEngine;

namespace Core.Entities
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private EnemyPool _pool;
        [SerializeField] private Vector2 _firstPoint;
        [SerializeField] private Vector2 _secondPoint;
        [SerializeField] private float _delay;

        private bool _timerStarted = false;

        private void Update()
        {
            if (_timerStarted == true)
                return;

            _timerStarted = true;
            StartCoroutine(Timer.Start(_delay, () => { Spawn(); _timerStarted = false; }));
        }

        private void Spawn()
        {
            float x = Random.Range(_firstPoint.x, _secondPoint.x);
            float y = Random.Range(_firstPoint.y, _secondPoint.y);
            Vector2 spawnPoint = new Vector2(x, y);

            Enemy enemy = _pool.enemyPool.Get();
            enemy.transform.position = spawnPoint;
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