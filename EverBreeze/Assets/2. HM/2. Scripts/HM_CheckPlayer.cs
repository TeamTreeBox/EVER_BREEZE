using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_CheckPlayer : MonoBehaviour
{

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        HM_FoxAI.instane.MoveOriginalPosition();
    //        print("PlayerTriggerEnter");
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HM_FoxAI.instane.MoveOriginalPosition();
            print("PlayerTriggerEnter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HM_FoxAI.instane.PlayerExitPosition();
            print("PlayerTriggerExit");
        }
    }
}
