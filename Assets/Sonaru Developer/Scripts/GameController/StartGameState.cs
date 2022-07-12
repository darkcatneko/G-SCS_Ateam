

using UnityEngine;

public class StartGameState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        Controller.Character.SetOriginPos(5,1);
        Debug.Log(Controller.Character.worldMap.GetWorldPosition(5, 1));
    }

    public void OnStateStay()
    {
        Controller.ChangeState(StateEnum.PlayerCommand);
    }

    public void OnStateExit()
    {
        
    }
}
