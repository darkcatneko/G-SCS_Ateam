using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    public float Destroytime;
    void Start()
    {
        Destroy(this.gameObject, Destroytime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
