

using UnityEngine;

public class PointData
{
    public int RowIndex;
    public int ColIndex;
    public GameObject ItemObject;
    public bool IsActive;
    
    public PointData(int col, int row, GameObject obj)
    {
        RowIndex = row;
        ColIndex = col;
        ItemObject = obj;
    }
    
    
}
