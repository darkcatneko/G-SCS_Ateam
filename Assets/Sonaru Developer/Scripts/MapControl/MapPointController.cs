using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapPointController : MonoBehaviour
{
    public MapSO WorldMap;

    public GameObject FireItem;
    public GameObject WaterItem;
    public GameObject WindItem;
    public GameObject EarthItem;

    private Dictionary<ElementType, List<PointData>> allPoints;
    
    private void Awake()
    {
        allPoints = new Dictionary<ElementType, List<PointData>>()
        {
            {ElementType.Fire, new List<PointData>()},
            {ElementType.Water, new List<PointData>()},
            {ElementType.Wind, new List<PointData>()},
            {ElementType.Earth, new List<PointData>()}
        };
        
        for (var i = 0; i < WorldMap.ThisMap.Count; i++)
        {
            for (var j = 0; j < WorldMap.ThisMap[i].ThisRow.Count; j++)
            {
                var theBlock = WorldMap.ThisMap[i].ThisRow[j];
                if (theBlock.ThisBlockType == BlockType.Point)
                {
                    var element = ((Points) theBlock).This_ELEMENT;
                    switch (element)
                    {
                        case ElementType.Fire:
                            var fire = Instantiate(FireItem, transform).GetComponent<PointData>();
                            fire.Init(element, i, j, TrySpawnAnother);
                            allPoints[element].Add(fire);
                            break;
                        case ElementType.Water:
                            var water = Instantiate(WaterItem, transform).GetComponent<PointData>();
                            water.Init(element, i, j, TrySpawnAnother);
                            allPoints[element].Add(water);
                            break;
                        case ElementType.Wind:
                            var wind = Instantiate(WindItem, transform).GetComponent<PointData>();
                            wind.Init(element, i, j, TrySpawnAnother);
                            allPoints[element].Add(wind);
                            break;
                        case ElementType.Earth:
                            var earth = Instantiate(EarthItem, transform).GetComponent<PointData>();
                            earth.Init(element, i, j, TrySpawnAnother);
                            allPoints[element].Add(earth);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        
        SpawnAll();
    }


    private void Update()
    {
        
    }

    private void SpawnAll()
    {
        foreach (var item in allPoints.Values.SelectMany(elementItem => elementItem))
        {
            item.Spawn(WorldMap.GetWorldPosition(item.ColIndex, item.RowIndex));
        }
    }
    
    
    // Only run when total points amount is two. QQ 
    private PointData CheckNeedSpawn(PointData nowRemoveData)
    {
       var index = allPoints[nowRemoveData.ElementType].IndexOf(nowRemoveData);
       var targetData = allPoints[nowRemoveData.ElementType][1 - index];
       return targetData.IsActive ? null : targetData;
    }

    private void TrySpawnAnother(PointData nowRemoveData)
    {
        var target = CheckNeedSpawn(nowRemoveData);
        if (target != null) target.Spawn(WorldMap.GetWorldPosition(target.ColIndex, target.RowIndex));
    }
}
