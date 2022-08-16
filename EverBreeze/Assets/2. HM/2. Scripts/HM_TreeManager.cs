using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_TreeManager : MonoBehaviour
{
    public HM_TreeManager instance;

    private void Awake()
    {
        instance = this;
    }
    public int[] levels = { 0, 1, 2, 3 };
    public GameObject[] trees;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTreeState(int level)
    {
        if(level >= 0 && level <= 3)  // ������ �� 4���̱⿡ 0,1,2,3 
        {
            for (int i = 0; i <= trees.Length; i++) 
            {
                if (i == level)
                {
                    trees[i].SetActive(true);   // ������ �´� ���� Ȱ��ȭ
                }
                else
                {
                    trees[i].SetActive(false); // ������ ������ ��Ȱ��ȭ
                }
            }
        }
    }
}
