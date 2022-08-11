using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_SkyboxTrigger : MonoBehaviour
{
    GameObject Player;
    Camera cam;

    public Material[] mat;
    public Skybox skybox;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("MainCamera");
        cam = Player.GetComponent<Camera>();
        skybox = Player.AddComponent<Skybox>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnterRegion")
        {
            skybox.material = mat[1];
        }
        else if (other.tag == "OutRegion")
        {
            skybox.material = mat[0];
        }
    }
}
