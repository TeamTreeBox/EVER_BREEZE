using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        FirstSpring.SetActive(false);
        SecondSpring.SetActive(false);
        ThirdSpring.SetActive(false);

        FirstWinter.SetActive(true);
        SecondWinter.SetActive(true);
        ThirdWinter.SetActive(true);

    }
    public GameObject FirstSpring;
    public GameObject SecondSpring;
    public GameObject ThirdSpring;

    public GameObject FirstWinter;
    public GameObject SecondWinter;
    public GameObject ThirdWinter;

    //test
    public bool isQuest_1_Clear = false;
    public bool isQuest_2_Clear = false;
    public bool isQuest_3_Clear = false;

    void Awake()
    {
     
    }

   

    // Update is called once per frame
    private void Update()
    {
        if(isQuest_1_Clear == true && isQuest_2_Clear == false && isQuest_3_Clear == false)
        {
            StartCoroutine(FirstChangeSpring());
        }
        else if(isQuest_1_Clear == false && isQuest_2_Clear == true && isQuest_3_Clear == false)
        {
            StartCoroutine(SecondChangeSpring());
        }
        else if(isQuest_1_Clear == false && isQuest_2_Clear == false && isQuest_3_Clear == true)
        {
            StartCoroutine(ThirdChangeSpring());
        }
        else if(isQuest_1_Clear == false && isQuest_2_Clear == true && isQuest_3_Clear == true)
        {
            StartCoroutine(FirstChangeWinter());
        }
        else if( isQuest_1_Clear == true && isQuest_2_Clear == false && isQuest_3_Clear == true)
        {
            StartCoroutine(SecondChangeWinter());
        }
        else if(isQuest_1_Clear == true && isQuest_2_Clear == true && isQuest_3_Clear == false)
        {
            StartCoroutine(ThirdChangeWinter());
        }
    }

    IEnumerator FirstChangeSpring()
    {
        FirstWinter.SetActive(false);
        FirstSpring.SetActive(true);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator SecondChangeSpring()
    {
        SecondWinter.SetActive(false);
        SecondSpring.SetActive(true);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator ThirdChangeSpring()
    {
        ThirdWinter.SetActive(false);
        ThirdSpring.SetActive(true);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator FirstChangeWinter()
    {
        FirstSpring.SetActive(false);
        FirstWinter.SetActive(true);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator SecondChangeWinter()
    {
        SecondSpring.SetActive(false);
        SecondWinter.SetActive(true);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator ThirdChangeWinter()
    {
        ThirdSpring.SetActive(false);
        ThirdWinter.SetActive(true);
        yield return new WaitForEndOfFrame();
    }
}
