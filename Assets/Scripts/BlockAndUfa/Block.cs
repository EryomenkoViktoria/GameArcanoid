using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace GameDevEVO
{
 public class Block : BaseBlock, IDamageable
    {
        private static int m_Count = 0;
        [SerializeField]
        private List<Sprite> m_Sprites;
        [SerializeField]
        private int m_Score;
        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;
        [SerializeField]
        private int m_Life;

        public static event Action OnEnded;
        public static event Action<int> OnDestroyed;

        public void SetData(ColoredBlock blockData)
        {
            m_Sprites = new List<Sprite>(blockData.Sprites);
            m_Score = blockData.Score;
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Life= m_Sprites.Count;
            m_SpriteRenderer.sprite = m_Sprites[m_Life-1];
            MainModule main = GetComponent<ParticleSystem>().main;
            main.startColor = m_SpriteRenderer.color = blockData.BaseColor;
        }

        public void ApplyDamage()
        {
            m_Life--;
            if (m_Life < 1)
            {
                m_SpriteRenderer.enabled = false;
                GetComponent<BoxCollider2D>().enabled=false;
                GetComponent<ParticleSystem>().Play();
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
            OnDestroyed?.Invoke(m_Score);

            if (m_Count < 1)
            {
                OnEnded?.Invoke();
            }
        }
    }
}