using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Scoring
{
    public class ScoreSystem : MonoBehaviour
    {
        public static ScoreSystem instance;

        [SerializeField] float startingScore = 0;
        [SerializeField] float scorePerSecond;
        [SerializeField] float[] levelTable;
        float score;

        public const string HighScoreKey = "HighScore";

        private void Awake()
        {
            instance = this;
            score = startingScore;
        }

        private void Update()
        {
            if (!GameObject.FindWithTag("Player")) return;
            AddScore(scorePerSecond * Time.deltaTime);
        }

        public int GetScore()
        {
            return Mathf.FloorToInt(score);
        }

        public int GetLevel()
        {
            for(int level = 0; level < levelTable.Length; level++)
            {
                if(levelTable[level] > score)
                {
                    return level;
                }
            }
            return levelTable.Length - 1;
        }

        public void AddScore(float amount)
        {
            score += amount;
        }

        void OnDestroy()
        {
            int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

            if (score > currentHighScore)
            {
                PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
            }
        }
    }
}
