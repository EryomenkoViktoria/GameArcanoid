using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class LostZone : MonoBehaviour
 {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision.gameObject);
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}