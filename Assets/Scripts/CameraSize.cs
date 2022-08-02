using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO.Tools
{
    public class CameraSize : MonoBehaviour
    {
        private const float SizeX = 1920.0f;
        private const float SizeY = 1080.0f;
        private float m_TargetSizeX = 0f;
        private float m_TargetSizeY = 0f;
        private const float HalfSize = 200.0f;
        [SerializeField] private bool m_IsHorisontal = true;


        private void Awake()
        {
            m_TargetSizeX = m_IsHorisontal ? SizeX : SizeY;
            m_TargetSizeY = m_IsHorisontal ? SizeY : SizeX;
            CameraResize();
        }

        private void CameraResize()
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = m_TargetSizeX / m_TargetSizeY;
            if (screenRatio >= targetRatio)
            {
                Resize();
            }
            else
            {
                float differetSize = targetRatio / screenRatio;
                Resize(differetSize);
            }
        }

        private void Resize(float diferentSize = 1.0f)
        {
            Camera.main.orthographicSize = m_TargetSizeY / HalfSize * diferentSize;
        }
    }

}
