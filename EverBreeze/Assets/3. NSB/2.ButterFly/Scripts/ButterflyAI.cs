using Oculus.Platform.Samples.VrHoops;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ButterflyAI : MonoBehaviour
{ 
    public static ButterflyAI instance;
    private void Awake()
    {
        instance = this;
    }

    // 속도
    float speed;

    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float minSpeed;
    [SerializeField]
    float defaultSpeed;

    [SerializeField]
    float speedLerpAmount;
    [SerializeField]
    float turningForce;

    //이동포인트
    Transform currentWaypoint;
    Transform saveWaypoint;

    [SerializeField]
    List<Transform> initialWaypoints;
    Queue<Transform> waypointQueue;

    float prevWaypointDistance;
    float waypointDistance;
    bool isComingClose;

    float prevRotY;
    float currRotY;
    float rotateAmount;
    float zRotateValue;

    float turningTime;


    //회전
    [SerializeField]
    float zRotateMaxThreshold = 0.5f;
    [SerializeField]
    float zRotateAmount = 90;


    public bool rest;
    public bool catchpossible = false;

    public GameObject grabHand;
    public GameObject bottle;
    public GameObject arrive;

    public GameObject shader;






    void ChangeWaypoint()
    {
        if (waypointQueue.Count == 0)
        {
            StartCoroutine(ButterflyRest());
            return;
        }

        currentWaypoint = waypointQueue.Dequeue();
        waypointDistance = Vector3.Distance(transform.position, currentWaypoint.position);
        prevWaypointDistance = waypointDistance;

        isComingClose = false;
    }

    void CheckWaypoint()
    {
        if (currentWaypoint == null)
        {
           
            return;
        }
        waypointDistance = Vector3.Distance(transform.position, currentWaypoint.position);

        if (waypointDistance >= prevWaypointDistance) // Aircraft is going farther from the waypoint
        {
            if (isComingClose == true)
            {
                ChangeWaypoint();
            }
        }
        
        else
        {
            isComingClose = true;
        }

        prevWaypointDistance = waypointDistance;
    }

    void Rotate()
    {
        if (currentWaypoint == null)
            return;

        Vector3 targetDir = currentWaypoint.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDir);

        float delta = Quaternion.Angle(transform.rotation, lookRotation);
        if (delta > 0f)
        {
            float lerpAmount = Mathf.SmoothDampAngle(delta, 0.0f, ref rotateAmount, turningTime);
            lerpAmount = 1.0f - (lerpAmount / delta);

            Vector3 eulerAngle = lookRotation.eulerAngles;
            eulerAngle.z += zRotateValue * zRotateAmount;
            lookRotation = Quaternion.Euler(eulerAngle);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, lerpAmount);
        }
    }

    void ZAxisRotate()
    {
        currRotY = transform.eulerAngles.y;
        float diff = prevRotY - currRotY;

        if (diff > 180) diff -= 360;
        if (diff < -180) diff += 360;

        prevRotY = transform.eulerAngles.y;
        zRotateValue = Mathf.Lerp(zRotateValue, Mathf.Clamp(diff / zRotateMaxThreshold, -1, 1), turningForce * Time.deltaTime);
    }

    void StartWaypoint()
    {
        this.speed = 6;
        shader.GetComponent<Renderer>().material.SetFloat("_Speed", 5);
        waypointQueue = new Queue<Transform>();
        foreach (Transform t in initialWaypoints)
        {
            waypointQueue.Enqueue(t);
        }
        ChangeWaypoint();
    }

    void Move()
    {
        transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
    }
 

    void Start()
    {
        speed = defaultSpeed;
        turningTime = 1 / turningForce;
        rest = false;
        StartWaypoint();

    }


    void Update()
    {
     
        CheckWaypoint();
        Rotate();
        ZAxisRotate();
        Move();
    }

     
    IEnumerator ButterflyRest() //활성화 상태의 휴식하는 나비
    {   //Vector3.Distance(arrive.transform.position, this.transform.position) < 15.0f &&
       
        rest = true;
        this.speed = 0;
        yield return new WaitForSeconds(5.0f);
        if (grabHand.GetComponent<CapOpen>().isGrabOn == true && bottle.GetComponent<StopStateCheck>().gatherState == true&& bottle.GetComponent<StopStateCheck>().stopState == true)
        {
            print(isComingClose);
            currentWaypoint = arrive.transform;
           
            Rotate();
            catchpossible = true;
            speed = 6;
            isComingClose = false;
            this.transform.position = Vector3.MoveTowards(transform.position, arrive.transform.position, 0.1f);
            catchpossible = false;

        }

        else if(grabHand.GetComponent<CapOpen>().isGrabOn == false || bottle.GetComponent<StopStateCheck>().gatherState == false)
        {
            isComingClose = true;
            StartWaypoint();
        }
        
        yield return new WaitForSeconds(5.0f);
        rest = false;
        this.speed += 0.01f;
        isComingClose = true;
        StartWaypoint();
        }
       
    
    private void OnTriggerEnter(Collider other)
    {       
            if (grabHand.GetComponent<CapOpen>().isGrabOn == true && bottle.GetComponent<StopStateCheck>().gatherState == true && catchpossible == true)
            {
                if (other.tag == "Bottle")
                {
                    this.gameObject.SetActive(false);
                    other.gameObject.GetComponent<SB_ButterflyQuest>().touchCount++;

                }

            }
        }
    
}