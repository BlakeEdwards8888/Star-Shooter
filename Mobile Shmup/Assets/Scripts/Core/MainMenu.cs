using Shmup.Scoring;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup.Core
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] TMP_Text bestText;

        private void Start()
        {
            int highScore = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
            if (highScore > 0)
            {
                bestText.SetText($"High Score:\n{highScore}");
            }
            else
            {
                bestText.gameObject.SetActive(false);
            }
        }

        public void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            Start();
        }
    }
}
