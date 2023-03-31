using Shmup.Progression;
using Shmup.Scoring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Movement
{
    public abstract class Mover : MonoBehaviour, IProgressable
    {
        [SerializeField] protected float maxSpeed;

        protected Rigidbody2D rb2d;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public void SetStat(BaseStats baseStats)
        {
            maxSpeed = baseStats.GetStat(Stat.Speed, maxSpeed);
        }
    }
}
