using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    public class Clone : Bonus
    {
        public override void Apply()
        {
           BallCreator ballCreator = GetComponentInParent<BallCreator>();
            if(ballCreator != null)
            {
                ballCreator.CreateClone();
            }
            Destroy(gameObject);
        }
    }
}