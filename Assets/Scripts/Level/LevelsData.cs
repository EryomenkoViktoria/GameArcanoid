using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class LevelsData 
    {
        private const string KeyName = "Save";
        private LevelsProgress m_LevelsProgres = new LevelsProgress();

        private void SaveData()
        {
            string saveJson = JsonUtility.ToJson(m_LevelsProgres);
            PlayerPrefs.SetString(KeyName, saveJson);
            PlayerPrefs.Save();
        }

        public void NewData()
        {
            var levelsCount = Resources.LoadAll<GameLevel>("Levels").Length;

            for(int i = 0; i < levelsCount; i++)
            {
                m_LevelsProgres.Levels.Add(new Progress());

            }

            m_LevelsProgres.Levels[0].IsOpened = true;
            SaveData();
            Resources.UnloadUnusedAssets();
        }

        public LevelsProgress GetLevelsProgress()
        {
            if (PlayerPrefs.HasKey(KeyName))
            {
                string saveJson = PlayerPrefs.GetString(KeyName);
                m_LevelsProgres = JsonUtility.FromJson<LevelsProgress>(saveJson);
            }

            else
            {
                NewData();
            }
            return m_LevelsProgres;
        }

        public void SaveLevelData(int index, Progress progress)
        {
            m_LevelsProgres = GetLevelsProgress();
            m_LevelsProgres.Levels[index] = progress;

            if(index< m_LevelsProgres.Levels.Count - 1)
            {
                m_LevelsProgres.Levels[index + 1].IsOpened = true;
            }
            m_LevelsProgres.Levels[index + 1].IsOpened = true;
            SaveData();
        }

        public void Clear()
        {
            PlayerPrefs.DeleteKey(KeyName);
        }
    }
}