using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class LoadingScreen : MonoBehaviour
 {
        public static LoadingScreen Screen = null;
        [SerializeField] Canvas m_Canvas;
        private void Awake()
        {
            if(Screen == null)
            {
                Screen = this;
                DontDestroyOnLoad(gameObject);
                m_Canvas.enabled = true;
            }

            else
            {
                Destroy(gameObject);
            }
        }

        public void Enable(bool value)
        {
            if (value)
            {
                m_Canvas.enabled = value;
            }
            else
            {
                Invoke(nameof(Disable), 0.5f);
            }
        }

        private void Disable()
        {
            m_Canvas.enabled = false;
        }
    }
}