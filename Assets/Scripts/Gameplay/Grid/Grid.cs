using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int cols = 0;
    [SerializeField] private int rows = 0;
    public float cellOffset = 0.0f;
    private Vector2 startPos = new Vector2(0, 0);
    [SerializeField] private float cellScale;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private List<GameObject> cellPrefabs = new List<GameObject>();
    private Vector2 _offset;

    private void Start()
    {
        SpawnGridCells();
        SetGridCellPositions();
    }

    private void SpawnGridCells()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                cellPrefabs.Add(Instantiate(cellPrefab) as GameObject);
                cellPrefabs[cellPrefabs.Count - 1].transform.SetParent(this.transform);
                cellPrefabs[cellPrefabs.Count - 1].transform.localScale = new Vector3(cellScale, cellScale, cellScale);
                cellPrefabs[cellPrefabs.Count - 1].GetComponent<CellGrid>().SetImage(SkillPointType.None);
            }
        }
    }

    private void SetGridCellPositions()
    {
        int columns = 0;
        int rows = 0;
        var cellRect = cellPrefabs[0].GetComponent<RectTransform>();
        _offset.x = cellRect.rect.width * cellRect.localScale.x + cellOffset;
        _offset.y = cellRect.rect.height * cellRect.localScale.y + cellOffset;
        foreach (var cell in cellPrefabs)
        {
            if (columns + 1 > cols)
            {
                
                columns = 0;
                rows++;
            }

            var pos_x_offset = _offset.x * columns;
            var pos_y_offset = _offset.y * rows;
            cell.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPos.x + pos_x_offset, startPos.y - pos_y_offset);
            cell.GetComponent<RectTransform>().localPosition = new Vector3(startPos.x + pos_x_offset, startPos.y - pos_y_offset,0f);
        }
    }
}
