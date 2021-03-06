using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class TwoControllerRegistry : MonoBehaviour
{
    public static TwoControllerRegistry instance;
    public GamePadRegistry Player1and2;
    public GamePadRegistry Player3and4;
    public Animator P12;
    public Animator P34;
    public Animator Maincanvas;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1and2.isChecked && Player3and4.isChecked)
        {
            Maincanvas.SetBool("AllSure", true);
        }
        //production
        foreach (Gamepad g in Gamepad.all)
        {
            if (Player1and2.isChecked && Player3and4.isChecked)
            {
                if (g.rightTrigger.isPressed || g.leftTrigger.isPressed)
                {
                    Debug.Log("next scene");
                    //SceneManager.LoadScene("MainGameScene");
                    //SceneManager.LoadScene("NewGridTest");
                    Maincanvas.SetBool("IntoGame", true);
                }
            }
        }
    }
      
}
