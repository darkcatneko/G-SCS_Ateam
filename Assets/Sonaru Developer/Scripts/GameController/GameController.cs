using System;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public int TotalRound;
    public List<FakePlayer> players;
    public int CurrentRound { get; set; }
    public bool CanInput = false;
    [SerializeField] private StateEnum currentState; 
    
    //private IState currentState;
    private Dictionary<StateEnum, IState> allStateDict;

    private void Awake()
    {
        CurrentRound = 1;

        allStateDict = new Dictionary<StateEnum, IState>
        {
            {StateEnum.NOTHING, null},
            {StateEnum.PlayerCommand, new PlayerCommandState()},
            {StateEnum.CharacterMove, new CharacterMoveState()}
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
}
