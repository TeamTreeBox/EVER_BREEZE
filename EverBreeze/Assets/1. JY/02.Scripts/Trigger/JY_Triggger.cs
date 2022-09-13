using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Triggger : MonoBehaviour
{
    public GameObject Tim_name;

    private void Start()
    {
        Tim_name.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Tim_name.SetActive(true);
        }
    }
}
