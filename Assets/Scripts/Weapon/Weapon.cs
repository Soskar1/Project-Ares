using UnityEngine;

namespace Core.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Weapon")]
        [SerializeField] protected BaseBullet _bullet;
        [SerializeField] protected LayerMask _target;
        [SerializeField] protected BulletStats _bulletStats;
        [SerializeField] private float _delay;

        [Header("Upgrade")]
        [SerializeField] protected int _level = 1;
        [SerializeField] private int _maxLevel;
        [SerializeField] private float _delayDecreasingCoefficient;
        [SerializeField] private float _damageIncreasingCoefficient;

        protected BulletPool _bulletPool;
        protected EffectsPool _effectsPool;

        private float _defaultDelay;
        private float _defaultDamage;

        public float Delay => _delay;
        public int Level => _level;

        private void Awake()
        {
            _defaultDelay = _delay;
            _defaultDamage = _bulletStats.damage;
        }

        public void Initialize(BulletPool bulletPool, EffectsPool effectsPool)
        {
            _bulletPool = bulletPool;
            _effectsPool = effectsPool;
        }

        public abstract void Fire();

        [ContextMenu("Upgrade")]
        public void Upgrade()
        {
            if (_level >= _maxLevel)
            {
                _delay -= _delayDecreasingCoefficient;
                return;
            }

            _level++;

            if (_level == _maxLevel)
                _bulletStats.damage += _damageIncreasingCoefficient;
        }

        public void Degrade()
        {
            if (_level >= _maxLevel)
            {
                _delay = _defaultDelay;
                _bulletStats.damage = _defaultDamage;
            }

            _level--;
        }

        public bool LevelCheck()
        {
            return _level > 1;
        }
    }
}