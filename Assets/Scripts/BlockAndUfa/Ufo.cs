using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    public class Ufo : MonoBehaviour, IDamageable
    {
        private const int Score = 500;
        private const float Speed = 2f;
        private float m_MaxDistance;

        [SerializeField] private SpriteRenderer m_SpriteRenderer;
        [SerializeField] private BoxCollider2D m_BoxCollider2D;
        [SerializeField] private ParticleSystem m_ParticleSystem;

        public static event Action<int> OnDestroyed;
        private void Update()
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            if(transform.position.x > m_MaxDistance)
            {
                gameObject.SetActive(false);
            }
        }

        private void ShowObject(bool value)
        {
            m_BoxCollider2D.enabled = value;
            m_SpriteRenderer.enabled = value;
        }

        private void OnEnable()
        {
            ShowObject(true);
            m_MaxDistance = Math.Abs(transform.position.x);
        }
        private void OnDestroy()
        {
            OnDestroyed?.Invoke(Score);
        }
        public void ApplyDamage()
        {
            ShowObject(false);
            m_ParticleSystem.Play();
        }
    }
}