using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_Triggger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WaterBall" && other.GetComponentInChildren<JY_ItemInfo>().state == ItemState.Field)
        {
            Invoke("ItemTrigger(Collider other)", 2.0f);
        }
    }

    public void ItemTrigger(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
