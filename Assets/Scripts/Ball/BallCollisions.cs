using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class BallCollisions : MonoBehaviour
    {
        [SerializeField]
        private BallMove m_Ball;
        [SerializeField]
        private BallSound m_BallSound;
        private float m_lastPositionX;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            m_BallSound.PlaySoundCollision();
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

            if (collision.gameObject.TryGetComponent(out BlockComposite blockComposite))
            {
                blockComposite.ApplyDamage(collision.contacts[0].point);
            }
        }
    }
}
