using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_TriggerPT : MonoBehaviour
{
    public GameObject PT_name;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PT_name.SetActive(false);
        }
    }
}
