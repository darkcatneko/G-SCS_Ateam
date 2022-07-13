using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class MenuControl : MonoBehaviour
{

    //public bool InstructionOpened = false;
    //public Image InstructionPIC;
    //[SerializeField] Vector2 StartPoint;

    public List<Gamepad> Controller = new List<Gamepad>();
    public bool[] IsPressing;
    private void Start()
    {
        //StartPoint = InstructionPIC.rectTransform.anchoredPosition;
        foreach (Gamepad g in Gamepad.all)
        {
            Controller.Add(g);            
        }
        IsPressing = new bool[Controller.Count];
    }
    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < Controller.Count; i++)
        {
            var g = Controller[i];
            if (IsPressing[i]&& !Controller[i].buttonWest.isPressed)
            {
                IsPressing[i] = false;
            }
            if (g.buttonEast.isPressed)
            {
                SceneManager.LoadScene("TwoControllerPlayerSign");
            }
            if (g.buttonSouth.isPressed)
            {
                Application.Quit();
            }
            //if (g.buttonWest.isPressed)
            //{
            //    if (IsPressing[i])return;
            //    IsPressing[i] = true;
            //    if (InstructionOpened == false)
            //    {
            //        InstructionOpened = true;
            //        DOTween.To(()=> { return InstructionPIC.rectTransform.anchoredPosition; },x=> { InstructionPIC.rectTransform.anchoredPosition = x; },new Vector2(0,540),0.5f);
            //    }
            //    else
            //    {
            //        InstructionOpened = false;
            //        DOTween.To(() => { return InstructionPIC.rectTransform.anchoredPosition; }, x => { InstructionPIC.rectTransform.anchoredPosition = x; }, StartPoint, 0.5f);
            //    }
            //}
        }
    }
}
