using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    [CreateAssetMenu(fileName = "Level", menuName= "GameData/Create/GameLeve;")]
 public class GameLevel : ScriptableObject
 {
        public List<BlockObject> Blocks = new List<BlockObject>();
 }

    [System.Serializable]

    public class BlockObject
    {
        public Vector3 Position;
        public BlockData Block;
    }
}