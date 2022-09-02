using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO
{
    public class BonusGenerate : MonoBehaviour
    {
        [SerializeField]
        private GameState m_GameState;
        private readonly List<BonusAttach> m_LevelBonuses = new List<BonusAttach>();
        private readonly LevelIndex m_LevelIndex = new LevelIndex();

        public void Generate()
        {
            m_LevelIndex.Clear();
            GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{m_LevelIndex.GetIndex()}");
            if (gameLevel != null)
            {
                foreach (var item in gameLevel.Bonuses)
                {
                    BonusAttach bonusAttach = Instantiate(item, transform);
                    bonusAttach.transform.position = transform.position;
                    m_LevelBonuses.Add(bonusAttach);
                }
            }
        }


        private void Activate(Vector2 position)
        {
            if (m_LevelBonuses.Count > 0)
            {
                int index = Random.Range(0, m_LevelBonuses.Count);
                Debug.Log("Activate " + m_LevelBonuses.Count + " / " + index); 
                m_LevelBonuses[index].transform.SetParent(null);
                m_LevelBonuses[index].transform.position = position;
                m_LevelBonuses[index].SetEnableMoveAndVisual(true);
                m_LevelBonuses.RemoveAt(index);
            }
        }

        private void OnEnable()
        {
            Block.OnDestroyedPosition += BonusChance;
        }

        private void OnDisable()
        {
            Block.OnDestroyedPosition -= BonusChance;
        }

        private void BonusChance(Vector2 position)
        {
            if (m_GameState.State == State.Gameplay)
            {
                var chance = Random.Range(0, 100);
                if (chance > 70)
                {
                    Activate(position);
                }
            }
        }
    }
}