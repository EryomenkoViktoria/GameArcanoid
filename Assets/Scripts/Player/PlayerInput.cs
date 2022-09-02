using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameDevEVO
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action<float> OnMove;
        public static event Action OnClicked;
        private Vector2 m_StartPosition = Vector2.zero;
        private float m_Direction = 0f;
        [SerializeField]
        private Button m_StartGame;

        [SerializeField]
        private GameObject m_StartGamePanel;

        private void OnEnable()
        {
            m_StartGame.onClick.AddListener(StartGame);
            PlayerLife.OnRestartGame += StartGamePanel;
            WindowController.StopGame += ClousedGamePanel;
        }

        private void OnDisable()
        {
            m_StartGame.onClick.RemoveListener(StartGame);
            PlayerLife.OnRestartGame -= StartGamePanel;
            WindowController.StopGame -= ClousedGamePanel;
        }

        private void StartGame()
        {
            OnClicked?.Invoke();
        }

        private void StartGamePanel()
        {
            m_StartGamePanel.SetActive(true);
        }

        private void ClousedGamePanel()
        {
            m_StartGamePanel.SetActive(false);
        }

        private void Update()
        {
#if UNITY_EDITOR
            OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                StartGame();
            }
#endif
            //#if Unity_ANDROID
            GetTouchInput();
            //#endif
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
                        m_Direction = touch.position.x > m_StartPosition.x ? 1f : -1f;
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