using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewRow", menuName = "Map/Row")]

public class Row : ScriptableObject
{
    public List<Block> ThisRow = new List<Block>();
}
