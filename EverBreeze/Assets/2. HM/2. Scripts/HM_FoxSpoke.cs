using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class HM_FoxSpoke : MonoBehaviour
{
    public static HM_FoxSpoke instacne;

    private void Awake()
    {
        instacne = this;
    }

    Animator foxAnim;
    NavMeshAgent foxAi;
    int ranBehavior = 0;

    public float txt_Speed = 3f;

    public GameObject fox_Talk_UI;
    SpriteRenderer fox_spriterender;

    public Sprite[] fox_Talk_1;
    public Sprite[] fox_Talk_2;
    public Sprite[] fox_Talk_3;
    public Sprite[] fox_Talk_4;
    public Sprite[] fox_Talk_5;
    public Sprite[] fox_Talk_6;
    public Sprite[] fox_Talk_7;
    public Sprite[] fox_Talk_8;

    public int save_num = 0;

    public int debug_Num = 0;

    public bool is_UI_Open = false;
    public bool debug_buttonTest = false;
    // Start is called before the first frame update
    void Start()
    {
        fox_spriterender = fox_Talk_UI.GetComponent<SpriteRenderer>();
        foxAnim = this.GetComponent<Animator>();
        foxAi = this.GetComponent<NavMeshAgent>();
        fox_Talk_UI.SetActive(false);

        StartCoroutine(FoxAnim());
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    IEnumerator FoxAnim()
    {
        if (foxAi.isStopped == false)
        {
            foxAnim.SetBool("IsWalking", false);
            ranBehavior = Random.Range(1, 4);

            switch (ranBehavior)
            {
                case 1:
                    foxAnim.SetTrigger("Idle_1");
                    break;

                case 2:
                    foxAnim.SetTrigger("Idle_2");
                    break;

                case 3:
                    foxAnim.SetTrigger("Idle_3");
                    break;
            }
        }
        else
        {
            foxAnim.SetBool("IsWalking", true);
        }

        yield return new WaitForSeconds(8f);
        StartCoroutine(FoxAnim());
    }

    IEnumerator OnQuestComplete()
    {
        //StopCoroutine(FoxAnim());

        //print("stopCoroutine");

        //yield return new WaitForSeconds(.5f);



        foxAnim.SetTrigger("QuestComplete");

        print("settrigger");

        yield return new WaitForSeconds(2f);

        StartCoroutine(FoxAnim());
    }

    public void SelectNum_Talk(int num)
    {
        switch (num)
        {
            case 0:
                StartCoroutine(Fox_Talk_1());
                break;

            case 1:
                StartCoroutine(Fox_Talk_2());
                break;

            case 2:
                StartCoroutine(Fox_Talk_3());
                break;

            case 3:
                StartCoroutine(Fox_Talk_4());
                break;

            case 4:
                StartCoroutine(Fox_Talk_5());
                break;

            case 5:
                StartCoroutine(Fox_Talk_6());
                break;

            case 6:
                StartCoroutine(Fox_Talk_7());
                break;

            case 7:
                StartCoroutine(Fox_Talk_8());
                break;

        }
    }

    IEnumerator Fox_Talk_1()
    {
        yield return new WaitForSeconds(3f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_1.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_1[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

    }

    IEnumerator Fox_Talk_2()
    {
        StartCoroutine(OnQuestComplete());

        //yield return new WaitForSeconds(5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_2.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_2[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;



    }

    IEnumerator Fox_Talk_3()
    {
        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_3.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_3[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        yield return new WaitForSeconds(1f);

        StartCoroutine(Fox_Talk_4());
    }

    IEnumerator Fox_Talk_4()
    {
        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_4.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_4[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;


    }

    IEnumerator Fox_Talk_5()
    {
        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_5.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_5[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;
    }

    IEnumerator Fox_Talk_6()
    {
        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_6.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_6[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        yield return new WaitForSeconds(1f);

        StartCoroutine(Fox_Talk_7());
    }

    IEnumerator Fox_Talk_7()
    {
        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_7.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_7[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;
    }

    IEnumerator Fox_Talk_8()
    {
        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_8.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_8[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;
    }
}
