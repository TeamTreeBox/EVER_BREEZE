using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_JemStone : MonoBehaviour
{
    Material jemMat;
    Texture jemTexture;
    MeshRenderer jemMesh;

    Color finalColor;

    // Start is called before the first frame update
    void Start()
    {
        jemMesh = GetComponent<MeshRenderer>();
        jemMat = jemMesh.material;
        jemTexture = GetComponent<Texture>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == this.gameObject.tag)
        {
            float emission = Mathf.PingPong( Time.time, 1.0f);
            Color baseColor = Color.red;
             finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

            jemMat.SetColor("_EmissionColor", finalColor * 1.5f);
        }
    }

    
    
}
