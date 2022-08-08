using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameDevEVO
{
    public class LevelEditor : EditorWindow
 {
        private Transform m_Parent;
        private EditorData m_Data;
        private int m_Index;
        private bool m_IsEnabledEditor;
        private GameLevel m_GameLevel;
        private SceneEditor m_SceneEditor;

        [MenuItem("Window/Level Editor")]

        public static void Init()
        {
            LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
            levelEditor.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            m_Parent =(Transform)EditorGUILayout.ObjectField(m_Parent, typeof(Transform), true);
            EditorGUILayout.Space(30);

            if (m_Data == null)
            {
                if(GUILayout.Button("Load data"))
                {
                    m_Data = (EditorData)AssetDatabase.LoadAssetAtPath("Assets/Editor/Data/EditorData.asset", typeof(EditorData));
                    m_SceneEditor = CreateInstance<SceneEditor>();
                    m_SceneEditor.SetLeveleEditor(this, m_Parent);
                }
            }

            else
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Block Prefub",EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    m_Index--;
                    if (m_Index < 0)
                    {
                        m_Index = m_Data.BlockDatas.Count - 1;
                    }
                }

                if (m_Data.BlockDatas[m_Index].BlockData is ColoredBlock)
                {
                    ColoredBlock coloredBlock = m_Data.BlockDatas[m_Index].BlockData as ColoredBlock;
                    GUI.color = coloredBlock.BaseColor;
                }
                else
                {
                    GUI.color = Color.white;

                }

                GUILayout.Label(m_Data.BlockDatas[m_Index].Texture2D);
                GUI.color = Color.white;

                if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    m_Index++;
                    if(m_Index> m_Data.BlockDatas.Count - 1)
                    {
                        m_Index = 0;
                    }
                }

                

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.Space(30);
                GUI.color = m_IsEnabledEditor ? Color.red : Color.white;
                if (GUILayout.Button("Create bloks"))
                {
                    m_IsEnabledEditor = !m_IsEnabledEditor;

                    if (m_SceneEditor)
                    {
                        SceneView.duringSceneGui += m_SceneEditor.OnSceneGUI;
                    }
                    else
                    {
                        SceneView.duringSceneGui -= m_SceneEditor.OnSceneGUI;
                    }
                }
                GUI.color = Color.white;

                GUILayout.Space(30);

                m_GameLevel = EditorGUILayout.ObjectField(m_GameLevel, typeof(GameLevel), false) as GameLevel;
                GUILayout.Space(10);
                GUILayout.BeginHorizontal();

                if (GUILayout.Button("Save Level"))
                {
                    SaveLevel saveLevel = new SaveLevel();
                    saveLevel.Save(m_GameLevel);
                    EditorUtility.SetDirty(m_GameLevel);
                    Debug.Log("Load Level");
                }
                if (GUILayout.Button("Load Level"))
                {
                    GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("Block");
                    foreach(var item in allBlocks)
                    {
                        DestroyImmediate(item.gameObject);
                    }
                    BlocksGenerator generator = new BlocksGenerator();
                    generator.Generate(m_GameLevel,m_Parent);
                }
                GUILayout.EndHorizontal();
            }
        }

        public BlockData GetBlock()
        {
            return m_Data.BlockDatas[m_Index].BlockData;
        }
    }
}