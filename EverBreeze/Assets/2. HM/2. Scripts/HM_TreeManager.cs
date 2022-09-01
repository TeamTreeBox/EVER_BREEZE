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

    public GameObject particle;
    int a = 0;

    public void QuestEventTrigger(int num)
    {
        StartCoroutine(ChangeTreesMat(num));
    }

    IEnumerator ChangeTreesMat(int level)
    {
        particle.SetActive(true);
        yield return new WaitForSeconds(3f);
        trees[level].SetActive(true);

        #region 마지막 트리가 SetActive(false)가 되기 위함

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
        particle.SetActive(false);
    }

}
