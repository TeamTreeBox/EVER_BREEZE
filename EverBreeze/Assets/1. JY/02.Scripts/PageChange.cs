using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChange : MonoBehaviour
{
    public GameObject page01_1;
    public GameObject page01_2;

    public GameObject page02_1;
    public GameObject page02_2;
    public GameObject page02_3;

    public GameObject page03_1;
    public GameObject page03_2;
    public GameObject page03_3;

    public GameObject page04_1;
    public GameObject page04_2;
    public GameObject page04_3;

    public GameObject back_01;
    public GameObject back_02;

    bool isPage01;

    bool isPage02_1;
    bool isPage02_2;

    bool isPage03_1;
    bool isPage03_2;

    bool isPage04_1;
    bool isPage04_2;

    bool isBack_01;
    bool isBack_02;

    void Start()
    {
        page01_1.SetActive(true);
        page01_2.SetActive(false);

        page02_1.SetActive(true);
        page02_2.SetActive(false);
        page02_3.SetActive(false);

        page03_1.SetActive(true);
        page03_2.SetActive(false);
        page03_3.SetActive(false);

        page04_1.SetActive(true);
        page04_2.SetActive(false);
        page04_3.SetActive(false);

        back_01.SetActive(true);
        back_02.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (PageManager.instance.debug_StageClear == 1 && isPage01 == false)
        {
            print("&&변경&&");
            page01_1.SetActive(false);
            page01_2.SetActive(true);

            isPage01 = true;
        }

        if (PageManager.instance.debug_StageClear == 2 && isPage02_1 == false && isPage02_2 == false)
        {
            print("&&변경&&");
            page02_1.SetActive(false);
            page02_2.SetActive(true);

            isPage02_1 = true;
        }

        if (PageManager.instance.debug_StageClear == 3 && isPage02_1 == true && isPage02_2 == false)
        {
            print("&&변경&&");
            page02_2.SetActive(false);
            page02_3.SetActive(true);
        }

        if (PageManager.instance.debug_StageClear == 4 && isPage03_1 == false && isPage03_2 == false)
        {
            print("&&변경&&");
            page03_1.SetActive(false);
            page03_2.SetActive(true);

            isPage03_1 = true;
        }

        if (PageManager.instance.debug_StageClear == 5 && isPage03_1 == true && isPage03_2 == false)
        {
            print("&&변경&&");
            page03_2.SetActive(false);
            page03_3.SetActive(true);

            isPage03_2 = true;
        }

        if (PageManager.instance.debug_StageClear == 6 && isPage04_1 == false && isPage04_2 == false)
        {
            print("&&변경&&");
            page04_1.SetActive(false);
            page04_2.SetActive(true);

            isPage04_1 = true;
        }

        if (PageManager.instance.debug_StageClear == 7 && isPage04_1 == true && isPage04_2 == false)
        {
            print("&&변경&&");
            page04_2.SetActive(false);
            page04_3.SetActive(true);

            isPage04_2 = true;
        }

        if (PageManager.instance.debug_StageClear == 7 && isBack_01 == false)
        {
            print("&&변경&&");
            back_01.SetActive(false);
            back_02.SetActive(true);

            isBack_01 = true;
        }
    }
}
