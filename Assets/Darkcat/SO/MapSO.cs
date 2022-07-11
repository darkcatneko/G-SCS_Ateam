using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMap", menuName = "Map/Map")]

public class MapSO : ScriptableObject
{
    public List<Row> ThisMap = new List<Row>();
}
