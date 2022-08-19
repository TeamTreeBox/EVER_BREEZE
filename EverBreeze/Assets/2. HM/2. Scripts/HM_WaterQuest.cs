using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HM_WaterQuest : MonoBehaviour
{
    public GameObject player;
    public GameObject cristal;
    public GameObject cristal_pos;

    float distance;
    float cristal_Dis;

    bool iscris_blowup = false;

    //public GameObject debug_playerpos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR


        if (Input.GetKeyDown(KeyCode.F))
        {
            //StartCoroutine(Debug_Test());
        }

#endif
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(CristalBlowUp());
        }
    }

    IEnumerator CristalBlowUp()
    {
        while (iscris_blowup == false)
        {
            cristal.transform.position = Vector3.Lerp(cristal.transform.position, cristal_pos.transform.position, Time.deltaTime);

            yield return new WaitForSeconds(0.1f);

            cristal.AddComponent<Rigidbody>();

            Rigidbody rigi = cristal.GetComponent<Rigidbody>();

            rigi.useGravity = false;
        }
    }

    //IEnumerator Debug_Test()
    //{
    //    this.transform.SetParent(debug_playerpos.transform);

    //    this.transform.localPosition = Vector3.zero;

    //    yield return new WaitForEndOfFrame();
    //}


}
