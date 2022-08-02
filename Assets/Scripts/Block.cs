using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class Block : MonoBehaviour
 {
        private static int m_Count = 0;
        private List<Sprite> m_Sprites;
        private int m_Score;
        private SpriteRenderer m_SpriteRenderer;
        private int m_Life;
        public void SetData(BlockData blockData)
        {
            m_Sprites = new List<Sprite>(blockData.Sprites);
            m_Score = blockData.Score;
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_SpriteRenderer.color = blockData.BaseColor;
            m_Life= m_Sprites.Count;
            m_SpriteRenderer.sprite = m_Sprites[m_Life-1];
        }

        public void ApplyDamage()
        {
            m_Life--;
            if (m_Life < 1)
            {
                Destroy(gameObject);
            }

            else
            {
                m_SpriteRenderer.sprite =m_Sprites[m_Life-1];  
            }
        }
        private void OnEnable()
        {
            m_Count++;
        }
        private void OnDisable()
        {
            m_Count--;
            if (m_Count < 1)
            {
                Debug.Log("block");
            }
        }
    }
}