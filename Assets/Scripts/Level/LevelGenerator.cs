using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameDevEVO 
{
 public class LevelGenerator : MonoBehaviour
 {
        private readonly LevelIndex m_LevelIndex = new LevelIndex();
        private readonly BlocksGenerator m_BlocksGenerator = new BlocksGenerator();
        [SerializeField]
        private Transform m_ParentBlocks;
        [SerializeField]
        private ClearLevel m_ClearLevel;
        [SerializeField]
        private GameState m_GameState;
        [SerializeField]
        private UnityEvent OnGenerated;
        [Space]
        [SerializeField]
        private SpriteRenderer m_Background;

        private void Start()
        {
            m_GameState.SetState(State.StopGame);
            Init();
        }

        private void Init()
        {
            m_ClearLevel.Clear();
            GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{m_LevelIndex.GetIndex()}");
            if(gameLevel != null)
            {
                m_BlocksGenerator.Generate(gameLevel, m_ParentBlocks);
                m_Background.sprite = gameLevel.Background;
            }
            LoadingScreen.Screen.Enable(false);
            m_GameState.SetState(State.Gameplay);
            OnGenerated.Invoke();
            
        }

        public void Generate()
        {
            LoadingScreen.Screen.Enable(true);
            Init();
        }

        public  void GenerateNext()
        {
            LevelsData levelsData = new LevelsData();
            int tempIndex = m_LevelIndex.GetIndex();
            if ( tempIndex < levelsData.GetLevelsProgress().Levels.Count - 1)
            {
                m_LevelIndex.SetIndex(tempIndex + 1);
                Generate();
            }

            else
            {
                Loader loader = new Loader();
                m_GameState.SetState(State.Other);
                loader.LoadingMainScene(true);
            }
        }
    }
}