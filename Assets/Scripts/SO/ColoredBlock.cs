using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    [CreateAssetMenu(fileName = "CloloredBlock", menuName = "GameData/Create/CloloredBlock")]
    public class ColoredBlock : BlockData

    {
        public List<Sprite> Sprites;
        public Color BaseColor;
        public int Score;
    }
}