using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDevEVO 
{
 public class AudioButton : MonoBehaviour
 {
        [SerializeField] private Button m_Button;
        [Space]
        [SerializeField]
        private Color m_EnableColor;
        [SerializeField]
        private Color m_DisableColor;
        [Space]
        [SerializeField]
        private Image m_Icon;
        [Space]
        [SerializeField]
        private Sprite m_EnableSprite; 
        [SerializeField]
        private Sprite m_DisableSprite;
        private bool m_Enable;

        public void SetState(bool value)
        {
            m_Enable = value;
            Changed();
        }
        public void Change()
        {
            m_Enable = !m_Enable;
            Changed();
        }
        private void Changed()
        {
            m_Button.image.color = m_Enable ? m_EnableColor : m_DisableColor;
            m_Icon.sprite = m_Enable ? m_EnableSprite : m_DisableSprite;
        }
    }
}