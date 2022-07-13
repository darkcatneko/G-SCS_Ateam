
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class GameOverState : IState
{
    private bool enableGameRestartInput = false;
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        enableGameRestartInput = false;
        
        MainGameUIController.instance.ChosenOneIsYou(GetHighestPlayer());
        MainGameUIController.instance.CallEnding();
        
        //Delay: 1.5f -> Enable player input to restart game 
        Controller.StartCoroutine(Controller.DelayDo(1.5f, () => enableGameRestartInput = true ));
    }

    public void OnStateStay()
    {
        
        if (enableGameRestartInput)
        {
            // detect input to restart game.
            foreach (Gamepad g in Gamepad.all)
            {
                if (g.buttonNorth.isPressed)
                {
                    foreach (var player in Controller.players)
                    {
                        player.playerData.clear();
                    }
                    SceneManager.LoadScene("Menu");
                }
                
            }           
        }
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
