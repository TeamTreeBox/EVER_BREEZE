using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SBManager : MonoBehaviour
{
    public Sprite[] SB;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FOXTEST");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator FOXTEST()
    {
        Image SBBox = this.GetComponent<Image>();
        for (int i = 0; i < SB.Length; i++)
        {
            SBBox.sprite = SB[i];
            yield return new WaitForSeconds(3);
        }
    }
}
