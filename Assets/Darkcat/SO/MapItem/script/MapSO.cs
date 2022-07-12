using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMap", menuName = "Map/Map")]

public class MapSO : ScriptableObject
{
    public List<Row> ThisMap = new List<Row>();

    public Block GetBlockData(int rowIndex, int colIndex)
    {
        // Check if the row exist
        if (rowIndex >= ThisMap.Count) return null;
        
        var currentRow = ThisMap[rowIndex];
        
        // check if the column exist
        if (colIndex >= currentRow.ThisRow.Count) return null;
        
        var currentBlock = currentRow.ThisRow[colIndex];
        return currentBlock;
    }
}
