using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_PCJam : MonoBehaviour
{
    Material mat;
    Texture texture;
    MeshRenderer meshRenderer;

    float emssionValue = 0;
    float emssionplus = 0.4f;
    float strengthValue = 0f;
    float strength_Plus = 0.8f;

    Color color;

    public GameObject player;
    public GameObject debug_playerpos;
    GameObject particle;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        debug_playerpos = player.transform.GetChild(1).gameObject;
        particle = this.transform.parent.GetChild(2).gameObject;
        meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material;
        texture = GetComponent<Texture>();
        //mat.SetFloat("_EmissionPower", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        print("Emission : " + mat.GetFloat("_EmissionPower"));
        print("Stregth : " + mat.GetFloat("_Translucency"));

        dist = Vector3.Distance(player.transform.position, this.transform.position);

        if(dist < 5)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(Debug_Test());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Right_Song")
        {
            StartCoroutine(ChangeEmissionValue());
        }
    }

    IEnumerator ChangeEmissionValue()
    {
        particle.SetActive(true);
        for(int i =0; i < 18; i++)
        {
            mat.SetFloat("_EmissionPower",emssionValue += emssionplus);
            mat.SetFloat("_Translucency", strengthValue += strength_Plus);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);

        particle.SetActive(false);
    }

    IEnumerator Debug_Test()
    {
        this.transform.parent.SetParent(debug_playerpos.transform);

        this.transform.localPosition = Vector3.zero;

        yield return new WaitForEndOfFrame();
    }

}
