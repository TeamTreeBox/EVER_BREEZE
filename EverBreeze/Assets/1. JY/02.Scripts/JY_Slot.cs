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
    bool waterIn;

    public void Start()
    {
        waterIn = false;
        water.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (activeState == true && obj.CompareTag("Player") && waterCount == waterMaxCount)
        {
            WaterReleaseItem();
            print("!!»ç¶óÁü");
        }

    }
    int waterCount;
    int waterMaxCount = 1;
    private void OnTriggerStay(Collider other)
    {
        //if (ItemInSlot != null) return;
        //GameObject obj = other.gameObject;
        GameObject obj = other.gameObject;
        //if (!IsItem(obj)) return;

        if (activeState == false && obj.CompareTag("Water") && waterCount < waterMaxCount)
        {
            WaterInsertItem(obj);
            print("!!»ý°ÜÁü");
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void WaterInsertItem(GameObject obj)
    {
        waterCount++;

        Destroy(obj.gameObject);
        //obj.gameObject.SetActive(false);

        water.gameObject.SetActive(true);

        waterIn = true;

        water.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Inventory;
    }

    void WaterReleaseItem()
    {
        print(">M< Out Item");
        water.gameObject.SetActive(false);

        GameObject waterNew = Instantiate(waterFactory);
        waterNew.transform.position = waterPos.transform.position;

        waterIn = false;
        waterCount--;
    }

    /*void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
        obj.transform.localScale = new Vector3(obj.transform.localScale.x / 2, obj.transform.localScale.y / 2, obj.transform.localScale.z / 2);
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        isInitem = true;
        //slotImage.color = Color.gray;
    }*/

    /*    void ReleaseItem(GameObject obj)
        {
            print(">M< Out Item");
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.transform.SetParent(null);
            obj.transform.localPosition = this.transform.position;
            obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
            obj.transform.localScale = new Vector3(obj.transform.localScale.x * 2, obj.transform.localScale.y * 2, obj.transform.localScale.z * 2);
            obj.GetComponent<Item>().inSlot = false;
            obj.GetComponent<Item>().currentSlot = null;
            ItemInSlot = null;
            isInitem = false;
        }

        void Inventoryobj()
        {
            // ÀÎº¥Åä¸® Ãß°¡ ***
            if (ItemInSlot.GetComponent<Item>() == null) return;
            if (ItemInSlot.GetComponent<Item>().inSlot == true)
            {
                ItemInSlot.GetComponent<Slot>().ItemInSlot = null;
                ItemInSlot.transform.parent = null;
                ItemInSlot.GetComponent<Item>().inSlot = false;
                ItemInSlot.GetComponent<Item>().currentSlot.ResetColor();
                ItemInSlot.GetComponent<Item>().currentSlot = null;
            }
        }*/
}
