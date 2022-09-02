using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChange : MonoBehaviour
{
    //Page0304 
    public GameObject page01;
    public GameObject page02;
    bool isPage01 = true;

    //Page0506
    public GameObject page03; //null page
    public GameObject page04;
    public GameObject page05;
    bool isPage03 = true;
    bool isPage04 = false;

    //Page0708
    public GameObject page06; //null page
    public GameObject page07;
    public GameObject page08;
    bool isPage06 = true;
    bool isPage07 = false;

    //Page0910
    public GameObject page09; //null page
    public GameObject page10;
    public GameObject page11; //Ending page
    bool isPage09 = true;
    bool isPage10 = false;

    //Back
    public GameObject page12; //null page
    public GameObject page13; //Ending page

    void Start()
    {
        //Page0304 
        page01.SetActive(true);
        page02.SetActive(false);

        //Page0506
        page03.SetActive(true);
        page04.SetActive(false);
        page05.SetActive(false);

        //Page0708
        page06.SetActive(true);
        page07.SetActive(false);
        page08.SetActive(false);

        //Page0910
        page09.SetActive(true);
        page10.SetActive(false);
        page11.SetActive(false);

        //Back
        page12.SetActive(true);
        page13.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Page0304 
        if (PageManager.instance.debug_StageClear == 1 && isPage01 == true)
        {
            page01.SetActive(false);
            page02.SetActive(true);
            isPage01 = false;
        }

        //Page0506
        if (PageManager.instance.debug_StageClear == 2 && isPage03 == true && isPage04 == false)
        {
            page03.SetActive(false);
            page04.SetActive(true);
            isPage03 = false;
            isPage04 = true;
        }
        if (PageManager.instance.debug_StageClear == 3 && isPage03 == false && isPage04 == true)
        {
            page04.SetActive(false);
            page05.SetActive(true);
            isPage04 = false;
        }

        //Page0708
        if (PageManager.instance.debug_StageClear == 4 && isPage06 == true && isPage07 == false)
        {
            page06.SetActive(false);
            page07.SetActive(true);
            isPage06 = false;
            isPage07 = true;
        }
        if (PageManager.instance.debug_StageClear == 5 && isPage06 == false && isPage07 == true)
        {
            page07.SetActive(false);
            page08.SetActive(true);
            isPage07 = false;
        }

        //Page0910
        if (PageManager.instance.debug_StageClear == 6 && isPage09 == true && isPage10 == false)
        {
            page09.SetActive(false);
            page10.SetActive(true);
            isPage09 = false;
            isPage10 = true;
        }
        //Ending page
        if (PageManager.instance.debug_StageClear == 7 && isPage09 == false && isPage10 == true)
        {
            page10.SetActive(false);
            page11.SetActive(true);

            page12.SetActive(false);
            page13.SetActive(true);
            isPage10 = false;
        }
    }
}
