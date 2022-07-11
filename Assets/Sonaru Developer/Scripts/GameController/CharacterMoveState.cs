
using UnityEngine;

public class CharacterMoveState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        foreach (var player in Controller.players)
        {
            Debug.Log(player.Input.Command);
        }
    }

    public void OnStateStay()
    {
        // Start move character
        
    }

    public void OnStateExit()
    {
        Controller.CurrentRound++;
        Debug.Log("CharacterMove End");
    }
}
