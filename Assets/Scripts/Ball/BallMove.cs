using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class BallMove : MonoBehaviour
 {
       [SerializeField] private Rigidbody2D m_Rigidbody2D;
        private bool m_IsActiv;
        private const float Force = 300;
        [SerializeField] private BallSound m_BallSound;
      


        private void OnEnable()
        {
            m_Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            PlayerInput.OnClicked += BallActivete;
        }

        private void OnDisable()
        {
            PlayerInput.OnClicked -= BallActivete;
        }
        private void BallActivete()
        {
            if (!m_IsActiv)
            {

                m_IsActiv = true;
                transform.SetParent(null);
                m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                AddForse();
                m_BallSound.PlaySoundAwake();
            }
        }

        public void AddForse(float direction = 0f)
        {
            m_Rigidbody2D.velocity = Vector2.zero;
            m_Rigidbody2D.AddForce(new Vector2(direction * (Force/2), Force));
        }

        public void StartClone(float direction)
        {
            m_IsActiv = true;
            m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            AddForse(direction);
            m_BallSound.PlaySoundAwake();
        }
    }
}