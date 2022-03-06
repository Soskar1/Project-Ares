using System.Collections.Generic;
using UnityEngine;

namespace Core.Weapons
{
    public class Shotgun : Weapon
    {
        [Header("Shot Positions")]
        [SerializeField] private Transform _1stLevelShotPos;
        [SerializeField] private List<Transform> _2ndLevelShotPoints;
        [SerializeField] private List<Transform> _3rdLevelShotPoints;

        [Header("Other")]
        [SerializeField] private int _bulletCount;
        [Range(0, 25f)] [SerializeField] private float _spread;

        public override void Fire()
        {
            switch (_level)
            {
                case 1:
                    CreateBullet();
                    break;
                case 2:
                    CreateBullet(_2ndLevelShotPoints);
                    break;
                case 3:
                    CreateBullet(_3rdLevelShotPoints);
                    break;
                default:
                    CreateBullet(_3rdLevelShotPoints);
                    break;
            }
        }

        private void CreateBullet()
        {
            for (int index = 0; index < _bulletCount; index++)
            {
                BaseBullet bullet = _bulletPool.Get(_bullet);
                bullet.transform.position = _1stLevelShotPos.position;
                bullet.transform.rotation = _1stLevelShotPos.rotation;

                float rotZ = Random.Range(-_spread, _spread);
                bullet.Shot(_bulletPool, _effectsPool, _bulletStats, _target, rotZ);
            }
        }

        private void CreateBullet(List<Transform> shotPositions)
        {
            for (int i = 0; i < shotPositions.Count; i++)
            {
                for (int j = 0; j < _bulletCount; j++)
                {
                    BaseBullet bullet = _bulletPool.Get(_bullet);
                    bullet.transform.position = shotPositions[i].position;
                    bullet.transform.rotation = shotPositions[i].rotation;

                    float rotZ = Random.Range(-_spread, _spread);
                    bullet.Shot(_bulletPool, _effectsPool, _bulletStats, _target, rotZ);
                }
            }
        }
    }
}