using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action<float> OnMove;
        private Vector2 m_StartPosition = Vector2.zero;
        private float m_Direction = 0f;

        private void Update()
        {
#if UNITY_EDITOR
            OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
#endif
#if Unity_ANDROID
            GetTouchInput();
#endif
        }

    private void GetTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    //case TouchPhase.Began:
                    //    break;
                    case TouchPhase.Moved:
                        m_Direction = touch.position.x> m_StartPosition.x ? 1f : -1f;
                        break;
                    //case TouchPhase.Stationary:
                    //    break;
                    //case TouchPhase.Ended:
                    //    break;
                    //case TouchPhase.Canceled:
                    //    break;
                    default:
                        m_StartPosition = touch.position;
                        m_Direction = 0f;
                        break;
                }
                OnMove?.Invoke(m_Direction);
            }
        }
    }
}