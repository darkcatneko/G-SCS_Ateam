using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewBlock", menuName = "Block/Trap")]
public class BackTrap : Block
{

    // Update is called once per frame
    public void ThisFunc()
    {
        Debug.Log("1");
    }
}
