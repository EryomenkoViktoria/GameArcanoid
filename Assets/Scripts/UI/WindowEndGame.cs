using UnityEngine;
using UnityEngine.UI;

namespace GameDevEVO
{
    public class WindowEndGame : MonoBehaviour
    {
        [SerializeField]
        private CalculationLevelProgress m_CalculationLevel;
        [SerializeField]
        private Image m_RibbonImage;
        [SerializeField]
        private Color m_WinColor;
        [SerializeField]
        private Color m_DefectColor;
        [SerializeField]
        private Image m_StartImage;
        [SerializeField]
        private Sprite[] m_StartSprites;
        [SerializeField]
        private Text m_ScoreText;
        [SerializeField]
        private Text m_RecordText;
        [SerializeField]
        private Text m_LevelIndex;
        [SerializeField]
        private Button m_ButtonNextLevel;

        private void OnEnable()
        {
            EndGameData endGameData = m_CalculationLevel.GameEndGameData();
            if (endGameData.Life > 0)
            {
                m_ButtonNextLevel.interactable = true;
            }
            else
            {
                m_ButtonNextLevel.interactable = false;
            }

            m_LevelIndex.text = (endGameData.LevelIndex + 1).ToString();
            m_RibbonImage.color = (endGameData.Life < 1) ? m_DefectColor : m_WinColor;
            m_StartImage.sprite = m_StartSprites[endGameData.Life];
            m_ScoreText.text = endGameData.Score.ToString();
            m_RecordText.text = endGameData.Record.ToString();

        }
    }
}