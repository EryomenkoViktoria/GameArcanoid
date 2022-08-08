using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameDevEVO 
{
 public class SceneEditor : EditorWindow
 {
        private readonly EditorGrid m_Grid = new EditorGrid();
        private LevelEditor m_LevelEditor;
        private Transform m_parent;

        public void SetLeveleEditor(LevelEditor levelEditor, Transform parent)
        {
            m_parent = parent;
            m_LevelEditor = levelEditor;
        }

        public void OnSceneGUI(SceneView sceneView)
        {
            Event current = Event.current;
            if (current.type == EventType.MouseDown)
            {
                Vector3 point = sceneView.camera.ScreenToWorldPoint(new Vector3(current.mousePosition.x, sceneView.camera.pixelHeight - current.mousePosition.y,
                    sceneView.camera.nearClipPlane));
                Vector3 position = m_Grid.CheckPositionon(point);
                if(position != Vector3.zero)
                {
                    if (IsEmpty(position))
                    {
                        GameObject game = PrefabUtility.InstantiatePrefab(m_LevelEditor.GetBlock().Prefub, m_parent) as GameObject;
                        game.transform.position = position;
                        if (game.TryGetComponent(out BaseBlock baseBlock))
                        {
                            baseBlock.BlockData = m_LevelEditor.GetBlock();
                        }

                        if (game.TryGetComponent(out Block block))
                        {
                           
                            block.SetData(m_LevelEditor.GetBlock() as ColoredBlock);
                        }
                    }
                    
                }
            }
            if(current.type == EventType.Layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
            }
        }

        private bool IsEmpty(Vector3 position)
        {
            Collider2D collider = Physics2D.OverlapCircle(position, 0.01f);
            return collider == null;
        }
 }
}