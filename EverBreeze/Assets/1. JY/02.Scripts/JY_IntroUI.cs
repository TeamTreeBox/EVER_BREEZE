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

    //�����ư
    public void OnClickQuit()
    {
        print("OnClickQuit");
        Application.Quit();
    }

    //���۹�ư
    public void OnClickNewGame()
    {
        print("OnClickNewGame");
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    //�ɼ� ��ư
    public void OnClickOption()
    {
        print("OnClickOption");
        menuUI.SetActive(false);
        optionUI.SetActive(true);
    }

    //�ɼ� ��ư
    public void OnClickMenu()
    {
        print("OnClickMenu");
        menuUI.SetActive(true);
        optionUI.SetActive(false);
    }

    //Ÿ��Ʋ��ư
    public void OnClickTitle()
    {
        print("OnClickQuit");
        SceneManager.LoadScene(0);
    }
}
