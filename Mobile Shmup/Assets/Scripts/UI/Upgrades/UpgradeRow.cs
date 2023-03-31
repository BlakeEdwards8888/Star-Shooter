using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shmup.UI.Upgrades
{
    public class UpgradeRow : MonoBehaviour
    {
        [SerializeField] string unlockKey;
        [SerializeField] int equipIndex;
        [SerializeField] Button unlockButton, equipButton;
        [SerializeField] int price;

        UpgradesPanel upgradesPanel;

        private void Awake()
        {
            upgradesPanel = FindObjectOfType<UpgradesPanel>();
        }

        private void Start()
        {
            UpdateRow();
        }

        public void UpdateRow()
        {
            if (!PlayerPrefs.HasKey(unlockKey) && unlockKey != "DefaultGun")
            {
                equipButton.gameObject.SetActive(false);
                unlockButton.gameObject.SetActive(true);
                TMP_Text buttonText = unlockButton.GetComponentInChildren<TMP_Text>();
                buttonText.text = $"Unlock\n#{price}";
                unlockButton.interactable = price <= PlayerPrefs.GetInt("Currency", 0);
            }
            else
            {
                equipButton.gameObject.SetActive(true);
                unlockButton.gameObject.SetActive(false);
                equipButton.interactable = PlayerPrefs.GetInt("EquippedGun", 0) != equipIndex;
            }
        }

        public void SetEquippedGun()
        {
            PlayerPrefs.SetInt("EquippedGun", equipIndex);
            upgradesPanel.UpdateUI();
        }

        public void Unlock()
        {
            PlayerPrefs.SetString(unlockKey, "");

            int currency = PlayerPrefs.GetInt("Currency");
            PlayerPrefs.SetInt("Currency", currency - price);

            upgradesPanel.UpdateUI();
        }
    }
}
