using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNum
{
    Player1,
    Player2,
    Player3,
    Player4,
}
public enum PlayerInput
{
    Up,
    Right,
    Left,
    Down,
    none,
}
[CreateAssetMenu(fileName = "NewPlayer", menuName = "Player")]
public class PlayerDataSo : ScriptableObject
{
    public PlayerNum ThisPlayer;
    public int PlayerMovePoint = 100;
    public int PlayerPoint=0;
    public bool Sure = false;
    public PlayerInput My_Input = PlayerInput.none;
    public ElementType PlayerElementType;

    public void GetFavorite()
    {
        PlayerPoint += 2;
    }
    public void GetDislike()
    {
        PlayerMovePoint -= 2;
    }
    
}
