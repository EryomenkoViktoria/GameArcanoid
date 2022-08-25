using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public class ScoreController : MonoBehaviour
 {
        [SerializeField] private GameState m_GameState;
        [SerializeField] private UnityEventInt UiUpdate;
        [SerializeField] private UnityEvent ThousandCollected;
        private const int ScoreToNextBonus = 1000;

        private int m_Score;
        public int GetScore()
        {
            return m_Score;
        }
        public void SetDefault()
        {
            m_Score = 0;
            UiUpdate.Invoke(m_Score);
        }

        private void OnEnable()
        {
            Block.OnDestroyed += ScoreCollect;
            Bonus.OnAdded += ScoreCollect;
            Ufo.OnDestroyed += ScoreCollect;
        }

        private void OnDisable()
        {
            Block.OnDestroyed -= ScoreCollect;
            Bonus.OnAdded -= ScoreCollect;
            Ufo.OnDestroyed -= ScoreCollect;
        }
        private void ScoreCollect(int value)
        {
            if(m_GameState.State == State.Gameplay)
            {
                m_Score += value;
                UiUpdate.Invoke(m_Score);
                if(m_Score % ScoreToNextBonus == 0)
                {
                    ThousandCollected.Invoke();
                }
            }
        }
    }
}