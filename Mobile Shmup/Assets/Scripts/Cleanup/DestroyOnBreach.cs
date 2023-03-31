using Shmup.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Cleanup
{
    public class DestroyOnBreach : CleanupOffScreen
    {
        [SerializeField] Canvas breachCanvas;

        protected override void OnOffScreen()
        {
            Vector2 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
            if (viewportPos.y > 0) return;

            GameObject player = GameObject.FindWithTag("Player");

            if (player)
            {
                Health playerHealth = player.GetComponent<Health>();
                playerHealth.TakeDamage(1);

                Vector2 canvasViewportPos = new Vector2 (viewportPos.x, 0);
                Vector2 canvasWorldPos = Camera.main.ViewportToWorldPoint(canvasViewportPos);
                Instantiate(breachCanvas, canvasWorldPos, Quaternion.identity);
            }

            base.OnOffScreen();
        }
    }
}
