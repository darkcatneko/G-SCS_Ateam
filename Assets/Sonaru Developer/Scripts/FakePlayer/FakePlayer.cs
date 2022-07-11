using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class FakePlayer : MonoBehaviour
{
    [SerializeField]public FakePlayerInput Input;
    private FakePlayerAction inputAction;
    public int PlayerIndex;

    public void Awake()
    {
        inputAction = new FakePlayerAction();
        Input = new FakePlayerInput(inputAction);
        SetPlayerInputEnable(true);
    }

    private void OnEnable()
    {
        
        Input.EnablePlayer(PlayerIndex);
    }

    public void SetPlayerInputEnable(bool enable)
    {
        if(enable) inputAction.Enable();
        else
        {
            Input.ResetCommand();
            inputAction.Disable();
        }
    }
}
