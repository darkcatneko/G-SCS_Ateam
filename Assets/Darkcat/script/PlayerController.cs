using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    public GamePadRegistry My_GamePad;//���U�����
    public PlayerDataSo playerData; //���a�ƭ�   
    public Player player;//���Ӫ��a
    public CommandType My_Command;//�{�b��J�����O
    public bool Sure = false;    //�T�{��J
    public bool CanInput = false;
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
        if (CanInput)
        {
            if (player == Player.Player1 || player == Player.Player3)
            {
                if (My_GamePad._gamepad.buttonEast.isPressed)
                {
                    My_Command = CommandType.Right;
                    Debug.Log((int)this.player);
                }
            }

        }       
    }

    
}
