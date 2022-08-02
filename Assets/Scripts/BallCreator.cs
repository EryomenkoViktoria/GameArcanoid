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
        private void Start()
        {
            Create();
        }

        private void Create()
        {
            Instantiate(m_BallPrefub,new Vector3(transform.position.x, transform.position.y+ OffsetY),Quaternion.identity,transform);
        }
    }
}