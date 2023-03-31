using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Equipment
{
    public class Equip : MonoBehaviour
    {
        [SerializeField] Gun[] equipableGuns;

        public Gun EquipGun(Gun gun)
        {
            int gunIndex = PlayerPrefs.GetInt("EquippedGun", 0);
            Gun equippedGun = Instantiate(equipableGuns[gunIndex], transform);
            return equippedGun;
        }
    }
}
