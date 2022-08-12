using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class AudioController : MonoBehaviour
 {
        public static AudioController Audio = null;
        private AudioState m_AudioState;
        [SerializeField] private AudioSource m_BackgroundSource;

        private void Awake()
        {
            if (Audio == null)
            {
                Audio = this;
                DontDestroyOnLoad(gameObject);
                m_AudioState = new AudioState();
                if (m_AudioState.GetAudioValues().Music) m_BackgroundSource.Play();

            }

            else
            {
                Destroy(gameObject);
            }
        }

        public void ChangeMusic()
        {
            m_AudioState.EnableMusic(!m_AudioState.GetAudioValues().Music);
            if (m_AudioState.GetAudioValues().Music)
            {
                m_BackgroundSource.Play();
            }
            else
            {
                m_BackgroundSource.Stop();
            }

        }

        public void ChageSound()
        {
            m_AudioState.EnableMusic(!m_AudioState.GetAudioValues().Sound);
        }

        public bool GetSoundValue()
        {
            return m_AudioState.GetAudioValues().Sound;
        }

        public bool GetMusicValue()
        {
            return m_AudioState.GetAudioValues().Music;
        }
    }
}