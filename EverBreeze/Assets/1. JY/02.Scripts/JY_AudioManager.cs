using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_AudioManager : MonoBehaviour
{
    public static JY_AudioManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    public int debug_Audio = 0;

    void Start()
    {
    }

    //����� ��ư Ŭ��
    public void Debug_Audio()
    {
        debug_Audio++;
    }
}
