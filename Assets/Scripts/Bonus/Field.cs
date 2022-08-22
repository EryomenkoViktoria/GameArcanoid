using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
    public class Field : Bonus, IRemovable
    {
        private FieldInScene m_FieldScene;
        private void OnEnable()
        {
            if(m_FieldScene == null)
            {
              m_FieldScene =FindObjectOfType<FieldInScene>();  
            }
        }
        public override void Apply()
        {
            m_FieldScene.SetActive(true);
            StartTimer();
        }

        public  void Remove()
        {
            m_FieldScene.SetActive(false);
        }
    }
}