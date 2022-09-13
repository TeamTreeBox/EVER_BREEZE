using GlobalSnowEffect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_FogTrigger : MonoBehaviour
{
    bool Entered = false;
    public Color FogColor;

    // Start is called before the first frame update
    void Start()
    {
        Entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player"&& Entered == false)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = FogColor;
            RenderSettings.fogMode = FogMode.Exponential; RenderSettings.fogDensity = 0.01f;
            Entered = true;
        }

        
    }
}
