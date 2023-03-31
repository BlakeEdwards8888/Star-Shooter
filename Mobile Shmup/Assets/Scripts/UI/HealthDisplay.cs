using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shmup.Attributes;
using UnityEngine.UI;

namespace Shmup.UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] Image playerLifeUI;
        [SerializeField] GameObject lifeDownEffect;

        Health playerHealth;
        float maxHealth;
        List<Image> playerHealthBar = new List<Image>();

        private void Awake()
        {
            playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        // Start is called before the first frame update
        void Start()
        {
            maxHealth = playerHealth.GetHealth();

            for(int i = 0; i < maxHealth; i++)
            {
                Image lifeUIInstance = Instantiate(playerLifeUI, transform);
                playerHealthBar.Add(lifeUIInstance);
            }

            playerHealth.onHealthChange += UpdateLifeBar;
        }

        public void UpdateLifeBar()
        {
            float health = playerHealth.GetHealth();

            for(int i = 0; i < playerHealthBar.Count; i++)
            {
                if(i < health)
                {
                    playerHealthBar[i].enabled = true;
                }
                else if(i >= health && playerHealthBar[i].enabled == true)
                {
                    Vector2 effectPos = Camera.main.ScreenToWorldPoint(playerHealthBar[i].transform.position);
                    Instantiate(lifeDownEffect, effectPos, Quaternion.identity);
                    playerHealthBar[i].enabled = false;
                }
            }
        }

        private void OnDisable()
        {
            playerHealth.onTakeDamage.RemoveListener(UpdateLifeBar);
        }

    }
}
