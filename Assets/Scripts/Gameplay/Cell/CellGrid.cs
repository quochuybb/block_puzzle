using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellGrid : MonoBehaviour
{
    public Image cellImage;
    public List<Sprite> cellImages;

    private void Awake()
    {
        cellImage = GetComponent<Image>();
    }

    public void SetImage(SkillPointType value)
    {
        cellImage.sprite = cellImages[(int)value];
    }
}
