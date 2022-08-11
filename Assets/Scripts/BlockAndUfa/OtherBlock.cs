using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class OtherBlock : BaseBlock
    {
        [SerializeField]
        private ParticleSystem m_Particle = null;

        private void Start()
        {
            m_Particle = Instantiate(m_Particle, gameObject.transform.position, Quaternion.identity);
            m_Particle.transform.SetParent(gameObject.transform);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            m_Particle.Simulate(0f, true, true);
            m_Particle.transform.position = collision.contacts[0].point;
            m_Particle.Play();
        }
    }
}