using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Control
{
    public class AcquireNearestTarget : TargetingStrategy
    {
        [SerializeField] float range = 2;
        [SerializeField] LayerMask targetMask;
        [SerializeField] float checkFrequency = 0.2f;

        float timeSinceChecked = 0;
        Transform target = null;

        public override event Action onTargetAcquired;

        // Update is called once per frame
        void Update()
        {
            timeSinceChecked += Time.deltaTime;

            if(timeSinceChecked >= checkFrequency && target == null)
            {
                target = CheckForTarget();
                onTargetAcquired?.Invoke();
            }
        }

        private Transform CheckForTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, Vector2.up, 0, targetMask);

            if (hits.Length == 0) return null;

            float[] distances = new float[hits.Length];
            for (int i = 0; i < hits.Length; i++)
            {
                distances[i] = hits[i].distance;
            }
            Array.Sort(distances, hits);

            return hits[0].transform;
        }

        public override Transform GetTarget()
        {
            return target;
        }
    }
}
