using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_Birds : MonoBehaviour
{
    public GameObject Player;

    Animator birds_anim;

    float distance;

    // Start is called before the first frame update
    void Start()
    {
        birds_anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, Player.transform.position);

        if(distance < 10f)
        {
            birds_anim.SetBool("IsPlayerCome", true);
        }
    }
}
