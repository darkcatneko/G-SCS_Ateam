

public class StartGameState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
    }

    public void OnStateStay()
    {
        
    }

    public void OnStateExit()
    {
        
    }
}
