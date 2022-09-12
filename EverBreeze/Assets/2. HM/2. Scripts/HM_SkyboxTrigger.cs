using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_SkyboxTrigger : MonoBehaviour
{
    public Material skyBox;
    public GameObject cam;
    public Light DirectLight;
    public float SkyChangeSpeed;
    public bool isEnter = false;

    private void Start()
    {
        cam.AddComponent<Skybox>().material = skyBox;

        skyBox.shader = Shader.Find("Skybox/VertBlendedSkybox");

        StartCoroutine(RoateSkyBox());
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            if(isEnter == false)
            {
                print("스카이박스_Night");
                StartCoroutine(ChangeSkyBoxNight());
                DirectLight.intensity = 0.5f;
            }
        }
    }

    IEnumerator ChangeSkyBoxNight()
    {
        for(float a = 0; a <= 1; a += SkyChangeSpeed)
        {
            isEnter = true;
            skyBox.SetFloat("_Blend", a);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator ChangeSkyBoxDay()
    {
        for (float a = 1; a >= 0; a -= SkyChangeSpeed)
        {
            isEnter = false;
            skyBox.SetFloat("_Blend", a);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void ChangeSkyDay()
    {
        StartCoroutine(ChangeSkyBoxDay());
    }

    IEnumerator RoateSkyBox()
    {
        for(float i = 0; i <= 360; i += 0.1f)
        {
            skyBox.SetFloat("_Rotation", i);
            yield return new WaitForSeconds(0.5f);

            if(i == 358)
            {
                i = 0;
            }
        }
    }
}
