using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    public GamePadRegistry My_GamePad;//註冊的手把
    public PlayerDataSo playerData; //玩家數值   
    public Player player;//哪個玩家
    public CommandType My_Command = CommandType.NOTHING;//現在輸入的指令
    public bool Sure = false;    //確認輸入
    public bool CanInput = false;

    private bool RSIP;
    private bool LSIP;
    void Start()
    {
        switch (player)
        {
            case Player.Player1:
                Debug.Log("success register Player1");
                My_GamePad = GameObject.Find("GamePad1&2").GetComponent<GamePadRegistry>();
                return;
            case Player.Player2:
                Debug.Log("success register Player2");
                My_GamePad = GameObject.Find("GamePad1&2").GetComponent<GamePadRegistry>();
                return;
            case Player.Player3:
                Debug.Log("success register Player3");
                My_GamePad = GameObject.Find("GamePad3&4").GetComponent<GamePadRegistry>();
                return;
            case Player.Player4:
                Debug.Log("success register Player4");
                My_GamePad = GameObject.Find("GamePad3&4").GetComponent<GamePadRegistry>();
                return;
        }
    }
   
    void Update()
    {
        OnlyOneClick();
        if (CanInput)
        {
            if (player == Player.Player1 || player == Player.Player3)
            {
                if (My_GamePad._gamepad.buttonEast.isPressed)
                {
                    My_Command = CommandType.Right;
                    Debug.Log((int)this.player);
                }
                if (My_GamePad._gamepad.buttonWest.isPressed)
                {
                    My_Command = CommandType.Left;
                    Debug.Log((int)this.player);
                }
                if (My_GamePad._gamepad.buttonNorth.isPressed)
                {
                    My_Command = CommandType.Up;
                    Debug.Log((int)this.player);
                }
                if (My_GamePad._gamepad.buttonSouth.isPressed)
                {
                    My_Command = CommandType.Down;
                    Debug.Log((int)this.player);
                }
                if (My_GamePad._gamepad.rightShoulder.isPressed&&RSIP == false)
                {
                    Debug.Log("shoulderpress");
                    RSIP = true;
                    Sure = !Sure;
                }
                if (My_GamePad._gamepad.rightTrigger.isPressed)
                {
                    My_Command = CommandType.NOTHING;
                    Debug.Log((int)this.player);
                }
            }
            if (player == Player.Player2 || player == Player.Player4)
            {
                if (My_GamePad.LeftDpad.ReadValue() == new Vector2(1, 0))
                {
                    My_Command = CommandType.Right;
                    Debug.Log((int)this.player);
                }
                if (My_GamePad.LeftDpad.ReadValue() == new Vector2(-1, 0))
                {
                    My_Command = CommandType.Left;
                    Debug.Log((int)this.player);
                }
                if (My_GamePad.LeftDpad.ReadValue() == new Vector2(0, 1))
                {
                    My_Command = CommandType.Up;
                    Debug.Log((int)this.player);
                }
                if (My_GamePad.LeftDpad.ReadValue() == new Vector2(-1, 0))
                {
                    My_Command = CommandType.Down;
                    Debug.Log((int)this.player);
                }
                if (My_GamePad._gamepad.leftShoulder.isPressed && LSIP == false)
                {
                    Debug.Log("shoulderpress");
                    LSIP = true;
                    Sure = !Sure;
                }
                if (My_GamePad._gamepad.leftShoulder.isPressed)
                {
                    My_Command = CommandType.NOTHING;
                    Debug.Log((int)this.player);
                }
            }

        }       
    }
    public void OnlyOneClick()
    {
        if (!My_GamePad._gamepad.rightShoulder.isPressed&&RSIP == true)
        {
            RSIP = false;
        }
        if (!My_GamePad._gamepad.leftShoulder.isPressed && LSIP == true)
        {
            LSIP = false;
        }
    }
    
}
