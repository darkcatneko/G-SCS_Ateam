using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGamePlayerData : MonoBehaviour
{
    public PlayerDataSo[] Players = new PlayerDataSo[4];
    public static MainGamePlayerData instance;
    private void Awake()
    {
        instance = this;
    }
}
