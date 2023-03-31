using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Progression
{
    [CreateAssetMenu(fileName = "Progression Table", menuName = "Progression Table")]
    public class ProgressionTable : ScriptableObject
    {
        [SerializeField] ProgressionEntry[] progressionEntries;

        Dictionary<ShipType, Dictionary<Stat, float[]>> lookupTable;

        public float GetStat(Stat stat, ShipType shipType, int level)
        {
            BuildLookup();

            if (!lookupTable[shipType].ContainsKey(stat))
            {
                Debug.LogError($"No progression entry for {shipType} {stat}");
                return 0;
            }

            float[] levels = lookupTable[shipType][stat];

            if(levels.Length == 0)
            {
                Debug.LogError($"No stat data for {shipType} {stat}");
                return 0;
            }

            if (levels.Length - 1 < level)
            {
                return levels[levels.Length - 1];
            }

            return levels[level];
        }

        void BuildLookup()
        {
            if (lookupTable != null) return;

            lookupTable = new Dictionary<ShipType, Dictionary<Stat, float[]>>();

            foreach (ProgressionEntry progressionEntry in progressionEntries)
            {
                var statLookupTable = new Dictionary<Stat, float[]>();

                foreach(StatProgression statProgression in progressionEntry.statProgressions)
                {
                    statLookupTable[statProgression.stat] = statProgression.levels;
                }

                lookupTable[progressionEntry.shipType] = statLookupTable;
            }
        }

        [System.Serializable]
        public struct ProgressionEntry
        {
            public ShipType shipType;
            public StatProgression[] statProgressions;
        }

        [System.Serializable]
        public struct StatProgression
        {
            public Stat stat;
            public float[] levels;    //x is the key, y is the value
        }
    }
}
