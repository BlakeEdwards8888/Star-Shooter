using Shmup.Progression;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Waves
{
    [CreateAssetMenu(fileName = "New Wave", menuName = "Wave")]
    public class WaveConfig: ScriptableObject
    {
        [SerializeField] WaveItem[] waveItems;
        [SerializeField] Vector2 scoreRange;
        //[SerializeField] List<string> additionalSettings = new List<string>();

        int level;

        public bool IsInRange(float score)
        {
            return (score >= scoreRange.x || scoreRange.x < 0)
                && (score <= scoreRange.y || scoreRange.y < 0);
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }

        public IEnumerator StartWave(Action finished)
        {
            foreach(WaveItem waveItem in waveItems)
            {
                foreach(WaveItem.SpawnConfig spawnConfig in waveItem.spawnConfigs)
                {
                    Vector2 spawnPoint = Camera.main.ViewportToWorldPoint(spawnConfig.viewportSpawnPosition);
                    GameObject spawn = Instantiate(spawnConfig.enemyPrefab, spawnPoint, spawnConfig.enemyPrefab.transform.rotation);

                    BaseStats baseStats = spawn.GetComponent<BaseStats>();
                    baseStats.SetLevel(level);

                    if (spawnConfig.additionalSettings.Count > 0)
                        baseStats.SendAdditionalSettings(spawnConfig.additionalSettings);
                }

                yield return new WaitForSeconds(waveItem.waitForNext);
            }

            finished();
        }
    }
}
