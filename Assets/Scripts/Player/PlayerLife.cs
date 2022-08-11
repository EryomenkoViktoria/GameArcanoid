using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public class PlayerLife : MonoBehaviour
 {
        private const int MAXLIFE = 3;
        private int m_Life;
        [SerializeField]
        private GameState m_GameState;
        [SerializeField]
        private UnityEvent OnAllLifeLosted;
        [SerializeField]
        private UnityEvent OnLifeLosted;
        [SerializeField]
        private UnityEventInt UIUpdate;
        public void SetDefault()
        {
            m_Life = MAXLIFE;
            UIUpdate.Invoke(m_Life);
        }

        private void OnEnable()
        {
            BallCount.OnEnded += LostLife;
        }

        private void OnDisable()
        {
            BallCount.OnEnded -= LostLife;
        }

        private void LostLife()
        {
           if(m_GameState.State == State.Gameplay)
            {
                m_Life--;
                if(m_Life < 1)
                {
                    OnAllLifeLosted.Invoke();
                }

                else
                {
                    OnLifeLosted.Invoke();
                }
                UIUpdate.Invoke(m_Life);
            }
        }
    }

    [System.Serializable]
    public class UnityEventInt : UnityEvent<int> { }
}