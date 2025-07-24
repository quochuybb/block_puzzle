using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public bool isEmpty;
    public SkillPointType pointType;

    public Cell()
    {
            
    }

    public Cell(bool isEmpty, SkillPointType pointType)
    {
        this.isEmpty = isEmpty;
    }
}
