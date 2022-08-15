using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class BallSound : MonoBehaviour
 {
        [SerializeField]
        private AudioSource m_AudioSource;
        [Space]
        [SerializeField]
        private AudioClip m_Awake;
        [SerializeField]
        private AudioClip m_Collision;

        public void PlaySoundAwake()
        {
            if (AudioController.Audio.GetSoundValue())
            {
                m_AudioSource.PlayOneShot(m_Awake);
            }
        }

        public void PlaySoundCollision()
        {
            if (AudioController.Audio.GetSoundValue())
            {
                m_AudioSource.PlayOneShot(m_Collision);
            }
        }
 }

}