using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDevEVO 
{
 public class LevelButton : MonoBehaviour
 {
        [SerializeField]
        private Button m_Button;
        [SerializeField] 
        private Text m_ButtonText;
        [SerializeField]
        private Image m_StartImage;
        [SerializeField] 
        private Sprite[] m_StarsSprites;
        private int m_Index;

        public void SetData(Progress progress, int index)
        {
            m_ButtonText.text= (index+1).ToString();
            m_Index = index;
            m_Button.interactable = progress.IsOpened;
            m_StartImage.sprite = m_StarsSprites[progress.StarsCount];
        }

        public void LevelSelected()
        {
            LoadingScreen.Screen.Enable(true);
            LevelIndex levelIndex = new LevelIndex();
            levelIndex.SetIndex(m_Index);
            Loader loader = new Loader();
            loader.LoadingMainScene(false);

        }
 }
}