using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_PCWaterQuest : MonoBehaviour
{
    public GameObject player;
    public GameObject cristal;
    public GameObject cristal_pos;

    float distance;
    float cristal_Dis;

    bool iscris_blowup = false;
    
    public GameObject debug_playerpos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR

        distance = Vector3.Distance(player.transform.position, this.transform.position);
        cristal_Dis = Vector3.Distance(cristal.transform.position, cristal_pos.transform.position);

        if(distance < 5f)
        {
            StartCoroutine(CristalBlowUp());
        }


        if (Input.GetKeyDown(KeyCode.F) && iscris_blowup == true)
        {
            StartCoroutine(Debug_Test());
        }

#endif
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
            rigi.isKinematic = true;

          if(cristal_Dis < 0.1f)
            {
                iscris_blowup = true;
            }
 
        }
    }

    IEnumerator Debug_Test()
    {
        this.transform.SetParent(debug_playerpos.transform);

        this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        this.transform.localPosition = Vector3.zero;

        yield return new WaitForEndOfFrame();
    }


}
