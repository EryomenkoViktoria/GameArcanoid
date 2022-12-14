using System.Collections;
using System.Collections.Generic;
# if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace GameDevEVO
{
 public class BlocksGenerator
 {
        public void Generate( GameLevel gameLevel , Transform parent)
        {
            for(int i = 0; i < gameLevel.Blocks.Count; i++)
            {
                GameObject game;
#if UNITY_EDITOR
                game = PrefabUtility.InstantiatePrefab(gameLevel.Blocks[i].Block.Prefub, parent) as GameObject;

                if (game.TryGetComponent(out BaseBlock baseBlock ))
                {
                    baseBlock.BlockData = gameLevel.Blocks[i].Block;
                }


#else
                game = GameObject.Instantiate(gameLevel.Blocks[i].Block.Prefub, parent);
                
#endif
                if (game.TryGetComponent(out Block block))
                {
                    block.SetData(gameLevel.Blocks[i].Block as ColoredBlock);

                }
                game.transform.position = gameLevel.Blocks[i].Position;
            }
        }
 }
}