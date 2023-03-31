using Shmup.Progression;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shmup.Scoring
{
    public class ScoreGiver : MonoBehaviour, IProgressable
    {
        [SerializeField] float scoreReward;
        [SerializeField] Canvas scoreRewardCanvasPrefab;

        ScoreSystem scoreSystem;

        private void Start()
        {
            scoreSystem = FindObjectOfType<ScoreSystem>();
        }

        public void RewardPoints()
        {
            scoreSystem.AddScore(scoreReward);
            Canvas scoreCanvasInstance = Instantiate(scoreRewardCanvasPrefab, transform.position, Quaternion.identity);
            scoreCanvasInstance.GetComponentInChildren<TMP_Text>().SetText($"+{scoreReward}");
        }

        public void SetStat(BaseStats baseStats)
        {
            scoreReward = baseStats.GetStat(Stat.ScoreReward, scoreReward);
        }
    }
}
