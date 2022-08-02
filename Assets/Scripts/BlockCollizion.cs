using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class BlockCollizion : MonoBehaviour
 {
        [SerializeField] private BallsMove m_Ball;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            m_Ball.MoveCollision(collision);
            if(collision.gameObject.TryGetComponent(out Block block))
            {
                block.ApplyDamage();
            }
        }
    }
}