using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointController : MonoBehaviour
{
    public MapSO WorldMap;

    public GameObject FireItem;
    public GameObject WaterItem;
    public GameObject WindItem;
    public GameObject EarthItem;

    private void Awake()
    {
        
        
        for (var i = 0; i < WorldMap.ThisMap.Count; i++)
        {
            for (var j = 0; j < WorldMap.ThisMap[i].ThisRow.Count; j++)
            {
                var theBlock = WorldMap.ThisMap[i].ThisRow[j];
                if (theBlock.ThisBlockType == BlockType.Point)
                {
                    if (((Points) theBlock).This_ELEMENT == ElementType.Fire)
                    {
                        
                    }
                    
                }
            }
        }
    }
    
    
}
