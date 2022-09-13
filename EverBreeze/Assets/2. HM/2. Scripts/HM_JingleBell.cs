using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_JingleBell : MonoBehaviour
{
    public bool isJingleTouch = false;
    public int jingleShake = 0;

     GameObject tree;

    public GameObject firstTouch;
    public GameObject secondTouch;
    AudioSource first;
    AudioSource Second;

    float distance;

    private void Start()
    {
        tree = GameObject.FindGameObjectWithTag("Tree");

        first = firstTouch.GetComponent<AudioSource>();
        Second = secondTouch.GetComponent<AudioSource>();
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
            if (other.gameObject.name == "First_Touch" && isJingleTouch == false)
            {
                FirstTouch();
            }
            else if (other.gameObject.name == "Second_Touch" && isJingleTouch == true)
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
        first.Play();
        print("�� 1");

    }

    void SecondTouch()
    {
        jingleShake += 1;
        isJingleTouch = false;
        print("�� �ѹ� �ֵθ�");
        Second.Play();
        print("�� 2");
    }

    void ThirdShake()
    {
        print("������ ���ϰ� �ϱ�");
        HM_QuestManager.instance.StartCoru(3);

    }

}
