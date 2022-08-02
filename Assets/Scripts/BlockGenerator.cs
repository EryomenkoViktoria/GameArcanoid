using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
 public class BlockGenerator : MonoBehaviour
 {
        [SerializeField]
        private List<BlockData> m_Blocks;

        private void Start()
        {
            for (int i=0; i<m_Blocks.Count; i++)
            {
                GameObject game = Instantiate(m_Blocks[i].Prefab, new Vector3(0 + i, 0, 0), Quaternion.identity);
                if(game.TryGetComponent(out Block block))
                {
                    block.SetData(m_Blocks[i]);
                }
            }
        }
    }
}