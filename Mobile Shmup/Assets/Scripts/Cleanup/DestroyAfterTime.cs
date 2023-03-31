using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Cleanup
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] float aliveTime;

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, aliveTime);
        }
    }
}
