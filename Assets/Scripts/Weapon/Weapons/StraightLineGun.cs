using System.Collections.Generic;
using UnityEngine;

namespace Core.Weapons
{
    public class StraightLineGun : Weapon
    {
        [Header("Shot Positions")]
        [SerializeField] private Transform _1stLevelShotPos;
        [SerializeField] private List<Transform> _2ndLevelShotPoints;
        [SerializeField] private List<Transform> _3rdLevelShotPoints;

        public override void Fire()
        {
            switch(_level)
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
            BaseBullet bullet = _bulletPool.Get(_bullet);
            bullet.transform.position = _1stLevelShotPos.position;
            bullet.transform.rotation = _1stLevelShotPos.rotation;

            bullet.Shot(_bulletPool, _effectsPool, _bulletStats, _target);
        }

        private void CreateBullet(List<Transform> shotPositions)
        {
            for (int index = 0; index < shotPositions.Count; index++)
            {
                BaseBullet bullet = _bulletPool.Get(_bullet);
                bullet.transform.position = shotPositions[index].position;
                bullet.transform.rotation = shotPositions[index].rotation;

                bullet.Shot(_bulletPool, _effectsPool, _bulletStats, _target);
            }
        }
    }
}