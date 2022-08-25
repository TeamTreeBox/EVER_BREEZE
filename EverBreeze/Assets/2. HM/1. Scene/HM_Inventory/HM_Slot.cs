using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HM_Slot : MonoBehaviour
{
    private bool activeState;

    public GameObject ItemInSlot;

    public GameObject waterFactory;
    public GameObject waterPos;
    public GameObject water;

    public GameObject branchFactory;
    public GameObject branchPos;
    public GameObject branch;

    public GameObject jamStoneFactory;
    public GameObject jamStonePos;
    public GameObject jamStone;

    public GameObject itemPos;

    public void Start()
    {
        water.SetActive(false);
        branch.SetActive(false);
        jamStone.SetActive(false);
    }

    public void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            ButtonSecondary();
        }
    }

    public void ButtonSecondary()
    {
        if (activeState == true)
        {
            print("!»ç¶óÁü");
            activeState = false;
        }
        else
        {
            print("!»ý°ÜÁü");
            activeState = true;
        }
    }

    /*public void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (activeState == true && JY_RayGrab.instance.grapable.CompareTag("Slot") && waterCount == waterMaxCount)
        {
            WaterReleaseItem();
            print("!!@»ç¶óÁü");
        }

        if (activeState == true && branchCount == branchMaxCount)
        {
            BranchReleaseItem();
            print("!!#»ç¶óÁü");
        }

        if (activeState == true && jamStoneCount == jamStoneMaxCount)
        {
            JamStoneReleaseItem();
            print("!!$»ç¶óÁü");
        }

    }*/
    public int waterCount;
    int waterMaxCount = 1;

    int branchCount;
    int branchMaxCount = 1;

    int jamStoneCount;
    int jamStoneMaxCount = 1;
    private void OnTriggerStay(Collider other)
    {
        //if (ItemInSlot != null) return;
        //GameObject obj = other.gameObject;
        GameObject obj = other.gameObject;
        //if (!IsItem(obj)) return;

        if (activeState == false && obj.CompareTag("Water") && waterCount < waterMaxCount)
        {
            HM_NewRayCast.instance.isGrabOn = false;
            WaterInsertItem(obj);
            print("!!@»ý°ÜÁü");
        }

        if (activeState == false && obj.CompareTag("Branch") && branchCount < branchMaxCount)
        {
            HM_NewRayCast.instance.isGrabOn = false;
            BranchInsertItem(obj);
            print("!!#»ý°ÜÁü");
        }

        if (activeState == false && obj.CompareTag("JamStone") && jamStoneCount < jamStoneMaxCount)
        {
            HM_NewRayCast.instance.isGrabOn = false;
            jamStoneInsertItem(obj);
            print("!!$»ý°ÜÁü");
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    public bool isWaterItemIn;
    void WaterInsertItem(GameObject obj)
    {
        waterCount++;

        Destroy(obj.gameObject);
        //obj.gameObject.SetActive(false);

        water.gameObject.SetActive(true);

        water.GetComponentInChildren<HM_NewItemInfo>().state = HMItemState.Inventory;

        isWaterItemIn = true;
    }

    void BranchInsertItem(GameObject obj)
    {
        branchCount++;

        Destroy(obj.gameObject);
        //obj.gameObject.SetActive(false);

        branch.gameObject.SetActive(true);

        branch.GetComponentInChildren<HM_NewItemInfo>().state = HMItemState.Inventory;
    }

    void jamStoneInsertItem(GameObject obj)
    {
        jamStoneCount++;

        Destroy(obj.gameObject);
        //obj.gameObject.SetActive(false);

        jamStone.gameObject.SetActive(true);

        jamStone.GetComponentInChildren<HM_NewItemInfo>().state = HMItemState.Inventory;
    }

    public void WaterReleaseItem()
    {
        print(">M< Out Item");
        water.gameObject.SetActive(false);

        GameObject waterNew = Instantiate(waterFactory);
        //waterNew.transform.position = waterPos.transform.position;
        //waterNew.transform.position = itemPos.transform.localPosition;

        HM_NewRayCast.instance.GrabItem(waterNew);

        waterCount--;
    }

    void BranchReleaseItem()
    {
        print(">M< Out Item");
        branch.gameObject.SetActive(false);

        GameObject branchNew = Instantiate(branchFactory);
        branchNew.transform.position = branchPos.transform.position;

        branchCount--;
    }

    void JamStoneReleaseItem()
    {
        print(">M< Out Item");
        jamStone.gameObject.SetActive(false);

        GameObject jamStoneNew = Instantiate(jamStoneFactory);
        jamStoneNew.transform.position = jamStonePos.transform.position;

        jamStoneCount--;
    }
}
