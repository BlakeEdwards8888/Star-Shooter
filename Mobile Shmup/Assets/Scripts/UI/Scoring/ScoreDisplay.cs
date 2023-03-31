using Shmup.Scoring;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shmup.UI.Scoring
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;

        ScoreSystem scoreSystem;

        private void Start()
        {
            scoreSystem = FindObjectOfType<ScoreSystem>();
        }

        private void LateUpdate()
        {
            scoreText.text = scoreSystem.GetScore().ToString();
        }
    }
}
