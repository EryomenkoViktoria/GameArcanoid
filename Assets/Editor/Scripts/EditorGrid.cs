using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevEVO 
{
 public class EditorGrid
 {
        private const float m_LeftPosition = -4.5f;
        private const float m_UpPosition = -8.75F;
        private const int m_ColumnCount = 10;
        private const int m_LineCount = 20;
        private const float m_OffsetDown = 0.5f;
        private const float m_OffsetRight = 1f;

        public Vector3 CheckPositionon(Vector3 position)
        {
            float tempX = 0;
            float tempY = 0;
            float x = m_LeftPosition - m_OffsetRight / 2;
            float y = m_UpPosition + m_OffsetDown / 2;

            if (position.x > x && position.x < (x + m_OffsetRight * m_ColumnCount) &&
                position.y< y&& position.y>(y- m_OffsetDown * m_LineCount))
            {
                for (int i= 0; i < m_ColumnCount; i++)
                {
                    if (position.x >x && position.x< (x+m_OffsetRight))
                    {
                        tempX = +m_OffsetRight / 2;
                        break;
                    }
                    else
                    {
                        x += m_OffsetRight;
                    }
                }

                for(int i=0; i< m_LineCount; i++)
                {
                    if(position.y < y&& position.y > (y - m_OffsetDown))
                    {
                        tempY = y - m_OffsetDown / 2;
                        break;
                    }

                    else
                    {
                        y -= m_OffsetDown;
                    }
                }
            }
            else
            {
                Debug.LogWarning("out of play zone");
            }
            
            return new Vector3(tempX, tempY);
        }

 }
}