using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_FoxSpoke_Renewal : MonoBehaviour
{
   public static HM_FoxSpoke_Renewal instance;
   
    SpriteRenderer fox_spriterender;

    [Header("�ؽ�Ʈ �Ѿ�� �ӵ�")]
    public float txt_Speed = 3f;

    //================����Ʈ VFX========================//

    [Header("Quest VFX")]
    public GameObject Trigger_Vfx;

    //==================================================//
    //==============��ȭUI â ������Ʈ===================//

    public GameObject fox_Talk_UI;

    //=================================================//
    //================��ȭ ��������Ʈ===================//

    [Header("��ȭ ��������Ʈ �迭")]
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
