using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class AudioState : MonoBehaviour
 {
        private AudioValues m_AudioValues = new AudioValues();
        private const string Key = "Audio";

        public AudioValues GetAudioValues()
        {
            if (PlayerPrefs.HasKey(Key))
            {
                m_AudioValues = JsonUtility.FromJson<AudioValues>(PlayerPrefs.GetString(Key));
            }
           
            else
            {
                Create();
            }

            return m_AudioValues;
        }

        public void EnableMusic(bool value)
        {
            m_AudioValues.Music = value;
            Save();
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(Key);
        }
        public void EnableSound(bool value)
        {
            m_AudioValues.Sound = value;
            Save();
        }

        private void Create()
        {
            m_AudioValues.Music = true;
            m_AudioValues.Sound = true;
            Save();
        }

        private void Save()
        {
            string save =JsonUtility.ToJson(m_AudioValues);
            PlayerPrefs.SetString(Key, save);
            PlayerPrefs.Save();
        }
    }

    [System.Serializable]
    public class AudioValues
    {
        public bool Music;
        public bool Sound;
    }
}