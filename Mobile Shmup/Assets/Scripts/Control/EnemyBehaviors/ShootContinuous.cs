using Shmup.Equipment;
using Shmup.Progression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Control.EnemyBehaviors
{
    public class ShootContinuous : MonoBehaviour, IProgressable
    {
        [SerializeField] float fireRate;
        Gun gun;

        float timeSincefired = 0;

        private void Awake()
        {
            gun = GetComponentInChildren<Gun>();
        }

        private void Update()
        {
            timeSincefired += Time.deltaTime;

            if (timeSincefired >= fireRate)
            {
                gun.Fire();
                timeSincefired = 0;
            }
        }

        public void SetStat(BaseStats baseStats)
        {
            fireRate = baseStats.GetStat(Stat.FireRate, fireRate);
        }

    }
}
