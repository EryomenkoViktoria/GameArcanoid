using System;
using UnityEngine;

namespace GameDevEVO
{
    public class BallCount : MonoBehaviour
    {
        private static int m_Count = 0;
        public static event Action OnEnded;

        private void OnEnable()
        {
            m_Count++;
        }

        private void OnDisable()
        {
            m_Count--;
            if (m_Count < 1)
            {
                OnEnded?.Invoke();
            }
        }
    }
}