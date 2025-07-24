using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Shape Data", menuName = "Shape Data")]
[System.Serializable]
public class ShapeData : ScriptableObject
{
    [System.Serializable]

    public class Row
    {
        public Cell[] cols;
        private int _size;

        public Row()
        {
            
        }

        public Row(int size,SkillPointType pointType)
        {
            CreateRow(size,pointType);
        }

        public void CreateRow(int size,SkillPointType pointType)
        {
            _size = size;
            cols = new Cell[_size];
            ClearRow();
            AssignSkillPoint(pointType);
        }


        public void ClearRow()
        {
            for (int i = 0; i < _size; i++)
            {
                cols[i].isEmpty = false;
            }
        }

        public void AssignSkillPoint(SkillPointType pointType)
        {
            for (int i = 0; i < _size; i++)
            {
                cols[i].pointType = pointType;
            }
        }
    }

    public int rows;
    public int cols;
    public Row[] board;

    public void ClearBoard()
    {
        for (int i = 0; i < rows; i++)
        {
            board[i].ClearRow();
        }
    }

    public void CreateBoard()
    {
        SkillPointType pointType = (SkillPointType)Random.Range(0, System.Enum.GetValues(typeof(SkillPointType)).Length);

        board = new Row[rows];
        for (int i = 0; i < rows; i++)
        {
            board[i] = new Row(cols,pointType);
        }

    }
}
