using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class test : MonoBehaviour
{
    public MapSO MyMap;
    public UnityEvent Eventer = new UnityEvent();
    void Start()
    {
        MyMap.ThisMap[0].ThisRow[0].SP_event.Invoke();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
