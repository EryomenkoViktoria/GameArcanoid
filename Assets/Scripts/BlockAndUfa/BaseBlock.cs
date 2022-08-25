using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public abstract class BaseBlock : MonoBehaviour
 {
#if UNITY_EDITOR
        [HideInInspector]
        public BlockData BlockData;
#endif
    }
}