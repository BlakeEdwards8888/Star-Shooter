using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Progression
{
    public class BaseStats : MonoBehaviour
    {
        [SerializeField] ProgressionTable progressionTable;
        [SerializeField] ShipType shipType;

        int level;

        public void SetLevel(int newLevel)
        {
            level = newLevel;

            foreach(IProgressable progressable in GetComponents<IProgressable>())
            {
                progressable.SetStat(this);
            }
        }

        public void SendAdditionalSettings(List<string> additionalSettings)
        {
            foreach (var receiver in GetComponents<IAdditionalSettingsReceiver>())
            {
                receiver.EvaluateSettings(additionalSettings);
            }
        }

        public float GetStat(Stat stat, float defaultValue)
        {
            float progressionStat = progressionTable.GetStat(stat, shipType, level);
            return progressionStat > 0 ? progressionStat : defaultValue;
        }


    }
}
