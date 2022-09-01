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
    public GameObject player;
    float dis;

    public GameObject originPose;
    public GameObject[] RandPose;

    bool isPlayerComeOn = false;

    // Start is called before the first frame update
    void Start()
    {
        fox_AI = this.GetComponent<NavMeshAgent>();
        StartCoroutine(RandMove());
    }

    public void MoveOriginalPosition()
    {
        StopCoroutine(RandMove());
        fox_AI.isStopped = true;
        fox_AI.isStopped = false;
        fox_AI.SetDestination(originPose.transform.position);

    }

    public void PlayerExitPosition()
    {
        fox_AI.isStopped = false;
        fox_AI.isStopped = true;

        StartCoroutine(RandMove());
    }

    IEnumerator RandMove()
    {
        while (isPlayerComeOn == false)
        {
            int a = Random.Range(0, RandPose.Length + 1);

            fox_AI.SetDestination(RandPose[a].transform.position);

            yield return new WaitForSeconds(3f);
        }


    }
}
