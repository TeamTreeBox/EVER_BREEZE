using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_TreeManager : MonoBehaviour
{
    public static HM_TreeManager instance;

     void Awake()
    {
        instance = this;
    }

    public int[] levels = { 0, 1, 2, 3 };
    public GameObject[] trees; 

    public GameObject particle_1;
    public GameObject particle_2;
    int a = 0;

    public void QuestEventTrigger(int num)
    {
        StartCoroutine(ChangeTreesMat(num));
    }

    IEnumerator ChangeTreesMat(int level)
    {
        particle_1.SetActive(true);
        particle_2.SetActive(true);
        yield return new WaitForSeconds(3f);
        trees[level].SetActive(true);

        #region ������ Ʈ���� SetActive(false)�� �Ǳ� ����

        if (level != 0)
        {
            trees[level - 1].SetActive(false);
        }
        else
        {
            trees[3].SetActive(false);
        }
        #endregion

        yield return new WaitForSeconds(3f);
        particle_1.SetActive(false);
        particle_2.SetActive(false);
    }

}
