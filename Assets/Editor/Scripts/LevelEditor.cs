using UnityEditor;
using UnityEngine;

namespace GameDevEVO
{
 public class LevelEditor : EditorWindow
 {
        private Transform m_Parent;
        private EditorData m_Data;
        private int m_Index;
        private bool m_IsEnabledEdit;
        private GameLevel m_GameLevel;

        [MenuItem("Window/Level Editor")]

        public static void Init()
        {
            LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
            levelEditor.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(10);
            m_Parent =(Transform)EditorGUILayout.ObjectField(m_Parent, typeof(Transform), true); // true - выбрать из ассетов или сцены
           // EditorGUILayout.Space(10);

            if (m_Data == null)
            {
                if(GUILayout.Button("Load data"))
                {
                    m_Data = (EditorData)AssetDatabase.LoadAssetAtPath("Assets/Editor/Data/EditorData.asset", typeof(EditorData));
                }
            }
            else
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label("Block Prefub", EditorStyles.boldLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.Space(5);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if ( GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    m_Index--;
                    if(m_Index < 0)
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
                    if(m_Index > m_Data.BlockDatas.Count - 1)
                    {
                        m_Index = 0;
                    }
                }

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
                GUILayout.Space(30);
                
                GUI.color = m_IsEnabledEdit ? Color.red : Color.white;
                if(GUILayout.Button("Create bloks"))
                {
                    m_IsEnabledEdit = !m_IsEnabledEdit;
                }
                GUI.color = Color.white;
                GUILayout.Space(30);

                m_GameLevel = EditorGUILayout.ObjectField(m_GameLevel, typeof(GameLevel), false) as GameLevel;
                GUILayout.Space(30);

                GUILayout.BeginHorizontal();
                if(GUILayout.Button("Save Level"))
                {
                    SaveLevel saveLevel = new SaveLevel();
                    m_GameLevel.Blocks = saveLevel.GetBlocks();
                    Debug.Log("Level Saved");
                }
                if (GUILayout.Button("Load Level"))
                {
                    GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("Block");
                    foreach (var item in allBlocks)
                    {
                        DestroyImmediate(item.gameObject);
                    }
                }

                GUILayout.EndHorizontal();
            }

        }
    }
}