using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public abstract class Bonus : MonoBehaviour
 {
        [SerializeField] protected int m_Score;
        [SerializeField] protected float m_Time = 4f;
        private float m_CurrentTime;
        private const float TimeStep = 0.5f;
        public static event Action<int> OnAdded;

        public abstract void Apply();

        public void StopAndRemove()
        {
           if (TryGetComponent(out IRemovable removable))
            {
                removable.Remove();
            }
            Destroy(gameObject);
        }
        protected void StartTimer()
        {
            OnAdded?.Invoke(m_Score);
            m_CurrentTime = m_Time;
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            while (m_CurrentTime> 0)
            {
                m_CurrentTime -= TimeStep;
                yield return new WaitForSeconds(TimeStep);
            }

            StopAndRemove();
        }
 }

}