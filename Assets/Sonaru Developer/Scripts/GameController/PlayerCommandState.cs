
using UnityEngine;

/// <summary>
/// 玩家下指令狀態
/// 結束條件：四名玩家按下確認 or 倒數時間到
/// </summary>

public class PlayerCommandState : IState
{
    private float countdownTimer;
    
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Controller = controller;
        
        // open player input
        for (var i = 0; i < Controller.players.Count; i++)
        {
            var player = Controller.players[i];
            player.CanInput = true;
            player.Sure = false;
            player.My_Command = CommandType.NOTHING;
            MainGameUIController.instance.Displays[i].PlayerUIOutLine.SetActive(false);
        }

        //Reset countdown timer 
        countdownTimer = Controller.RoundLastTime;
        MainGameUIController.instance.SampleTime = countdownTimer;

        // change player command order
        Controller.NowLeadPlayer = Controller.LeaderChange(Controller.NowLeadPlayer);
        // change the marker on the ui
        MainGameUIController.instance.ChangeLeaderMark((int)Controller.NowLeadPlayer);
    }

    public void OnStateStay()
    {
        // wait player command until time finished
        countdownTimer -= Time.deltaTime;
        MainGameUIController.instance.SampleTime = countdownTimer;
        if (countdownTimer <= 0)
        {
            Debug.Log("小王八蛋給我按喔");
            Controller.ChangeState(StateEnum.CharacterMove);
        }
             
        else if (Controller.AllChecked())
        {
            Controller.ChangeState(StateEnum.CharacterMove);
        }
    }

    public void OnStateExit()
    {
        // close player input
        foreach (var player in Controller.players)
        {
            player.CanInput = false;
        }
        // Get all commands
        Controller.CollectInput();
    }
    
    
}
