using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class BallsMove : MonoBehaviour
 {
        private Rigidbody2D m_Rigidbody2D;
        private bool m_IsActiv;
        private const float Force = 300;
        private float m_lastPositionX;

        private void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Backspace) && !m_IsActiv)
            {
                BallActive();

            }
#endif
#if UNITY_ANDROID
            if (Input.touchCount > 0 && !m_IsActiv)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.tapCount > 1)
                {
                    BallActive();
                }
            }
#endif
        }

        private void BallActive()
        {
            m_lastPositionX = transform.position.x;
           m_IsActiv = true;
            transform.SetParent(null);
            m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            m_Rigidbody2D.AddForce(Vector2.up* Force);
        }
        public void MoveCollision(Collision2D collision)
        {
            float ballPositionX = transform.position.x;
            if (collision.gameObject.TryGetComponent(out PlayerMove player))
            {
                if (ballPositionX< m_lastPositionX + 0.1&& ballPositionX > m_lastPositionX-0.1)
                {
                    float collisionPointX = collision.contacts[0].point.x;
                    m_Rigidbody2D.velocity = Vector2.zero;
                    float playerCenterPosition = player.gameObject.GetComponent<Transform>().position.x;
                    float difference = playerCenterPosition - collisionPointX;
                    float direction = collisionPointX< playerCenterPosition ? -1 :1;
                    m_Rigidbody2D.AddForce(new Vector2(direction * Math.Abs(difference * (Force / 2)), Force));
                }
            }

            m_lastPositionX = ballPositionX;
        }
    }
}