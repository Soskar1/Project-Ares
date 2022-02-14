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

        //private void Update()
        //{
        //    if (_input.MouseWheel > 0)
        //    {
        //        Weapon activeWeapon = _shooting.weapon;

        //    }
        //    else if (_input.MouseWheel < 0)
        //    {

        //    }
        //}
    }
}