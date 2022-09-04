using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class HM_FoxAI : MonoBehaviour
{
    public static HM_FoxAI instane;

    private void Awake()
    {
        instane = this;
    }

    NavMeshAgent fox_AI;
    Animator fox_Anim;
    public GameObject player;
    int ran;
    float dis;
    float ranDis;
    float originDis;
    public GameObject originPose;
    public GameObject[] RandPose;

    bool isPlayerComeOn = false;
    bool isIdle = true;

    Coroutine randCoru;
    Coroutine MoveAnimCoru;
    Coroutine IdleAnimCoru;

    // Start is called before the first frame update
    void Start()
    {
        ran = Random.Range(0, RandPose.Length);
        fox_AI = this.GetComponent<NavMeshAgent>();
        fox_Anim = this.GetComponent<Animator>();
        randCoru = StartCoroutine(RandMove());
    }

    private void Update()
    {
        ranDis = Vector3.Distance(this.transform.position, RandPose[ran].transform.position);
        originDis = Vector3.Distance(this.transform.position, originPose.transform.position);

        if (fox_AI.isStopped == false)
        {
            fox_Anim.SetBool("IsWalking", true);
        }
        else
        {
            fox_Anim.SetBool("IsWalking", false);

        }
    }

    public void MoveOriginalPosition()
    {
        isPlayerComeOn = true;
        StopCoroutine(randCoru);
        fox_AI.isStopped = true;
        fox_AI.isStopped = false;
        fox_AI.SetDestination(originPose.transform.position);

        if(originDis < 1f)
        {
            fox_AI.isStopped = true;
            transform.LookAt(player.transform);
        }

    }

    public void PlayerExitPosition()
    {
        isPlayerComeOn = false;
        fox_AI.isStopped = true;
        fox_AI.isStopped = false;

        randCoru = StartCoroutine(RandMove());
    }

    public void QuestComplete()
    {
        fox_Anim.SetTrigger("QuestComplete");
    }

    IEnumerator RandMove()
    {
        while (isPlayerComeOn == false)
        {
            ran = Random.Range(0, RandPose.Length);

            fox_AI.SetDestination(RandPose[ran].transform.position);

            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator IdleAnim()
    {
        if (fox_AI.isStopped == true)
        {
            int a = Random.Range(0, 3);

            yield return new WaitForSeconds(3f);

            switch (a)
            {
                case 0:
                    fox_Anim.SetTrigger("Idle_1");
                    break;

                case 1:
                    fox_Anim.SetTrigger("Idle_2");
                    break;

                case 2:
                    fox_Anim.SetTrigger("Idle_3");
                    break;

            }

            if (fox_AI.isStopped == true)
            {
                yield return new WaitForEndOfFrame();
                IdleAnimCoru = StartCoroutine(IdleAnim());
            }
            else
            {
                yield return new WaitForEndOfFrame();
                MoveAnimCoru = StartCoroutine(MoveAnim());
            }
        }
    }

    IEnumerator MoveAnim()
    {
        if (isIdle == false)
        {
            fox_Anim.SetBool("IsWalking", true);

            if (fox_AI.isStopped == true)
            {
                yield return new WaitForEndOfFrame();
                IdleAnimCoru = StartCoroutine(IdleAnim());
            }
            else
            {
                yield return new WaitForEndOfFrame();
                MoveAnimCoru = StartCoroutine(MoveAnim());
            }
        }
    }
}



