using Shmup.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Core
{
    public class CameraBehavior : MonoBehaviour
    {
        Animator anim;
        Health playerHealth;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
            playerHealth.onTakeDamage.AddListener(ShakeScreen);
        }

        void ShakeScreen()
        {
            if (playerHealth.GetHealth() == 0) return;
            anim.ResetTrigger("Shake");
            anim.SetTrigger("Shake");
        }

        private void OnDisable()
        {
            playerHealth.onTakeDamage.RemoveListener(ShakeScreen);
        }
    }
}
