using UnityEngine;

namespace Core.Weapons
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        private void OnEnable()
        {
            if (Pool<Bullet>.pool != null)
            {
                Debug.Log("������ �������");
                StartCoroutine(Timer.Start(_lifeTime, () => { Pool<Bullet>.pool.Release(this); }));
            }
            else
            {
                Debug.LogWarning("��� ���� �� ��� ������, ������� ������ ����� ���������!");
                Destroy(gameObject, _lifeTime);
            }
        }

        private void Update() => transform.Translate(Vector2.right * _speed * Time.deltaTime);

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.TryGetComponent(out IDamage target))
        //    {
        //        Debug.Log(collision.name);
        //        target.OnHit(_damage);
        //    }
        //}
    }
}