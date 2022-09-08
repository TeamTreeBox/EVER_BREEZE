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


    public GameObject MainGrass;
    public GameObject MainFlower;
    public GameObject MainSpringTree;
    public GameObject MainWinterTree;

    public GameObject MainSpringPlant;
    public GameObject MainWinterPlant;

    public GameObject MainCenterSpringGround;
    public GameObject MainSpringGround;
    public GameObject MainCenterWinterGround;
    public GameObject MainWinterGround;

    public GameObject MainColorTree;
    public GameObject MainDeadTree;

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
                FirstChange_Spring();
                FirstChange_Main();
            }
            else if (a == 2 && test_2 == false)
            {
                SecondChange_Spring();
                SecondChange_Main();
            }
            else if(a == 3 && test_3 == false)
            {
                ThirdChange_Spring();
                ThirdChange_Main();
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

    public void FirstChange_Main()
    {
        StartCoroutine(MainFirstChange());
    }

    public void SecondChange_Main()
    {
        StartCoroutine(MainSecondChange());
    }


    public void ThirdChange_Main()
    {
        StartCoroutine(MainThirdChange());
    }



    IEnumerator FirstChangeSpring()
    {
        FirstSpring.SetActive(true);
        FirstWinter.SetActive(false);
        print("Change");
        yield return new WaitForEndOfFrame();
    }
    IEnumerator SecondChangeSpring()
    {
        SecondSpring.SetActive(true);
        SecondWinter.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
    IEnumerator ThirdChangeSpring()
    {
        ThirdSpring.SetActive(true);
        ThirdWinter.SetActive(false);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator MainFirstChange()

    {
        MainColorTree.SetActive(true);
        MainSpringPlant.SetActive(true);
        MainSpringGround.SetActive(true);

        MainDeadTree.SetActive(false);
        MainWinterPlant.SetActive(false);
        MainWinterGround.SetActive(false);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator MainSecondChange()

    {
        MainFlower.SetActive(true);
        MainCenterSpringGround.SetActive(true);
        MainSpringTree.SetActive(true);

        MainCenterWinterGround.SetActive(false);
        MainWinterTree.SetActive(false);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator MainThirdChange()

    {
        MainGrass.SetActive(true);
        yield return new WaitForEndOfFrame();
    }
}
