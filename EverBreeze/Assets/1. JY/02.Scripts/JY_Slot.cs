using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_Slot : MonoBehaviour
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

    public void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (activeState == true && JY_RayGrab.instance.grabable.CompareTag("Slot") && waterCount == waterMaxCount)
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

    }

    public int waterCount;
    int waterMaxCount = 1;

    int branchCount;
    int branchMaxCount = 3;

    int jamStoneCount;
    int jamStoneMaxCount = 1;
    private void OnTriggerStay(Collider other)
    {
        //if (ItemInSlot != null) return;
        //GameObject obj = other.gameObject;
        GameObject obj = other.gameObject;
        //if (!IsItem(obj)) return;

        if (ItemInSlot != water || ItemInSlot != branch || ItemInSlot != jamStone)
        {
        if (activeState == false && obj.CompareTag("Water") && waterCount < waterMaxCount && ItemInSlot == null)
        {
            JY_RayGrab.instance.isGrabOn = false;
            WaterInsertItem(obj);
            print("!!@»ý°ÜÁü");
        }

        if (activeState == false && obj.CompareTag("Branch") && branchCount < branchMaxCount && ItemInSlot == null)
        {
            JY_RayGrab.instance.isGrabOn = false;
            BranchInsertItem(obj);
            print("!!#»ý°ÜÁü");
        }

        if (activeState == false && obj.CompareTag("JamStone") && jamStoneCount < jamStoneMaxCount && ItemInSlot == null)
        {
            JY_RayGrab.instance.isGrabOn = false;
            jamStoneInsertItem(obj);
            print("!!$»ý°ÜÁü");
        }
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    public bool isWaterItemIn; 
    void WaterInsertItem(GameObject obj)
    {
        if (waterCount < waterMaxCount)
        {
            waterCount++;

            Destroy(obj.gameObject);
            //obj.gameObject.SetActive(false);

            water.gameObject.SetActive(true);

            water.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Inventory;

            isWaterItemIn = true;

            ItemInSlot = water;
        }
    }

    void BranchInsertItem(GameObject obj)
    {
        if (branchCount < branchMaxCount)
        {
            branchCount++;

            Destroy(obj.gameObject);
            //obj.gameObject.SetActive(false);

            branch.gameObject.SetActive(true);

            branch.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Inventory;

            isWaterItemIn = true;

            ItemInSlot = branch;
        }
    }

    void jamStoneInsertItem(GameObject obj)
    {
        if (jamStoneCount < jamStoneMaxCount)
        {
            jamStoneCount++;

            Destroy(obj.gameObject);
            //obj.gameObject.SetActive(false);

            jamStone.gameObject.SetActive(true);

            jamStone.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Inventory;

            ItemInSlot = jamStone;
        }
    }

    public void WaterReleaseItem()
    {
        print(">M< Out Item");
        water.gameObject.SetActive(false);

        GameObject waterNew = Instantiate(waterFactory);
        waterNew.transform.position = waterPos.transform.position;

        //waterCount--;

        ItemInSlot = null;
    }

    void BranchReleaseItem()
    {
        print(">M< Out Item");
        branch.gameObject.SetActive(false);

        GameObject branchNew = Instantiate(branchFactory);
        branchNew.transform.position = branchPos.transform.position;

        //branchCount--;

        ItemInSlot = null;
    }

    void JamStoneReleaseItem()
    {
        print(">M< Out Item");
        jamStone.gameObject.SetActive(false);

        GameObject jamStoneNew = Instantiate(jamStoneFactory);
        jamStoneNew.transform.position = jamStonePos.transform.position;

        //jamStoneCount--;

        ItemInSlot = null;
    }
}
