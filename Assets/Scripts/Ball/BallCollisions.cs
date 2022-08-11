using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class BallCollisions : MonoBehaviour
    {
        [SerializeField] private BallMove m_Ball;
        private float m_lastPositionX;
        private void OnCollisionEnter2D(Collision2D collision)
        {

            float ballPositionX = transform.position.x;

            if (collision.gameObject.TryGetComponent(out PlayerMove playerMove))
            {
                if (collision.gameObject.TryGetComponent(out PlayerMove player))
                {
                    float collisionPointX = collision.contacts[0].point.x;
                    float playerCenterPosition = playerMove.gameObject.transform.position.x;
                    float difference = playerCenterPosition - collisionPointX;
                    float direction = collisionPointX < playerCenterPosition ? -1 : 1;
                    m_Ball.AddForse(direction * Mathf.Abs(difference));
                }
            }
            m_lastPositionX = ballPositionX;
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage();
            }
        }
    }
}
