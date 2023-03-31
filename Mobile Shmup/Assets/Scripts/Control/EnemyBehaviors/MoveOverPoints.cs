using Shmup.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Control.EnemyBehaviors
{
    [RequireComponent(typeof(KinematicMover))]
    public class MoveOverPoints : MonoBehaviour, IAdditionalSettingsReceiver
    {
        [SerializeField] List<Vector2> viewportPoints = new List<Vector2>();

        KinematicMover mover;
        Vector2 targetPosition;
        int pointIndex = 0;

        // Start is called before the first frame update
        void Awake()
        {
            mover = GetComponent<KinematicMover>();
            targetPosition = GetWorldPosition(viewportPoints[pointIndex]);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if((Vector2)transform.position != targetPosition)
            {
                mover.MoveToPosition(targetPosition);
            }
            else
            {
                CyclePoints();
            }
        }

        private void CyclePoints()
        {
            if (pointIndex == viewportPoints.Count - 1)
            {
                pointIndex = 0;
            }
            else
            {
                pointIndex++;
            }

            targetPosition = GetWorldPosition(viewportPoints[pointIndex]);
        }

        private Vector2 GetWorldPosition(Vector2 viewportPosition)
        {
            return Camera.main.ViewportToWorldPoint(viewportPosition);
        }

        public void EvaluateSettings(List<string> settings)
        {
            if (settings.Contains("ReverseDirection"))
            {
                viewportPoints.Reverse();
                targetPosition = GetWorldPosition(viewportPoints[pointIndex]);
            }
        }
    }
}
