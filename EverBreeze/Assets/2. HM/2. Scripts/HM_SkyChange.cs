using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_SkyChange : MonoBehaviour
{
    public GameObject skyChange;
    float blend;

    public Material[] skyBoxMat;
    public int i = 0;

   // Start is called before the first frame update
   void Start()
    {
        StartCoroutine(ChangeUpSkyBox());   
    }

    // Update is called once per frame
    void Update()
    {
        blend = skyChange.GetComponent<SkyboxBlender>().blend;
    }

    IEnumerator ChangeUpSkyBox()
    {
        if(blend < 0.95f)
        {
            while (blend < 1)
            {
                skyChange.GetComponent<SkyboxBlender>().blend += 0.05f;
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeSkyBoxMat());
        StartCoroutine(ChangeDownSkyBox());
    }

    IEnumerator ChangeDownSkyBox()
    {
        if (blend >= 0.95)
        {
            while (blend >= 0)
            {
                skyChange.GetComponent<SkyboxBlender>().blend -= 0.05f;
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeUpSkyBox());
    }

    IEnumerator ChangeSkyBoxMat()
    {
        i += 1;

        if(i < skyBoxMat.Length)
        {
            skyChange.GetComponent<SkyboxBlender>().skyBox2 = skyBoxMat[i];
        }
        else
        {
            i = 0;
        }

        yield return new WaitForEndOfFrame();
    }
}
