using Shmup.Equipment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Control.EnemyBehaviors
{
    public class ShootOnStart : MonoBehaviour
    {
        [SerializeField] float waitToFire = 0.3f;
        Gun gun;

        private void Awake()
        {
            gun = GetComponentInChildren<Gun>();
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(waitToFire);
            gun.Fire();
        }
    }
}
