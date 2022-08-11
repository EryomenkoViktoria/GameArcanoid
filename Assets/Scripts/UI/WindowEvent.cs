using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class WindowEvent : MonoBehaviour
 {
        [SerializeField] private GameState m_GameState;
        [SerializeField] private GameObject m_PauseButton;

        private void OnEnable()
        {
            m_PauseButton.SetActive(false);
            m_GameState.SetState(State.StopGame);
        }

        private void OnDisable()
        {
            m_PauseButton.SetActive(true);
        }
    }
}