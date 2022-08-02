using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class LostZone : MonoBehaviour
 {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.TryGetComponent(out BallsMove ball))
            {
                Destroy(ball.gameObject);
            }
        }
    }
}