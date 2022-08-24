using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDevEVO 
{
 public class ButtonsGenerator : MonoBehaviour
 {
        [SerializeField]
        private Button m_ButtonPrefab;
        [SerializeField]
        private GameObject m_Content;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            LevelsData levelsData = new LevelsData();
            LevelsProgress levelsProgress = levelsData.GetLevelsProgress();

            for (int i= 0; i < levelsProgress.Levels.Count; i++)
            {
                Button button = Instantiate(m_ButtonPrefab, m_Content.transform);
                if(button.gameObject.TryGetComponent(out LevelButton levelButton))
                {
                    levelButton.SetData(levelsProgress.Levels[i], i);
                }
            }

            LoadingScreen.Screen.Enable(false);

        }
    }
}