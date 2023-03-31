using Shmup.Progression;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shmup.Attributes
{
    public class Health : MonoBehaviour, IProgressable
    {
        [SerializeField] float currentHealth;
        [SerializeField] GameObject deathEffect;

        public UnityEvent onDeath;
        public UnityEvent onTakeDamage;
        public event Action onHealthChange;

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            onHealthChange?.Invoke();

            if (currentHealth <= 0)
            {
                onDeath?.Invoke();
                Death();
            }
            else
            {
                onTakeDamage?.Invoke();
            }
        }

        public float GetHealth()
        {
            return currentHealth;
        }

        //Temporary function for setting health on continue while upgrades have not been
        //implemented
        public void SetHealth(float newHealth)
        {
            currentHealth = newHealth;
        }

        public void Death()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            if (gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetStat(BaseStats baseStats)
        {
            currentHealth = baseStats.GetStat(Stat.Health, currentHealth);
        }
    }
}
