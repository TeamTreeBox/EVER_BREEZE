using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_JingleBell : MonoBehaviour
{
    public bool isJingleTouch = false;
    public int jingleShake = 0;

     GameObject tree;

    float distance;

    private void Start()
    {
        tree = GameObject.FindGameObjectWithTag("Tree");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(tree.transform.position, this.transform.position);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(distance < 20f)
        {
            if (other.gameObject.name == "First_Touch")
            {
                FirstTouch();
            }
            else if (other.gameObject.name == "Second_Touch")
            {
                SecondTouch();
                if (jingleShake >= 3)
                {
                    ThirdShake();
                }
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
        HM_QuestManager.instance.StartCoru(3);

        Destroy(this.gameObject);

    }

}
