using Core.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Weapons
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons;
        [SerializeField] private Shooting _shooting;
        [SerializeField] private Input _input;

        private void OnEnable() => _input.OnWeaponSwitch += SwitchWeapon;
        private void OnDisable() => _input.OnWeaponSwitch -= SwitchWeapon;
        private void SwitchWeapon(int weaponId) => _shooting.TakeWeapon(_weapons[weaponId]);
    }
}