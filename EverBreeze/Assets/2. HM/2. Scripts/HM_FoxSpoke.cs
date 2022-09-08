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

    //=========Äù½ºÆ® VFX===============================//

    [Header("Quest VFX")]
    public GameObject Trigger_Vfx;

    // Start is called before the first frame update
    void Start()
    {
        fox_spriterender = fox_Talk_UI.GetComponent<SpriteRenderer>();
        foxAnim = this.GetComponent<Animator>();
        foxAi = this.GetComponent<NavMeshAgent>();
        fox_Talk_UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

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

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 1;

        yield return new WaitForSeconds(2f);

        StartCoroutine(Fox_Talk_2());

    }

    IEnumerator Fox_Talk_2()
    {
        //yield return new WaitForSeconds(5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_2.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_2[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 2;

        yield return new WaitForSeconds(2f);

        Trigger_Vfx.SetActive(true);
    }

    IEnumerator Fox_Talk_3()
    {
        Trigger_Vfx.SetActive(false);

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
        PageManager.instance.debug_StageClear = 3;

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

        HM_ItemSpawner.instance.SpwanJemStone();

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 4;

        yield return new WaitForSeconds(2f);

        Trigger_Vfx.SetActive(true);
    }

    IEnumerator Fox_Talk_5()
    {
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
        PageManager.instance.debug_StageClear = 5;

        yield return new WaitForSeconds(2f);

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

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 6;

        yield return new WaitForSeconds(2f);

        Trigger_Vfx.SetActive(true);

    }

    IEnumerator Fox_Talk_8()
    {
        Trigger_Vfx.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        fox_Talk_UI.SetActive(true);

        for (int i = 0; i < fox_Talk_8.Length; i++)
        {
            fox_spriterender.sprite = fox_Talk_8[i];

            yield return new WaitForSeconds(txt_Speed);
        }

        fox_Talk_UI.SetActive(false);

        is_UI_Open = false;

        HM_QuestManager.instance.BookIconPopUP();
        PageManager.instance.debug_StageClear = 7;

        yield return new WaitForSeconds(2f);
    }
}
