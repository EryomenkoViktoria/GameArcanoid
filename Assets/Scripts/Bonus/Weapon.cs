using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    public class Weapon : Bonus
    {
        private ObjectPool m_BulletsPool;
        private const float OffserY = 0.5f;
        private const float OffserX = 0.5f;

        public override void Apply()
        {
            StartTimer();
            StartCoroutine(StartShoot());
        }
        private void OnEnable()
        {
            if(m_BulletsPool == null)
            {
                ObjectPool[] objectPools = FindObjectsOfType<ObjectPool>();
                for(int i =0; i< objectPools.Length; i++)
                {
                    if (objectPools[i].gameObject.CompareTag("BulletsPool"))
                    {
                        m_BulletsPool = objectPools[i];
                        break;
                    }
                }
            }
        }

        private IEnumerator StartShoot()
        {
            while (true)
            {
                ActivateBullet(OffserX);
                ActivateBullet(-OffserX);
                yield return new WaitForSeconds(0.5f);

            }

        }

        private void ActivateBullet(float offsetX)
        {
            GameObject bullet = m_BulletsPool.GetObject();
            if(bullet != null)
            {
                bullet.transform.position = new Vector2(transform.position.x + offsetX, transform.position.y + OffserY) ;
                bullet.SetActive(true);
            }
        }
    }
}