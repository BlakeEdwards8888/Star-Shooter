using Shmup.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Control.EnemyBehaviors
{
    [RequireComponent(typeof(DynamicMover))]
    public class MoveSerpentine : MonoBehaviour, IAdditionalSettingsReceiver
    {
        [SerializeField] float changeDirectionRate = 0.2f;

        Vector2 direction = new Vector2(-0.25f, -0.75f);
        DynamicMover mover;
        float timeSinceChangedDirection = 0;

        private void Awake()
        {
            mover = GetComponent<DynamicMover>();
        }

        private void Start()
        {
            timeSinceChangedDirection = changeDirectionRate / 2;
        }

        private void Update()
        {
            timeSinceChangedDirection += Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if (timeSinceChangedDirection > changeDirectionRate)
            {
                FlipDirection();
                timeSinceChangedDirection = 0;
            }

            //keep moving in the set direction
            mover.Move(direction);
        }

        private void FlipDirection()
        {
            direction.x *= -1f;           
        }

        public void EvaluateSettings(List<string> settings)
        {
            if (settings.Contains("FlipDirection"))
                FlipDirection();
        }
    }
}
