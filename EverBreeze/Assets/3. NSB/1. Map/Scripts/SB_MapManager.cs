using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_MapManager : MonoBehaviour
{
    public static SB_MapManager instance;

    public GameObject FirstSpring;
    public GameObject SecondSpring;
    public GameObject ThirdSpring;

    public GameObject FirstWinter;
    public GameObject SecondWinter;
    public GameObject ThirdWinter;

    bool test_1 = false;
    bool test_2 = false;
    bool test_3 = false;
    int a = 0;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        FirstSpring.SetActive(false);
        SecondSpring.SetActive(false);
        ThirdSpring.SetActive(false);

        FirstWinter.SetActive(true);
        SecondWinter.SetActive(true);
        ThirdWinter.SetActive(true);
    }


    private void Update()
    {
        #if UNITY_EDITOR

        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            a += 1;
            print(a);
            if (a == 1 && test_1 == false)
            {
                FirstWinter.SetActive(false);
                FirstSpring.SetActive(true);
            }
            else if (a == 2 && test_2 == false)
            {
                test_2 = true;
                SecondChange_Spring();
            }
            else if(a == 3 && test_3 == false)
            {
                test_3 = true;
                ThirdChange_Spring();
            }
        }
        #endif
    }

    public void FirstChange_Spring()
    {
        StartCoroutine(FirstChangeSpring());
    }

    public void SecondChange_Spring()
    {
        StartCoroutine(SecondChangeSpring());
    }

    public void ThirdChange_Spring()
    {
        StartCoroutine(ThirdChangeSpring());
    }



    IEnumerator FirstChangeSpring()
    {
        FirstWinter.SetActive(false);
        FirstSpring.SetActive(true);
        print("Change");
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

}
