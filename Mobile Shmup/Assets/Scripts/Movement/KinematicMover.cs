using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Movement
{
    public class KinematicMover : Mover
    {
        Vector2 v;

        public void MoveToPosition(Vector2 targetPosition)
        {
            float smoothTime = Vector2.Distance(transform.position, targetPosition) / maxSpeed;
            Vector2 newPos = Vector2.SmoothDamp(transform.position, targetPosition, ref v, smoothTime);
            rb2d.MovePosition(newPos);
        }
    }
}
