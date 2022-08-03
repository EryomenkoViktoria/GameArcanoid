using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class TestAttintionField : MonoBehaviour
    {
        [AttentionField]
        public Camera MyCamera;

        [SerializeField, AttentionField]
        private Transform m_Transform;
 }
}