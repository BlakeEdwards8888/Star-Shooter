using Shmup.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Combat
{
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField] protected float damage;
        [SerializeField] protected bool hitsPlayer = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (hitsPlayer && !other.CompareTag("Player")) return;
            if (!hitsPlayer && other.CompareTag("Player")) return;

            Health health = other.GetComponent<Health>();

            if (!health) return;

            health.TakeDamage(damage);

            CollisionEffect();
        }

        protected virtual void CollisionEffect() 
        {
            Destroy(gameObject);
        }
    }
}
