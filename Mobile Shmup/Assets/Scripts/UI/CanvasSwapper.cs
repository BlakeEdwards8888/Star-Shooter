using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.UI
{
    public class CanvasSwapper : MonoBehaviour
    {
        [SerializeField] GameObject[] canvases;
        public void SwapCanvas(int activeCanvas)
        {
            for (int i = 0; i < canvases.Length; i++)
            {
                if (i == activeCanvas)
                {
                    canvases[i].SetActive(true);
                }
                else
                {
                    canvases[i].SetActive(false);
                }
            }
        }
    }
}
