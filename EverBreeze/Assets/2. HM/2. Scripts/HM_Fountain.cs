using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_Fountain : MonoBehaviour
{
    public GameObject WaterBall;

    private void Start()
    {
       
    }

    private void OnTriggerEnter(Collider  other)
    {
        if(other.tag == "Player_Hand")
        {
            if(WaterBall.gameObject != null)
            WaterBall.GetComponent<HM_WaterQuest>().CristalCoroutine();
        }    
    }
}
