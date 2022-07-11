using System.Collections;
using System.Collections.Generic;
using SonaruUtilities;
using UnityEngine;

[System.Serializable]
public class GridBlock
{
    private GridMap grid;
    public int XIndex;
    public int YIndex;

    public bool IsObstacle;


    public GridBlock(GridMap gridMap, int xIndex, int yIndex)
    {
        grid = gridMap;
        XIndex = xIndex;
        YIndex = yIndex;
    }

    
    public void SetObstacle(bool isObstacle)
    {
        IsObstacle = isObstacle;
    }


    public override string ToString()
    {
        return XIndex + "," + YIndex;
    }
}
