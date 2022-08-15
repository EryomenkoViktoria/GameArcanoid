using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class SettingWindow : MonoBehaviour
 {
        [SerializeField] private AudioButton m_Sound;

        [SerializeField] private AudioButton m_Music;
        private void OnEnable()
        {
            m_Music.SetState(AudioController.Audio.GetMusicValue());
            m_Sound.SetState(AudioController.Audio.GetSoundValue());

        }

        public void ChangeSound()
        {
            AudioController.Audio.ChageSound();
        }

        public void ChangeMusic()
        {
            AudioController.Audio.ChangeMusic();
        }

        public void ClearProgress()
        {
            LevelIndex levelIndex = new LevelIndex();
            levelIndex.Clear();
            LevelsData levelsData = new LevelsData();
            levelsData.Clear();
            Loader loader = new Loader();
            loader.LoadingMainScene(true);
        }
    }
}