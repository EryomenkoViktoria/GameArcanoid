using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    [RequireComponent(typeof(BonusMove), typeof(BoxCollider2D), typeof(SpriteRenderer))]
    public class BonusAttach : MonoBehaviour
 {
        [SerializeField] private BonusMove m_BonusMove;
        [SerializeField] private BoxCollider2D m_BoxCollider2D;
        [SerializeField] private SpriteRenderer m_SpriteRenderer;
        [Space]
        [SerializeField] private Bonus m_Bonus;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out PlayerMove playerMove))
            {
                SetEnableMoveAndVisual(false);
                Bonus[] bonuses = playerMove.gameObject.GetComponentsInChildren<Bonus>();
                if(bonuses.Length > 0)
                {
                    foreach (var item in bonuses)
                    {
                        if(m_Bonus.GetType()== item.GetType())
                        {
                            item.StopAndRemove();
                            break;
                        }
                    }
                    Attach(playerMove.transform);
                }
                else
                {
                    Attach(playerMove.transform);
                }

            }
        }

        private void Attach(Transform parent)
        {
            transform.SetParent(parent);
            transform.position = parent.position;
            m_Bonus.Apply();
        }

        private void OnEnable()
        {
            SetEnableMoveAndVisual(false);
        }
        public void SetEnableMoveAndVisual(bool value)
        {
            m_BoxCollider2D.enabled = value;
            m_SpriteRenderer.enabled = value;
        }
    }
}