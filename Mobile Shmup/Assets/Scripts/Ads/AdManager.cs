using Shmup.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Shmup.Ads
{
    public class AdManager : MonoBehaviour, IUnityAdsListener
    {
        [SerializeField] bool testMode = true;

        public static AdManager instance;

        string gameId = "4307571";

        GameOverScreen gameOverScreen;

        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                Advertisement.AddListener(this);
                Advertisement.Initialize(gameId, testMode);
            }
            else
            {
                Destroy(gameObject);
            }
        }


        public void OnUnityAdsDidError(string message)
        {
            Debug.LogError(message);
        }

        public void ShowAd(GameOverScreen gameOverScreen)
        {
            this.gameOverScreen = gameOverScreen;

            Advertisement.Show("Rewarded_Video");
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Finished:
                    gameOverScreen.ContinueGame();
                    break;
                case ShowResult.Skipped:
                    gameOverScreen.ContinueGame();
                    break;
                case ShowResult.Failed:
                    Debug.LogWarning("Ad Failed");
                    break;
            }
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            Debug.Log("Ad Started");
        }

        public void OnUnityAdsReady(string placementId)
        {
            Debug.Log("Unity Ads Ready");
        }
    }
}
