using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class simpleSceneChange : MonoBehaviour
{
    public void IntoMainGame()
    {
        SceneManager.LoadScene("NewGridTest");
    }
    public void DonDonSFX()
    {
        AudioController.Instance.SpawnSFX(SFXType.StartGame);
    }
}
