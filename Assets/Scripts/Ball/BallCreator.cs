using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class BallCreator : MonoBehaviour
 {
        [SerializeField]
        private GameObject m_BallPrefub;
        private const float OffsetY = 0.5f;
        private readonly List<GameObject> m_SaveBalls = new List<GameObject>();
        
        public void Create()
        {
            m_SaveBalls.Clear();
            m_SaveBalls.Add(Instantiate(m_BallPrefub,new Vector3(transform.position.x, transform.position.y+ OffsetY),Quaternion.identity,transform));
        }

        public void CreateClone()
        {
            foreach (var item in m_SaveBalls)
            {
                if (item != null)
                {
                    GameObject cloneOne = Instantiate(m_BallPrefub, new Vector3(item.transform.position.x, item.transform.position.y), 
                        Quaternion.identity, null);
                    GameObject cloneTwo = Instantiate(m_BallPrefub, new Vector3(item.transform.position.x, item.transform.position.y),
                        Quaternion.identity, null);
                    cloneOne.GetComponent<BallMove>().StartClone(1f);
                    cloneTwo.GetComponent<BallMove>().StartClone(-1f);
                    m_SaveBalls.Add(cloneOne);
                    m_SaveBalls.Add(cloneTwo);
                    break;
                }
            }
        }
    }
}