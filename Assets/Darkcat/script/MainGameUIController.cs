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
    public Image LeaderMark;
    public GameObject InformationBoard;
    public Animator Ending;
    public Image ChosenOne;

    public float SampleTime;
    public Image TimerFill;
    public TextMeshProUGUI TimerTxt;

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
    public void ChangeLeaderMark(int NextPlayer)
    {
        LeaderMark.transform.DOMove(new Vector3(450f+NextPlayer*470f, 163f, 0), 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        TimerFill.fillAmount = SampleTime/20f;
        TimerTxt.text = Mathf.RoundToInt(SampleTime).ToString();
        foreach (var display in Displays)
        {
            display.PlayerPointDisplay.text = display.ThisPlayerData.PlayerPoint.ToString();
            display.PlayerStepLeft.text = display.ThisPlayerData.PlayerMovePoint.ToString();
        }
        for (int i = 0; i < 4; i++)
        {
            if (MainData.players[i].playerData.PlayerMovePoint<=0)
            {
                Displays[i].PlayerUIObject.GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
            }            
        }
    }
    public void SureFeedBack(int MYPlayer)
    {
        Displays[MYPlayer].PlayerUIObject.transform.DOPunchScale(Vector3.one*0.2f,0.35f,15).OnComplete(()=>{ Displays[MYPlayer].PlayerUIObject.transform.DOScale(Displays[MYPlayer].oripos, 0.2f);   });
    }
    public void ChosenOneIsYou(Player player)
    {
        ChosenOne.transform.position = ChosenOne.transform.position + new Vector3(470f, 0, 0) * (int)player;
    }
    public void CallEnding()
    {
        Ending.enabled = true;
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
