using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class HM_FoxSpoke : MonoBehaviour
{
    public static HM_FoxSpoke instacne;

    Animator foxAnim;
    NavMeshAgent foxAi;
    SpriteRenderer fox_spriterender;

    int ranBehavior = 0;
    [Header("텍스트 넘어가는 속도")]
    public float txt_Speed = 3f;

    //================퀘스트 VFX========================//

    [Header("Quest VFX")]
    public GameObject Trigger_Vfx;

    //==================================================//
    //==============대화UI 창 오브젝트===================//

    public GameObject fox_Talk_UI;

    //=================================================//
    //================대화 스프라이트===================//

    [Header("대화 스프라이트 배열")]
    public Sprite[] fox_Talk_1;
    public Sprite[] fox_Talk_2;
    public Sprite[] fox_Talk_3;
    public Sprite[] fox_Talk_4;
    public Sprite[] fox_Talk_5;
    public Sprite[] fox_Talk_6;
    public Sprite[] fox_Talk_7;
    public Sprite[] fox_Talk_8;

    //=================================================//
    //================추가 대화 스프라이트===================//

    [Header("추가 대화 스프라이트 배열")]
    public Sprite[] fox_Talk_1_2;
    public Sprite[] fox_Talk_6_2;
    //=================================================//


    public int save_num = 0;
    public int debug_Num = 0;
    public bool is_UI_Open = false;
    public bool debug_buttonTest = false;


    private void Awake()
    {
        instacne = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fox_spriterender = fox_Talk_UI.GetComponent<SpriteRenderer>();
        foxAnim = this.GetComponent<Animator>();
        foxAi = this.GetComponent<NavMeshAgent>();
        fox_Talk_UI.SetActive(false);
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
        //봄을 되찾는 거 도와 줄 거죠? - TUTORIAL
        Trigger_Vfx.SetActive(false);

        yield return new WaitForSeconds(3f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_1.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_1[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

       

        yield return new WaitForSeconds(2f);

        StartCoroutine(Fox_Talk_2());

    }

    IEnumerator Fox_Talk_2()
    {
        //샘의 물 - Quest01 Start
        //yield return new WaitForSeconds(5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_2.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_2[i];

            yield return new WaitForSeconds(txt_Speed);
        }
        JY_AudioManager.instance.debug_Audio = 1;
        JY_AudioManager.instance.debug_BGM = 1; 
        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 1;

        yield return new WaitForSeconds(2f);

        Trigger_Vfx.SetActive(true);
    }

    IEnumerator Fox_Talk_3()
    {
        //나무에게서 조금 생기가 느껴져 - Qust01 Clear
        Trigger_Vfx.SetActive(false);
        JY_Audio.instance.Audio_Tree01();

        yield return new WaitForSeconds(1f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_3.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_3[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        yield return new WaitForSeconds(1f);

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 2;

        StartCoroutine(Fox_Talk_4());
    }

    IEnumerator Fox_Talk_4()
    {
        //나뭇가지 챙겨서 숲으로 - Quest02 Start
        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_4.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_4[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        JY_AudioManager.instance.debug_BGM = 2;
        JY_AudioManager.instance.debug_Audio = 3;
        JY_AudioManager.instance.debug_Audio = 4;

        HM_ItemSpawner.instance.SpwanJemStone();

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 3;

        yield return new WaitForSeconds(2f);

        Trigger_Vfx.SetActive(true);
    }

    IEnumerator Fox_Talk_5()
    {
        //이 종을 받아주세요 - Quest02 Bell
        Trigger_Vfx.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_5.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_5[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        HM_ItemSpawner.instance.SpwanJingleBell();

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;
    }

    IEnumerator Fox_Talk_6()
    {
        JY_Audio.instance.Audio_Tree02();
        //이제 곧 완전한 봄 - Quest02 Clear
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

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 4;

        yield return new WaitForSeconds(2f);

        StartCoroutine(Fox_Talk_7());
    }

    IEnumerator Fox_Talk_7()
    {
        //고대의 나비 - Quest03 Start
        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_7.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_7[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        //오디오
        JY_AudioManager.instance.debug_BGM = 3;
        JY_AudioManager.instance.debug_Audio = 5;

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;


        HM_ItemSpawner.instance.SpwanBottle();
        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 5;

        yield return new WaitForSeconds(2f);

        Trigger_Vfx.SetActive(true);

    }

    IEnumerator Fox_Talk_8()
    {
        JY_Audio.instance.Audio_Tree03();

        //더이상 겨울은 없을 거예요 - Ending
        Trigger_Vfx.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);


        for (int i = 0; i < fox_Talk_8.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_8[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        JY_AudioManager.instance.debug_BGM = 4;
        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 6;

        yield return new WaitForSeconds(10f);

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 7;
    }


    //======추가 대화==========//

    public void Fox_Talk_1_2_Func()
    {
        StartCoroutine(Fox_Talk_1_2());
    }
    public void Fox_Talk_6_2_Func()
    {
        StartCoroutine(Fox_Talk_6_2());
    }

    IEnumerator Fox_Talk_1_2()
    {
        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_1_2.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_1_2[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        yield return new WaitForSeconds(1f);
    }

    IEnumerator Fox_Talk_6_2()
    {
        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_6_2.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_6_2[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        yield return new WaitForSeconds(1f);
    }
}
