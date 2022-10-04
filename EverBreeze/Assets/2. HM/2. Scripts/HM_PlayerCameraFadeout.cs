using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_PlayerCameraFadeout : MonoBehaviour
{

    public GameObject Quad;

    MeshRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = Quad.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadeIn()
    {
        StartCoroutine(GetFadeIn());
    }

    IEnumerator GetFadeOut()
    {
        Color C = render.material.color;

        for(float i = 1; i >= 0; i -= 0.1f)
        {
            C.a = i;
            render.material.color = C;
            yield return new WaitForSeconds(0.05f);
        }

        C.a = 0;
        render.material.color = C;
    }

    IEnumerator GetFadeIn()
    {
        Color C = render.material.color;

        for (float i = 0; i <= 1; i += 0.1f)
        {
            C.a = i;
            render.material.color = C;
            yield return new WaitForSeconds(0.05f);
        }

        C.a = 1;
        render.material.color = C;

        yield return new WaitForSeconds(1f);
        StartCoroutine(GetFadeOut());
    }
}
