using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBlenderMGR : MonoBehaviour
{
    public Material skyBox;
    public GameObject cam;

    public Texture[] Skybox_1;
    public Texture[] Skybox_2;
    public Texture[] Skybox_3;

    string[] shaderProp_1 = { "_FrontTex", "_BackTex", "_LeftTex", "_RightTex", "_UpTex", "_DownTex" };

    string[] shaderProp_2 = { "_FrontTex2", "_BackTex2", "_LeftTex2", "_RightTex2", "_UpTex2", "_DownTex2" };

    // Start is called before the first frame update
    void Start()
    {
        cam.AddComponent<Skybox>().material = skyBox;

        skyBox.shader = Shader.Find("RenderFX/Skybox Blended");

        

        StartCoroutine(FirstSkyBoxChange());
        StartCoroutine(SecondSkyBoxChange());

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(SkyGoNight());
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SkyGoDay());
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(FirstSkyBoxChange());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(SecondSkyBoxChange());
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(ThirdSkyBoxChange());
        }


    }

  IEnumerator FirstSkyBoxChange()
    {
        for(int i =0; i < Skybox_1.Length; i++)
        {
            skyBox.SetTexture(shaderProp_1[i], Skybox_1[i]);
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator SecondSkyBoxChange()
    {
        for (int i = 0; i < Skybox_2.Length; i++)
        {
            skyBox.SetTexture(shaderProp_1[i], Skybox_2[i]);
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator ThirdSkyBoxChange()
    {
        print("ThirdSkyBoxChange");
        for (int i = 0; i < Skybox_3.Length; i++)
        {
            skyBox.SetTexture(shaderProp_1[i], Skybox_3[i]);
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator SkyGoNight()
    {
        print("GONight");
        for (float i = 0; i <= 1; i += 0.05f)
        {
            skyBox.SetFloat("_Blend", i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator SkyGoDay()
    {
        print("GODay");
        for (float i = 1; i >= 0; i -= 0.05f)
        {
            skyBox.SetFloat("_Blend", i);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
