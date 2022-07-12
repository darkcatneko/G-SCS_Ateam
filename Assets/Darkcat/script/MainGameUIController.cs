using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MainGameUIController : MonoBehaviour
{
    public static MainGameUIController instance;
    public GameController MainData;
    public PlayerUI[] Displays = new PlayerUI[4];    

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach (var player in Displays)
        {
            player.setOri();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var display in Displays)
        {
            display.PlayerPointDisplay.text = display.ThisPlayerData.PlayerPoint.ToString();
            display.PlayerStepLeft.text = display.ThisPlayerData.PlayerMovePoint.ToString();
        }
    }
    public void SureFeedBack(int MYPlayer)
    {
        Displays[MYPlayer].PlayerUIObject.transform.DOPunchScale(Vector3.one*0.2f,0.35f,15).OnComplete(()=>{ Displays[MYPlayer].PlayerUIObject.transform.DOScale(Displays[MYPlayer].oripos, 0.2f);   });
    }
}
[System.Serializable]
public class PlayerUI
{
    public GameObject PlayerUIOutLine;
    public GameObject PlayerUIObject;
    public TextMeshProUGUI PlayerPointDisplay;
    public TextMeshProUGUI PlayerStepLeft;
    public Animator PlayerAnimate;
    public PlayerDataSo ThisPlayerData;
    public Vector3 oripos;
    public void setOri()
    {
        oripos = PlayerUIObject.transform.localScale;
    }
    
}
