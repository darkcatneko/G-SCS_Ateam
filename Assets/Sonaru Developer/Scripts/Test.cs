using System;
using UnityEngine;

namespace Sonaru_Developer.Scripts
{
    public class Test : MonoBehaviour
    {
        private GridMap gridMap;

        private void Awake()
        {
            gridMap = new GridMap(10, 10, 10);
        }
    }
}