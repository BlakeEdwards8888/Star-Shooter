using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Shmup.Movement;
using Shmup.Equipment;
using System;

namespace Shmup.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float touchOffset = 0.5f;

        Equip equip;
        Gun gun;
        KinematicMover mover;
        Vector2 moveDirection;
        Vector2 targetPosition;

        private void Awake()
        {
            mover = GetComponent<KinematicMover>();
            equip = GetComponent<Equip>();
            gun = equip.EquipGun(null);
        }

        private void Update()
        {
#if UNITY_ANDROID
            if (Touchscreen.current.primaryTouch.press.isPressed)
            {
                gun.Fire();
                HandleMovement();
            }
#elif UNITY_WEBGL
            if (Mouse.current.press.isPressed)
            {
                gun.Fire();
                HandleMovement();
            }
#endif
        }

        void FixedUpdate()
        {
#if UNITY_ANDROID
            if (Touchscreen.current.primaryTouch.press.isPressed)
            {
                mover.MoveToPosition(targetPosition);
            }
#elif UNITY_WEBGL
            if (Mouse.current.press.isPressed)
            {
                mover.MoveToPosition(targetPosition);
            }
#endif
        }

        private void HandleMovement()
        {
            Vector2 screenPos = new Vector2();
#if UNITY_ANDROID
            screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
#elif UNITY_WEBGL
            screenPos = Mouse.current.position.ReadValue();
#endif
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.y += touchOffset;
            targetPosition = worldPos;
            moveDirection = (worldPos - (Vector2)transform.position).normalized;
        }

    }
}
