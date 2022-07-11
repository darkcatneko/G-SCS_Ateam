using System.Collections.Generic;
using SonaruUtilities;
using UnityEngine;


public class GridMap
{
    public Vector3 originPosition = Vector3.zero;
    public bool OpenDebugMode = true;
    
    private int columnNum;
    private int rowNum;
    private float cellSize;
    private GridBlock[,] allGridBlocks;
    private TextMesh[,] debugTexts;
    
    public GridMap(int row, int col, float size)
    {
        rowNum = row;
        columnNum = col;
        cellSize = size;

        allGridBlocks = new GridBlock[rowNum, columnNum];
        for(var i = 0; i < rowNum; i++)
        {
            for (var j = 0; j < columnNum; j++)
            {
                allGridBlocks[i, j] = new GridBlock(this, i, j);
            }
        }
        
        if(OpenDebugMode) UseDebugText();
    }


    private void UseDebugText()
    {
        debugTexts = new TextMesh[rowNum, columnNum];
        for(int x = 0; x < debugTexts.GetLength(0); x++)
        {
            for(int y = 0; y < debugTexts.GetLength(1); y++)
            {
                debugTexts[x, y] = DebugTextMesh.CreatWorldText(allGridBlocks[x, y]?.ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, (int)(0.125f * cellSize * cellSize + 7.5f), Color.blue, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.red, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.red, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, columnNum), GetWorldPosition(rowNum, columnNum), Color.red, 100f);
        Debug.DrawLine(GetWorldPosition(rowNum, 0), GetWorldPosition(rowNum, columnNum), Color.red, 100f);
    }


    public Vector3 GetWorldPosition(int x, int y)
    {
        Debug.Log(x+" " + y );
        return new Vector3(x, 0, y) * cellSize + originPosition;
    }
}
