using Shmup.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Control.EnemyBehaviors
{
    public class MoveForward: MonoBehaviour
    {
        DynamicMover mover;

        private void Awake()
        {
            mover = GetComponent<DynamicMover>();
        }

        private void FixedUpdate()
        {
            mover.Move(transform.up);
        }
    }
}
