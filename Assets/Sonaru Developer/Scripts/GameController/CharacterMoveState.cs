
using UnityEngine;

public class CharacterMoveState : IState
{
    private int targetCommand = 0;
    private bool allMoveFinish = false;
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        targetCommand = 0;
        allMoveFinish = false;
    }

    public void OnStateStay()
    {
        // Start move character
        if (Controller.Character.MoveOver && !allMoveFinish)
        {
            Debug.Log(targetCommand + ": " + Controller.OurInput[targetCommand]);
            Controller.Character.CommandMoveCharacter(Controller.OurInput[targetCommand]);
            allMoveFinish = targetCommand == Controller.OurInput.Length - 1;
            if(!allMoveFinish) targetCommand++;
        }

        if (Controller.Character.MoveOver && allMoveFinish)
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
}
