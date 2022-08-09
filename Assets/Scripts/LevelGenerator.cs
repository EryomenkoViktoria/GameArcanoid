using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            m_ClearLevel.Clear();
            GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{m_LevelIndex.GetIndex()}");
            if(gameLevel != null)
            {
                m_BlocksGenerator.Generate(gameLevel, m_ParentBlocks);
            }
            LoadingScreen.Screen.Enable(false);
        }

        public void Generate()
        {
            LoadingScreen.Screen.Enable(true);
            Init();
        }
    }
}