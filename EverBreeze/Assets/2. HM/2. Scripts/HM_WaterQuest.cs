using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_WaterQuest : MonoBehaviour
{
    public GameObject player;
    public GameObject cristal;
    public GameObject cristal_pos;

    float distance;
    float cristal_Dis;

    bool iscris_blowup = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        cristal_Dis = Vector3.Distance(cristal.transform.position, cristal_pos.transform.position);
        if (distance < 3f)
        {
            if (cristal_Dis > 0.2f)
            {
                StartCoroutine(CristalBlowUp());
            }
            else
            {
                iscris_blowup = true;
                StopAllCoroutines();
            }
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
}
