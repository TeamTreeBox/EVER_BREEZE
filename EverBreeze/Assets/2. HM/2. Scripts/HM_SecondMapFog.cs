using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_SecondMapFog : MonoBehaviour
{
    public GameObject Fog;

    //Material fogmat;

    bool isEnterSecondMap = false;

    MeshRenderer fogmat;

    private void Start()
    {
        fogmat = Fog.GetComponent<MeshRenderer>();
 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isEnterSecondMap == false)
        {
            print("¾È°³ÄÑÁü");
            Fog.SetActive(true);
            StartCoroutine(FogFadeIn());
        }
        else if (other.tag == "Player" && isEnterSecondMap == true)
        {
            print("¾È°³²¨Áü");
            StartCoroutine(FogFadeOut());
            Fog.SetActive(false);
        }
    }

    IEnumerator FogFadeIn()
    {
        for(float a = 0; a <= 1; a += 0.05f)
        {
            fogmat.material.SetFloat("_FogIntensity", a);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(10f);
        isEnterSecondMap = true;

    }

    IEnumerator FogFadeOut()
    {
        for (float a = 1; a >= 0; a -= 0.01f)
        {
            fogmat.material.SetFloat("Fog Intensity", a);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(10f);
        isEnterSecondMap = false;
    }
}
