using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Linq;

public class PlayerManager
{
    public static Dictionary<Gamepad, GamePadRegistry> playerList = new();
}
public class GamePadRegistry : MonoBehaviour
{
    public Gamepad _gamepad;
    
    public enum Check
    {
        circle, cross
    }
    public Check check;
    public bool isChecked = false;
    public ButtonControl RightEastButton;
    public ButtonControl RightNorthButton;
    public ButtonControl RightSouthButton;
    public ButtonControl RightWestButton;
    public DpadControl LeftDpad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChecked)
        {
            foreach (Gamepad g in Gamepad.all)
            {
                if (PlayerManager.playerList.Keys.Contains(g)) continue;
                if (check == Check.circle)
                {
                    if (g.buttonEast.isPressed)
                    {
                        _gamepad = g;
                        isChecked = true;                      
                        PlayerManager.playerList.Add(g, this);
                        RightEastButton = _gamepad.buttonEast;
                        RightNorthButton= _gamepad.buttonNorth;
                        RightSouthButton = _gamepad.buttonSouth;
                        RightWestButton = _gamepad.buttonWest;
                        LeftDpad = _gamepad.dpad;
                        Debug.Log(check.ToString());
                        return;
                    }
                }
                else if (check == Check.cross)
                {
                    if (g.buttonSouth.isPressed)
                    {
                        _gamepad = g;
                        isChecked = true;
                        PlayerManager.playerList.Add(g, this);
                        RightEastButton = _gamepad.buttonEast;
                        RightNorthButton = _gamepad.buttonNorth;
                        RightSouthButton = _gamepad.buttonSouth;
                        RightWestButton = _gamepad.buttonWest;
                        LeftDpad = _gamepad.dpad;
                        Debug.Log(check.ToString());
                        return;
                    }
                }
            }
            return;
        }
    }
}
