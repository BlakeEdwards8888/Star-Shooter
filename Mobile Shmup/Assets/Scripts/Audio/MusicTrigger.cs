using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Audio
{
    public class MusicTrigger : MonoBehaviour
    {
        [SerializeField] AudioClip clip;

        // Start is called before the first frame update
        void Start()
        {
            if (MusicPlayer.instance)
                MusicPlayer.instance.SwitchTracks(clip);
        }
    }
}
