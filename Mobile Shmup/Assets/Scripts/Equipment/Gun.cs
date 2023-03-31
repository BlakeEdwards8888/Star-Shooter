using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shmup.Equipment
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform[] firePoints;
        [SerializeField] float bulletSpeed;
        [SerializeField] protected float fireRate;

        protected float timeSinceFired = Mathf.Infinity;

        public UnityEvent onFire;

        protected virtual void Update()
        {
            timeSinceFired += Time.deltaTime;
        }

        public virtual void Fire()
        {
            if(timeSinceFired >= fireRate)
            {
                foreach (Transform firePoint in firePoints)
                {
                    GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    Rigidbody2D bulletRb2d = bulletInstance.GetComponent<Rigidbody2D>();

                    bulletRb2d.velocity = firePoint.up * bulletSpeed;
                }

                timeSinceFired = 0;

                onFire?.Invoke();
            }
        }

    }
}
