using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup.SceneManagement
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadLevel(int level)
        {
            SceneManager.LoadScene(level);
        }
    }
}
