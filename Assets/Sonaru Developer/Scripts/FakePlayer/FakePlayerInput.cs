
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class FakePlayerInput
{
    private FakePlayerAction inputAction;
    [SerializeField]private CommandType command;

    public CommandType Command
    {
        get => command;
        set
        {
            if(IsChecked) return;
            command = value;
        }
    }

    public bool IsChecked;
  
    public FakePlayerInput(FakePlayerAction inputAction)
    {
        this.inputAction = inputAction;
        ResetCommand();
    }

    public void ResetCommand()
    {
        IsChecked = false;
        Command = CommandType.NOTHING;
    }

    public void EnablePlayer(int i)
    {
        switch (i)
        {
            case 1:
                EnablePlayer1();
                break;
            case 2:
                EnablePlayer2();
                break;
            case 3:
                EnablePlayer3();
                break;
            case 4:
                EnablePlayer4();
                break;
            
            default:
                break;
        }
    }

    private void EnablePlayer1()
    {
        inputAction.FakePlayer1.Up.performed += ctx => Command = CommandType.Up;
        inputAction.FakePlayer1.Down.performed += ctx => Command = CommandType.Down;
        inputAction.FakePlayer1.Left.performed += ctx => Command = CommandType.Left;
        inputAction.FakePlayer1.Right.performed += ctx => Command = CommandType.Right;
        inputAction.FakePlayer1.Check.performed += ctx => IsChecked = !IsChecked;
    }

    private void EnablePlayer2()
    {
        inputAction.FakePlayer2.Up.performed += ctx => Command = CommandType.Up;
        inputAction.FakePlayer2.Down.performed += ctx => Command = CommandType.Down;
        inputAction.FakePlayer2.Left.performed += ctx => Command = CommandType.Left;
        inputAction.FakePlayer2.Right.performed += ctx => Command = CommandType.Right;
        inputAction.FakePlayer2.Check.performed += ctx => IsChecked = !IsChecked;
    }
    
    private void EnablePlayer3()
    {
        inputAction.FakePlayer3.Up.performed += ctx => Command = CommandType.Up;
        inputAction.FakePlayer3.Down.performed += ctx => Command = CommandType.Down;
        inputAction.FakePlayer3.Left.performed += ctx => Command = CommandType.Left;
        inputAction.FakePlayer3.Right.performed += ctx => Command = CommandType.Right;
        inputAction.FakePlayer3.Check.performed += ctx => IsChecked = !IsChecked;
    }
    
    private void EnablePlayer4()
    {
        inputAction.FakePlayer4.Up.performed += ctx => Command = CommandType.Up;
        inputAction.FakePlayer4.Down.performed += ctx => Command = CommandType.Down;
        inputAction.FakePlayer4.Left.performed += ctx => Command = CommandType.Left;
        inputAction.FakePlayer4.Right.performed += ctx => Command = CommandType.Right;
        inputAction.FakePlayer4.Check.performed += ctx => IsChecked = !IsChecked;
    }
    
    
}
