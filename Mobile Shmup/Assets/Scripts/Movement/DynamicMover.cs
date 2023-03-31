using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Movement
{
    public class DynamicMover : Mover
    {
        [SerializeField] float acceleration;

        public virtual void Move(Vector2 direction)
        {
            rb2d.AddForce(direction * acceleration, ForceMode2D.Force);
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
        }
    }
}
