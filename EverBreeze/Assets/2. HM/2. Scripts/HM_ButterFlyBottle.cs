using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_ButterFlyBottle : MonoBehaviour
{
    public GameObject[] butterfly;
    int touchCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ButterFly")
        {
            if(touchCount < butterfly.Length)
            {
                butterfly[touchCount].SetActive(true);
                touchCount++;
            }
        }
    }
}
