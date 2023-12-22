using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{

    private void Start()
    {
        Invoke("ShowAd", 2.5f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Exitbtn()
    {
        SceneManager.LoadScene(0);
    }

    private void ShowAd()
    {
        AdsController.VideoAd();
    }
}
