using UnityEngine;

namespace Core.Entities
{
    public class Spawner : MonoBehaviour
    {
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
            BaseEnemy enemy = Pool<BaseEnemy>.pool.Get();
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