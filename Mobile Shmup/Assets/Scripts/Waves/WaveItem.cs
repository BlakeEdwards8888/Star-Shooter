using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Waves
{
    [System.Serializable]
    public class WaveItem
    {
        [System.Serializable]
        public class SpawnConfig
        {
            public GameObject enemyPrefab;
            public Vector2 viewportSpawnPosition;
            public List<string> additionalSettings = new List<string>();
        }

        public SpawnConfig[] spawnConfigs;
        public float waitForNext;
    }
}