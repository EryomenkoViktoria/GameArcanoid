using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class FieldInScene : MonoBehaviour
 {
        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;
        [SerializeField]
        private BoxCollider2D m_BoxCollider2;

        public void SetActive(bool value)
        {
            m_BoxCollider2.enabled = value;
            m_SpriteRenderer.enabled = value;
        }
 }
}