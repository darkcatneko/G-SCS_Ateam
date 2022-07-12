
using UnityEngine;

public class CharacterMoveState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        foreach (var command in Controller.OurInput)
        {
            Debug.Log(command);
        }
    }

    public void OnStateStay()
    {
        // Start move character
        
        // Check if all player not left any move point -> go to game over state
        
        // Check if any player get enough points -> go to game over state
        
        // Random decide if go to special event
        
        // else: round + 1 -> go to player command state
        
    }

    public void OnStateExit()
    {
        Controller.CurrentRound++;
    }
}
