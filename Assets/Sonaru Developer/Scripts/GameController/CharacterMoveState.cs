
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveState : IState
{
    //private int targetCommand = 0;
    private bool allMoveFinish = false;
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        //targetCommand = 0;
        allMoveFinish = false;

        Controller.StartCoroutine(MoveAllPlayer(() => { allMoveFinish = true; }));
    }

    public void OnStateStay()
    {
        // Start move character
        // if (Controller.Character.MoveOver && !allMoveFinish)
        // {
        //     Debug.Log(targetCommand + ": " + Controller.OurInput[targetCommand]);
        //     Controller.Character.CommandMoveCharacter(Controller.OurInput[targetCommand]);
        //     allMoveFinish = targetCommand == Controller.OurInput.Length - 1;
        //     if(!allMoveFinish) targetCommand++;
        // }

        if (allMoveFinish)
        {
            // Check if all player not left any move point -> go to game over state
                    
            // Check if any player get enough points -> go to game over state
            
            // Random decide if go to special event
            
            // else: round + 1 -> go to player command state
            Controller.ChangeState(StateEnum.PlayerCommand);
        }
    }

    public void OnStateExit()
    {
        Controller.CurrentRound++;
    }

    private IEnumerator MoveAllPlayer(Action onFinish = null)
    {
        foreach (var t in Controller.OurInput)
        {
            yield return WaitForMoveOver(t);
        }
        onFinish?.Invoke();
    }

    private IEnumerator WaitForMoveOver(CommandType command)
    {
        Controller.Character.CommandMoveCharacter(command);
        while (!Controller.Character.MoveOver)
        {
            yield return null;
        }
    }
}
