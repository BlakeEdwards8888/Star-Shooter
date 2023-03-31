using Shmup.Ads;
using Shmup.Attributes;
using Shmup.Scoring;
using Shmup.UI.Scoring;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Shmup.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] TMP_Text scoreText, bestText, currencyText;
        [SerializeField] Vector2 playerSpawnPoint;
        [SerializeField] Button continueButton;

        Health playerHealth;
        ScoreSystem scoreSystem;
        ScoreDisplay scoreDisplay;
        HealthDisplay healthDisplay;
        GameObject player;

        private void Start()
        {
            scoreSystem = FindObjectOfType<ScoreSystem>();
            scoreDisplay = FindObjectOfType<ScoreDisplay>();
            healthDisplay = FindObjectOfType<HealthDisplay>();
            player = GameObject.FindWithTag("Player");
            playerHealth = player.GetComponent<Health>();
            playerHealth.onDeath.AddListener(GameOver);
        }

        public void TogglePanel(bool toggle)
        {
            gameOverPanel.SetActive(toggle);
        }

        void GameOver()
        {
            scoreDisplay.gameObject.SetActive(false);

            int score = scoreSystem.GetScore();

            scoreText.SetText($"Score: {score}");

            int savedScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
            int best = savedScore > score ? savedScore : score;

            bestText.SetText($"Best: {best}");

            int currencyReward = score / 100;
            currencyText.SetText($"#{currencyReward}");
            PlayerPrefs.SetInt("Currency", currencyReward);

            TogglePanel(true);
        }

        public void ContinueButton()
        {
            AdManager.instance.ShowAd(this);
            continueButton.interactable = false;
        }

        public void ContinueGame()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            player.transform.position = playerSpawnPoint;
            player.SetActive(true);
            playerHealth.SetHealth(3);  //TODO change this according to upgrades
            healthDisplay.UpdateLifeBar();
            scoreDisplay.gameObject.SetActive(true);
            continueButton.interactable = false;
            TogglePanel(false);
        }

        private void OnDisable()
        {
            playerHealth.onDeath.RemoveListener(GameOver);
        }
    }
}
