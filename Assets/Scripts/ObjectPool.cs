using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class ObjectPool : MonoBehaviour
 {
        [SerializeField]
        private GameObject m_Object;
        [SerializeField]
        private int AmountToPool;
        private readonly List<GameObject> m_Objects = new List<GameObject>();

        private void OnEnable()
        {
            CreatePool();
        }
        private void CreatePool()
        {
            m_Objects.Clear();
            GameObject temp;
            for (int i = 0; i < AmountToPool; i++)
            {
                temp = Instantiate(m_Object, transform);
                temp.SetActive(false);
                m_Objects.Add(temp);
            }
        }

        public  GameObject GetObject()
        {
            for (int i = 0; i < m_Objects.Count; i++)
            {
                if (!m_Objects[i].activeInHierarchy)
                {
                    return m_Objects[i];
                }
            }
            return null;
        }
    }
}