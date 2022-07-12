

public class StartGameState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        Controller.Character.SetOriginPos(2,3);
    }

    public void OnStateStay()
    {
        Controller.ChangeState(StateEnum.PlayerCommand);
    }

    public void OnStateExit()
    {
        
    }
}
