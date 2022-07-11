
using UnityEngine;

/// <summary>
/// 玩家下指令狀態
/// 結束條件：四名玩家按下確認 or 倒數時間到
/// </summary>

public class PlayerCommandState : IState
{
    public GameController Controller { get; set; }
    public void OnStateEnter(GameController controller)
    {
        Debug.Log("PlayerCommand Start");
        Controller = controller;
        
        //Reset countdown timer 
        
        // change player command order
        
    }

    public void OnStateStay()
    {
        // wait player command until time finished

        if (Controller.AllChecked())
        {
            Controller.ChangeState(StateEnum.CharacterMove);
        }
    }

    public void OnStateExit()
    {
        Debug.Log("PlayerCommand End");
    }
    
    
}
