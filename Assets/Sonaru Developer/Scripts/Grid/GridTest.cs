using System;
using UnityEngine;

namespace Sonaru_Developer.Scripts
{
    public class GridTest : MonoBehaviour
    {
        private GridMap gridMap;
        public int RowNumber;
        public int ColumnNumber;
        public float CellSize;
        
        public bool GridMapDebug;

        private void Awake()
        {
            gridMap = new GridMap(RowNumber, ColumnNumber, CellSize, GridMapDebug);
        }
    }
}