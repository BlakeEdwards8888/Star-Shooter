using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Control
{
    public class FaceTarget : MonoBehaviour
    {
        [SerializeField] float rotationSpeed;

        TargetingStrategy targetingStrategy;
        Transform target;

        private void Awake()
        {
            targetingStrategy = GetComponent<TargetingStrategy>();
            targetingStrategy.onTargetAcquired += GetTargetFromStrategy;
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null) return;


            Vector2 targetPos = target.position;

            targetPos.x = targetPos.x - transform.position.x;
            targetPos.y = targetPos.y - transform.position.y;

            float angle = (Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg) - 90; //adjusted for Up Vector

            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        public void GetTargetFromStrategy()
        {
            target = targetingStrategy.GetTarget();
        }

        private void OnDestroy()
        {
            targetingStrategy.onTargetAcquired -= GetTargetFromStrategy;
        }
    }
}
