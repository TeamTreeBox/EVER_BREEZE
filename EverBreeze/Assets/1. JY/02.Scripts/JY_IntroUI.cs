using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JY_IntroUI : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject optionUI;
    public GameObject SystemMgr;

    AsyncOperation op;
    float time;

    bool goNextScene = false;

    private void Start()
    {
        menuUI.SetActive(true);
        optionUI.SetActive(false);

    }

    //종료버튼
    public void OnClickQuit()
    {
        print("OnClickQuit");
        Application.Quit();
    }

    //시작버튼
    public void OnClickNewGame()
    {
        print("OnClickNewGame");
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    //옵션 버튼
    public void OnClickOption()
    {
        print("OnClickOption");
        menuUI.SetActive(false);
        optionUI.SetActive(true);
    }

    //옵션 버튼
    public void OnClickMenu()
    {
        print("OnClickMenu");
        menuUI.SetActive(true);
        optionUI.SetActive(false);
    }

    //타이틀버튼
    public void OnClickTitle()
    {
        print("OnClickQuit");
        SceneManager.LoadScene(0);
    }
}
