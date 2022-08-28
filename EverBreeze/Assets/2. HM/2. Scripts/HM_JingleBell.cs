using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_JingleBell : MonoBehaviour
{
    public bool isJingleTouch = false;
    public int jingleShake = 0;

    //public GameObject tree;

    //float distance;

    // Update is called once per frame
    void Update()
    {
       // distance = Vector3.Distance(tree.transform.position, this.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "First_Touch")
        {
            FirstTouch();
        }
        else if (other.gameObject.name == "Second_Touch")
        {
            SecondTouch();
            if(jingleShake >= 1)
            {
                ThirdShake();
            }
        }
    }

    void FirstTouch()
    {
        isJingleTouch = true;
    }

    void SecondTouch()
    {
        jingleShake += 1;
        isJingleTouch = false;
        print("벨 한번 휘두름");
    }

    void ThirdShake()
    {
        print("나무가 변하게 하기");
    }

}
