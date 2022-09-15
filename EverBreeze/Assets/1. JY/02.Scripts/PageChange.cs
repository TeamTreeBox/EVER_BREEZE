using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChange : MonoBehaviour
{
    //Page0304 
    public GameObject page01;
    public GameObject page02;

    //Page0506
    public GameObject page03; //null page
    public GameObject page04;
    public GameObject page05;

    //Page0708
    public GameObject page06; //null page
    public GameObject page07;
    public GameObject page08;

    //Page0910
    public GameObject page09; //null page
    public GameObject page10;
    public GameObject page11; //Ending page

    //Page0910
    public GameObject page12; //null page
    public GameObject page13; //Ending page


    void Start()
    {
        //Page0506
        page01.SetActive(true);
        page02.SetActive(false);

        //Page0708
        page03.SetActive(true);
        page04.SetActive(false);
        page05.SetActive(false);

        //Page0910
        page06.SetActive(true);
        page07.SetActive(false);
        page08.SetActive(false);

        //Page1112
        page09.SetActive(true);
        page10.SetActive(false);
        page11.SetActive(false);

        //Page1314
        page12.SetActive(true);
        page13.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Page0506
        if (PageManager.instance.debug_StageClear == 1)
        {   // => 퀘스트 1 시작할때
            page01.SetActive(false);
            page02.SetActive(true);
        }

        //Page0708
        if (PageManager.instance.debug_StageClear == 2)
        {   // => 퀘스트 1 끝났을 때
            page01.SetActive(false);
            page03.SetActive(false);//null page
            page04.SetActive(true);
        }
        if (PageManager.instance.debug_StageClear == 3)
        {   // => 퀘스트 2 시작할 때
            page01.SetActive(false);
            page03.SetActive(false);//null page
            page04.SetActive(false);
            page05.SetActive(true);
        }

        //Page0910
        if (PageManager.instance.debug_StageClear == 4)
        {   // => 퀘스트 2 끝날 때
            page01.SetActive(false);
            page03.SetActive(false);//null page
            page04.SetActive(false);
            page06.SetActive(false);//null page
            page07.SetActive(true);
        }
        if (PageManager.instance.debug_StageClear == 5)
        {   // => 퀘스트 3 시작할 때
            page01.SetActive(false);
            page03.SetActive(false);//null page
            page04.SetActive(false);
            page06.SetActive(false);//null page
            page07.SetActive(false);
            page08.SetActive(true);
        }

        //Page1112
        if (PageManager.instance.debug_StageClear == 6)
        {   // => 퀘스트 3 끝날 때
            page01.SetActive(false);
            page03.SetActive(false);//null page
            page04.SetActive(false);
            page06.SetActive(false);//null page
            page07.SetActive(false);
            page09.SetActive(false);//null page
            page10.SetActive(true);
        }
        //Ending page
        if (PageManager.instance.debug_StageClear == 7)
        {   // 엔딩
            page01.SetActive(false);
            page03.SetActive(false);//null page
            page04.SetActive(false);
            page06.SetActive(false);//null page
            page07.SetActive(false);
            page09.SetActive(false);//null page
            page10.SetActive(false);
            page11.SetActive(true);//Ending page

            page12.SetActive(false);//null page
            page13.SetActive(true);//Ending page
        }
    }
}
