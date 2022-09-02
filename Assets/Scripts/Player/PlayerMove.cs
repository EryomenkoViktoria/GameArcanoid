using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class PlayerMove : MonoBehaviour
 {
        private Rigidbody2D m_Rigidbody2;
        private SpriteRenderer m_SpriteRenderer;
        private float m_MoveX = 0f;
        private float m_Speed = 10f;
        private const float BorderPosition = 5f;

        private void Awake()
        {
            m_Rigidbody2 = GetComponent<Rigidbody2D>();
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            float positionX = m_Rigidbody2.position.x + m_MoveX * m_Speed * Time.fixedDeltaTime;
            positionX = Mathf.Clamp(positionX, -BorderPosition+(m_SpriteRenderer.size.x/2), BorderPosition - (m_SpriteRenderer.size.x / 2));
            m_Rigidbody2.MovePosition(new Vector2(positionX, m_Rigidbody2.position.y));
        }

        private void OnEnable()
        {
            PlayerInput.OnMove += Move;   
        }

        private void OnDisable()
        {
            PlayerInput.OnMove -= Move;
        }
        private void Move(float moveX)
        {
            m_MoveX = moveX;
        }

        public void ResetPosition()
        {
            m_Rigidbody2.position = new Vector2(0f, m_Rigidbody2.position.y);
        }
    }
}