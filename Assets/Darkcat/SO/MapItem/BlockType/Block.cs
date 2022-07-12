using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public enum BlockType
{
    Empty,
    Wall,
    Trap,
    Point,
}


public abstract class Block : ScriptableObject
{
    public BlockType ThisBlockType;
    public UnityEvent SP_event = new UnityEvent();
    
}

