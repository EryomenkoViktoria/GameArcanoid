using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class BallSpeedController : MonoBehaviour
 {
        [SerializeField] private Rigidbody2D m_rigidbody2D;
        private const float MinSpeed = 5.8f;
        private const float MAxSpeed = 6.2f;
        private const int WaitFrame = 30;

        private void Update()
        {
          if(m_rigidbody2D.velocity.magnitude != 0)
            {
                if(Time.frameCount% WaitFrame == 0)
                {
                    if(m_rigidbody2D.velocity.magnitude < MinSpeed || m_rigidbody2D.velocity.magnitude > MAxSpeed)
                    {
                        float speedCorrect = MAxSpeed /m_rigidbody2D.velocity.magnitude;
                        m_rigidbody2D.velocity *= speedCorrect;
                    }
                }
            }   
        }
    }
}