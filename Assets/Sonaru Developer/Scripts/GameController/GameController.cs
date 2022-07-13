﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public int TotalRound;
    public MainCharacter Character;                     //主角
    public List<PlayerController> players;              //更新為新的playerInput
    public Player NowLeadPlayer;                        //領頭玩家
    public CommandType[] OurInput = new CommandType[4]; //總輸入
    [SerializeField] Sprite[] commandPic;               //圖庫
    public Animator MainUIAnimator;                     //UI動畫器
    public int CurrentRound;
    //public bool CanInput = false;
    //public bool IsLastRound => CurrentRound >= TotalRound;
    public float RoundLastTime = 20;
    //public bool StartCountDown = false;
    
    [SerializeField] private StateEnum currentState;
    private Dictionary<StateEnum, IState> allStateDict;
    

    private void Awake()
    {
        CurrentRound = 1;

        allStateDict = new Dictionary<StateEnum, IState>
        {
            {StateEnum.NOTHING, null},
            {StateEnum.StartGame, new StartGameState()},
            {StateEnum.PlayerCommand, new PlayerCommandState()},
            {StateEnum.CharacterMove, new CharacterMoveState()},
            {StateEnum.GameOver, new GameOverState()},
            {StateEnum.SpecialEvent, new SpecialEventState()}
        };

        ChangeState(StateEnum.StartGame);
    }

    private void Update()
    {
        allStateDict[currentState]?.OnStateStay();
    }


    public void ChangeState(StateEnum newState)
    {
        allStateDict[currentState]?.OnStateExit();
        
        if(allStateDict[newState] == null ) return;
        
        currentState = newState;
        allStateDict[currentState].OnStateEnter(this);
    }


    public bool AllChecked()
    {
        return players.All(player => player.Sure);
    }
    
    public Player LeaderChange(Player Now)
    {
        switch((int)Now)
        {
            case 0:
                return Player.Player2;
            case 1:
                return Player.Player3;
            case 2:
                return Player.Player4;
            case 3:
                return Player.Player1;
            default:
                return Player.Player1;
        }
    }
    public PlayerController Find_PC(int Playernum)
    {
        return players[Playernum % 4];
    }
    public void CollectInput()
    {
        for (int i = 0; i < OurInput.Length; i++)
        {
            OurInput[i] = Find_PC((int)NowLeadPlayer + i).My_Command;
        }
        ChangeCommandPic("FirstCommand", 0);
        ChangeCommandPic("SecondCommand", 1);
        ChangeCommandPic("ThirdCommand", 2);
        ChangeCommandPic("FourCommand", 3);
    }
    public void ChangeCommandPic(string which,int num)
    {
        MainGameUIController.instance.InformationBoard.transform.Find(which).GetComponent<Image>().sprite = commandPic[(int)OurInput[num]];
    }
    
    // Duration : 3.5f
    public void CallInformationAnimation()
    {
        MainUIAnimator.SetTrigger("FinishInput");
    }

    public IEnumerator DelayDo(float delay, Action onFinish = null)
    {
        yield return new WaitForSeconds(delay);
        onFinish?.Invoke();
    }
}
