using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMap", menuName = "Map/Map")]

public class MapSO : ScriptableObject
{
    public List<Row> ThisMap = new List<Row>();

    public Block GetBlockData(int ColIndex, int RowIndex)
    {
        // Check if the row exist
        if (ColIndex >= ThisMap.Count) return null;
        
        var currentRow = ThisMap[ColIndex];
        
        // check if the column exist
        if (RowIndex >= currentRow.ThisRow.Count) return null;
        
        var currentBlock = currentRow.ThisRow[RowIndex];
        return currentBlock;
    }


    public Vector3 GetWorldPosition(int ColIndex, int RowIndex)
    {
        var originPos = new Vector3(-110, 7.5f, -120);
        var cellSize = 20;
        var xPos = ColIndex * cellSize + cellSize * .5f;
        var zPos = RowIndex * cellSize + cellSize * .5f;

        return originPos + new Vector3(xPos, 0, zPos);
    }
}
