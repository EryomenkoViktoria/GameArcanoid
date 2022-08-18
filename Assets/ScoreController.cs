using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class ScoreController : MonoBehaviour
 {
        [SerializeField]
        private GameState m_GameState;
        private int m_Score;
        [SerializeField] private UnityEventInt UiUpdate;

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
        }

        private void OnDisable()
        {
            Block.OnDestroyed -= ScoreCollect;
            Bonus.OnAdded -= ScoreCollect;

        }
        private void ScoreCollect(int value)
        {
            if(m_GameState.State == State.Gameplay)
            {
                m_Score += value;
                UiUpdate.Invoke(m_Score);
            }
        }
    }
}