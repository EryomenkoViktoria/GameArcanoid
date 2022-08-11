using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action<float> OnMove;
        public static event Action OnClicked;
        private Vector2 m_StartPosition = Vector2.zero;
        private float m_Direction = 0f;

        private void Update()
        {
#if UNITY_EDITOR
            OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                OnClicked?.Invoke();
            }
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
                if (touch.tapCount > 1)
                {
                    OnClicked?.Invoke();
                }
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        m_Direction = touch.position.x> m_StartPosition.x ? 1f : -1f;
                        break;
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