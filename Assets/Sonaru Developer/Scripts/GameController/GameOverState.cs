


public class GameOverState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;

        MainGameUIController.instance.ChosenOneIsYou(GetHighestPlayer());
        MainGameUIController.instance.CallEnding();
    }

    public void OnStateStay()
    {
        
    }

    public void OnStateExit()
    {
        
    }


    private Player GetHighestPlayer()
    {
        var highestP = Controller.players[0];
        foreach (var player in Controller.players)
        {
            if (player.playerData.PlayerPoint > highestP.playerData.PlayerPoint) highestP = player;

        }

        return highestP.player;
    }
}
