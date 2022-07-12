using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBlock", menuName = "Block/Point")]

public class Points : Block
{
    [SerializeField] ElementType This_ELEMENT;
   public void GainPoint()
    {
        switch(This_ELEMENT)
        {
            case ElementType.Fire:
                return;
            case ElementType.Water:
                return;
            case ElementType.Wind:
                return;
            case ElementType.Earth:
                return;

        }
    }
}
