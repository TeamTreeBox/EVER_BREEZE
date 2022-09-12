using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_FoxSpoke_Renewal : MonoBehaviour
{
   public static HM_FoxSpoke_Renewal instance;
   
    SpriteRenderer fox_spriterender;

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
    public int save_num = 0;
    public int debug_Num = 0;
    public bool is_UI_Open = false;
    public bool debug_buttonTest = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
