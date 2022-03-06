using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    public class InventoryHUD : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _weaponList;
        [SerializeField] private Input _input;

        private void OnEnable() => _input.OnWeaponSwitch += ChangeWeaponUI;
        private void OnDisable() => _input.OnWeaponSwitch -= ChangeWeaponUI;

        private void ChangeWeaponUI(int weaponID)
        {
            DisableAllUI();
            _weaponList[weaponID].SetActive(true);
        }

        private void DisableAllUI()
        {
            foreach (GameObject weapon in _weaponList)
                weapon.SetActive(false);
        }
    }
}