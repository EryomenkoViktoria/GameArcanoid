using UnityEngine;

namespace GameDevEVO
{
    public class CalculationLevelProgress : MonoBehaviour
    {
        [SerializeField]
        private PlayerLife m_PlayerLife;
        [SerializeField]
        private ScoreController m_ScoreController;
        private Progress m_Progress = new Progress();
        private readonly LevelsData m_LevelData = new LevelsData();
        private readonly LevelIndex m_LevelIndex = new LevelIndex();
        private EndGameData m_EndGameData;

        private void Calculate()
        {
            m_Progress = m_LevelData.GetLevelsProgress().Levels[m_LevelIndex.GetIndex()];

            m_EndGameData = new EndGameData()
            {
                LevelIndex = m_LevelIndex.GetIndex(),
                Life = m_PlayerLife.GetLifeCount(),
                Score = m_ScoreController.GetScore(),
                Record = m_Progress.MaxScore
            };

            if (m_PlayerLife.GetLifeCount() > 0)
            {
                SaveLevelProgress();
            }
        }

        private void SaveLevelProgress()
        {
            if (m_EndGameData.Record < m_EndGameData.Score)
            {
                m_Progress.MaxScore = m_EndGameData.Score;
            }
            if (m_Progress.StarsCount < m_EndGameData.Life)
            {
                m_Progress.StarsCount = m_EndGameData.Life;
            }

            m_LevelData.SaveLevelData(m_LevelIndex.GetIndex(), m_Progress);
        }

        public EndGameData GameEndGameData()
        {
            Calculate();
            return m_EndGameData;
        }
    }

    public struct EndGameData
    {
        public int LevelIndex;
        public int Life;
        public int Score;
        public int Record;
    }
}