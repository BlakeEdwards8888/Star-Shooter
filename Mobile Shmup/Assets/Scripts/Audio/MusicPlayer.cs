using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup.Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        public static MusicPlayer instance;

        AudioSource audioSource;

        // Start is called before the first frame update
        void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                audioSource = GetComponent<AudioSource>();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SwitchTracks(AudioClip track)
        {
            if (track == audioSource.clip) return;

            audioSource.Stop();
            audioSource.clip = track;
            audioSource.Play();
        }
    }
}
