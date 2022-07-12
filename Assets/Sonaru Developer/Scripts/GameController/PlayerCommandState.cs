
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

        countdownTimer = Controller.RoundLastTime;
        //Reset countdown timer 
        
        // change player command order
        Controller.NowLeadPlayer = Controller.LeaderChange(Controller.NowLeadPlayer);
    }

    public void OnStateStay()
    {
        // wait player command until time finished
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0)
        {
            Debug.Log("小王八蛋給我按喔");
            Controller.ChangeState(StateEnum.CharacterMove);
        }
             
        if (Controller.AllChecked())
        {
            Controller.ChangeState(StateEnum.CharacterMove);
        }
    }

    public void OnStateExit()
    {
        // Get all commands
        Controller.CollectInput();
    }
    
    
}
