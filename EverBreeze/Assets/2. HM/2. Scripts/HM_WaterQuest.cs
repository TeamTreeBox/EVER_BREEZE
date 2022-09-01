using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HM_WaterQuest : MonoBehaviour
{
    public GameObject player;
    public GameObject cristal;
    public GameObject cristal_pos;

    public GameObject waterVfx;
    public GameObject inSideWater;

    float distance;
    float cristal_Dis;

    bool iscris_blowup = false;

    // Start is called before the first frame update
    void Start()
    {
        inSideWater.SetActive(false);
        inSideWater.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        cristal_Dis = Vector3.Distance(cristal.transform.position, cristal_pos.transform.position);

        if(cristal_Dis < 1f)
        {
            StopAllCoroutines();
        }
    }

    public void CristalCoroutine()
    {
        StartCoroutine(CristalBlowUp());
    }

    IEnumerator CristalBlowUp()
    {
        while (iscris_blowup == false)
        {
            inSideWater.SetActive(false);
            inSideWater.SetActive(true);
            cristal.transform.position = Vector3.Lerp(cristal.transform.position, cristal_pos.transform.position, Time.deltaTime);

            yield return new WaitForSeconds(0.1f);

            cristal.AddComponent<Rigidbody>();

            Rigidbody rigi = cristal.GetComponent<Rigidbody>();

            rigi.useGravity = false;
            //rigi.isKinematic = true;
            rigi.constraints = RigidbodyConstraints.FreezePosition;

            if (cristal_Dis < 0.55f)
            {
                this.gameObject.layer = 1 << 6;
                iscris_blowup = true;
                StopAllCoroutines();
            }
        }

       
    }

    public void SizeChangeWaterVFX()
    {
        print("WaterSizeChanage");
        waterVfx.transform.localScale = new Vector3(.1f, .1f, .1f);

        GameObject vfxChild = waterVfx.transform.GetChild(0).gameObject;

        vfxChild.transform.localScale = new Vector3(.1f, .1f, .1f);

        inSideWater.SetActive(false);
        inSideWater.SetActive(true);

    }
}
