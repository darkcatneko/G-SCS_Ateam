
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterMoveState : IState
{
    private bool allMoveFinish = false;
    //private bool commandPicAnim = false;
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        allMoveFinish = false;
        // Show information animation
        Controller.CallInformationAnimation();
        // Calculate all player step
        AllPlayerCountStep();
        // Delay 3.5f Do MovePlayer
        Controller.StartCoroutine((Controller.DelayDo(3.5f, () =>
        {
            Controller.StartCoroutine(MoveAllPlayer(() => { allMoveFinish = true; }));
        })));
        
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
            if(AllPlayerNoStepLeft()) Controller.ChangeState(StateEnum.GameOver);
            
            // Check if any player get enough points -> go to game over state
            if(AnyPlayerGetEnoughPoint()) Controller.ChangeState(StateEnum.GameOver);
            
            // Random decide if go to special event (If time enough)
            
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

    private void AllPlayerCountStep()
    {
        foreach (var player in Controller.players.Where(player => player.playerData.PlayerMovePoint > 0))
        {
            player.playerData.PlayerMovePoint--;
        }
    }

    private bool AllPlayerNoStepLeft()
    {
        return Controller.players.All(player => player.playerData.PlayerMovePoint <= 0);
    }


    private bool AnyPlayerGetEnoughPoint()
    {
        return Controller.players.Any(player => player.playerData.PlayerPoint >= Controller.TargetPoint);
    }
}
