using System;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public int TotalRound;
    public List<FakePlayer> players;
    public int CurrentRound;
    public bool CanInput = false;
    //public bool IsLastRound => CurrentRound >= TotalRound;
    public float RoundLastTime = 5;
    public bool StartCountDown = false;
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

        ChangeState(StateEnum.PlayerCommand);
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
        foreach (var player in players)
        {
            if (!player.Input.IsChecked) return false;
        }

        return true;
    }

    public void StartTimer()
    {
        RoundLastTime = 5;
        StartCountDown = true;
    }
}
