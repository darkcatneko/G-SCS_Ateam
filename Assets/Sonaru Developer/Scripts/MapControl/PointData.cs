

using System;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PointData : MonoBehaviour
{
    public ElementType ElementType;
    public int RowIndex;
    public int ColIndex;
    public Action<PointData> OnInactive;
    
    private bool isActive;

    public bool IsActive
    {
        get => isActive;
        set
        {
            if(value == false) OnInactive?.Invoke(this);
            isActive = value;
        }
    }

    public void Init(ElementType eType, int col, int row, Action<PointData> onInactive = null)
    {
        ElementType = eType;
        RowIndex = row;
        ColIndex = col;
        isActive = false;
        OnInactive += onInactive;
        gameObject.SetActive(isActive);
    }

    public void Spawn(Vector3 pos)
    {
        transform.position = pos;
        IsActive = true;
        gameObject.SetActive(IsActive);
    }

    public void Remove()
    {
        IsActive = false;
        gameObject.SetActive(IsActive);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            Remove();
        }
    }
}
