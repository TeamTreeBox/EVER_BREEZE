using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ButterflyFlying : MonoBehaviour
{

    //var target:Vector3;
    private Vector3 target;
    //var timer:float;
    private float timer;
    //var sec:int;
    private int sec;

    void Start()
    {
        target = ResetTarget();
        sec = ResetSec();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > sec)
        {
            target = ResetTarget();
            sec = ResetSec();
        }
        transform.Translate(target * 10 * Time.deltaTime);
    }

    Vector3 ResetTarget()
    {
        return new Vector3(Random.Range(transform.position.x + -2.0f, transform.position.x + 2.0f), Random.Range(transform.position.y + -2.0f, transform.position.y + 2.0f), Random.Range(transform.position.z + -2.0f, transform.position.z + 2.0f));
    }

    int ResetSec()
    {
        timer = 0;
        return Random.Range(1, 3);
    }
}
