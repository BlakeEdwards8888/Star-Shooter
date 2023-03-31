using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shmup.UI.Upgrades
{
    public class UpgradesPanel : MonoBehaviour
    {
        [SerializeField] TMP_Text currencyText;
        [SerializeField] UpgradeRow[] rows;

        private void Start()
        {
            UpdateUI();
        }

        public void UpdateUI()
        {
            int currency = PlayerPrefs.GetInt("Currency", 0);
            currencyText.text = currency > 0 ? $"#{currency}" : "";

            foreach(UpgradeRow row in rows)
            {
                row.UpdateRow();
            }
        }
    }
}
