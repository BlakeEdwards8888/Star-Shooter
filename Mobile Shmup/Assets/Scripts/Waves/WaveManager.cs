using Shmup.Scoring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Waves
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] WaveConfig[] waveConfigs;
        [SerializeField] float timeBetweenWaves;

        float timeSinceWaveEnded;
        bool waveInProgress = false;

        List<WaveConfig> availableWaves = new List<WaveConfig>();

        private void Update()
        {
            if (!GameObject.FindWithTag("Player")) return;
            if (waveInProgress) return;

            timeSinceWaveEnded += Time.deltaTime;

            if(timeSinceWaveEnded >= timeBetweenWaves)
            {
                BuildWaveTable();

                WaveConfig waveConfig = availableWaves[Random.Range(0, availableWaves.Count)];
                waveConfig.SetLevel(ScoreSystem.instance.GetLevel());
                StartCoroutine(waveConfig.StartWave(WaveFinished));
                waveInProgress = true;
            }
        }

        void WaveFinished()
        {
            waveInProgress = false;
            timeSinceWaveEnded = 0;
        }

        void BuildWaveTable()
        {
            availableWaves.Clear();

            float score = ScoreSystem.instance.GetScore();

            foreach(WaveConfig waveConfig in waveConfigs)
            {
                if(waveConfig.IsInRange(score))
                    availableWaves.Add(waveConfig);
            }
        }
    }
}
