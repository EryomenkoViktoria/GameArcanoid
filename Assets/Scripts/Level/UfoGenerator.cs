using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class UfoGenerator : MonoBehaviour
 {

        private const float MinPositionY = -4.75f;
        private const float MaxPositionY = 8.75f;
        private ObjectPool m_UfosPool;

        private void OnEnable()
        {
            if( m_UfosPool == null)
            {
                ObjectPool[] objectPools = FindObjectsOfType<ObjectPool>();
                for(int i = 0; i < objectPools.Length; i++)
                {
                    if (objectPools[i].gameObject.CompareTag("UfosPool"))
                    {
                        m_UfosPool = objectPools[i];
                        break;
                    }
                }
            }
        }

        public void Generate()
        {
            GameObject ufo = m_UfosPool.GetObject();
            if(ufo != null)
            {
                float  tempY = Random.Range(MinPositionY, MaxPositionY);
                ufo.transform.position = new Vector2(transform.position.x, tempY);
                ufo.SetActive(true);
            }
        }
    }
}