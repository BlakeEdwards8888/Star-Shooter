using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Cleanup
{
    public class CleanupOffScreen : MonoBehaviour
    {
        [SerializeField] Renderer[] renderers;
        [SerializeField] float checkFrequency;

        float timeSinceChecked = Mathf.Infinity;

        private void Update()
        {
            timeSinceChecked += Time.deltaTime;
            if (timeSinceChecked >= checkFrequency)
            {
                CheckRenderers();
            }
        }

        private void CheckRenderers()
        {
            List<Renderer> invisibleRenderers = new List<Renderer>();

            foreach (Renderer renderer in renderers)
            {
                if (renderer.isVisible) continue;
                invisibleRenderers.Add(renderer);
            }

            if(invisibleRenderers.Count >= renderers.Length)
            {
                OnOffScreen();
            }

            timeSinceChecked = 0;
        }

        protected virtual void OnOffScreen() 
        {
            Destroy(gameObject);
        }
    }
}
