using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Movement
{
    public class FlatRateMover : DynamicMover
    {
        public override void Move(Vector2 direction)
        {
            rb2d.velocity = direction * maxSpeed;
        }
    }
}
