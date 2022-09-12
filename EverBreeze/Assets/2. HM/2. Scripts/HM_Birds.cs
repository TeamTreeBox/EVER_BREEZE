using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HM_Birds : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] birdsMove;
    Animator birds_anim;
    NavMeshAgent birds_Ai;

    public float distance;
    public float aiDis;

    public float XRange;
    public float YRange;
    public float ZRange;

    public int a;
    bool isPlayerCom = false;
    bool isWalking = true;

    Coroutine co_idle;
    Coroutine co_Move;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        birds_anim = GetComponent<Animator>();
        birds_Ai = GetComponent<NavMeshAgent>();
        XRange = Random.Range(800, 1000);
        ZRange = Random.Range(-500, 500);
        YRange = Random.Range(30, 60);

        a = Random.Range(0, birdsMove.Length);

      

        co_idle = StartCoroutine(IsIdle());

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, Player.transform.position);
        aiDis = Vector3.Distance(this.transform.position, birdsMove[a].transform.position);

        if(distance < 50)
        {
            isPlayerCom = true;
        }

        if (isPlayerCom == true)
        {
            if(isWalking == true)
            {
            StopCoroutine(co_idle);
            }
            else
            {
            StopCoroutine(co_Move);
            }

            birds_Ai.enabled = false;
            isPlayerCom = true;
            IsPlayerCome();
        }
    }

    void IsPlayerCome()
    {
        this.transform.LookAt(new Vector3(XRange, 10, ZRange));

        //JY_AudioManager.instance.debug_Audio = 2;

        birds_anim.SetBool("IsWalk", false);
        birds_anim.SetBool("IsPlayerCome", true);

        // this.transform.Translate(new Vector3(XRange, YRange, ZRange) * speed * Time.deltaTime);

        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(XRange, YRange, ZRange), speed * Time.deltaTime);


        Destroy(this.gameObject, 10f);
    }


    IEnumerator IsIdle()
    {
        if(isPlayerCom == false)
        {
            isWalking = true;
            yield return new WaitForSeconds(1f);

            birds_anim.SetBool("IsPlayerCome", false);
            birds_anim.SetBool("IsWalk", true);

            birds_Ai.isStopped = false;

            birds_Ai.SetDestination(birdsMove[a].transform.position);

            if(aiDis < 2f)
            {
                isWalking = false;
                co_Move = StartCoroutine(IsNextMove());
            }
            else
            {
                co_idle = StartCoroutine(IsIdle());
            }

        }

    }

    IEnumerator IsNextMove()
    {
        birds_Ai.isStopped = true;
        birds_anim.SetBool("IsWalk", false);
        yield return new WaitForSeconds(1f);
        a = Random.Range(0, birdsMove.Length);
        StartCoroutine(IsIdle());
    }

}
