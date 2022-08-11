using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class WindowController : MonoBehaviour
 {
        [SerializeField] private GameState m_GameState;
        [SerializeField] private GameObject m_EndGameWindow;
        [SerializeField] private GameObject m_PauseWindow;

        public void Play()
        {
            m_GameState.SetState(State.Gameplay);
            m_PauseWindow.SetActive(false);
        }
        public void Replay()
        {
            DisableTwoWindow();
        }


        public void NextLevel()
        {
            m_EndGameWindow.SetActive(false);
        }
        public void ToHome()
        {
            DisableTwoWindow();
            LoadingScreen.Screen.Enable(true);
            Loader loader = new Loader();
            m_GameState.SetState(State.Other);
            loader.LoadingMainScene(true);
        }


        private void DisableTwoWindow()
        {
            m_EndGameWindow.SetActive(false);
            m_PauseWindow.SetActive(false);
        }

        private void OnEnable()
        {
            Block.OnEnded += EndGame;
        }

        private void OnDisable()
        {
            Block.OnEnded -= EndGame;
        }

        private void EndGame()
        {
            if(m_GameState.State == State.Gameplay)
            {
                m_EndGameWindow.SetActive(true);
            }
        }
    }
}