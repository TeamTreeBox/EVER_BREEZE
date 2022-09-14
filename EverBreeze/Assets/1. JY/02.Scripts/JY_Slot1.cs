using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class JY_Slot1 : MonoBehaviour
{
    public GameObject ItemInSlot;
    public GameObject countImage;

    public GameObject slot01;
    public GameObject slot02;
    public GameObject slot03;

    public int itemCount = 0;
    public int itemMaxCount = 5;

    public TextMeshProUGUI text_Count;

    public bool isInitem = false;
    public GameObject itemPOS;
    public GameObject jingleBellGrabPos;

    public bool inSlot01;
    public bool inSlot02;
    public bool inSlot03;

    void Start()
    {
        countImage.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        //if (ItemInSlot != null) return;
        GameObject obj = other.gameObject;
        if (!IsItem(obj)) return;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && obj.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            InsertItem(obj);
        }
    }
    
    public void OutItem()
    {
        if (isInitem == true && OVRInput.GetDown(OVRInput.Button.One))
        {
            GameObject obj = transform.GetChild(0).gameObject;
            ReleaseItem(obj);
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void InsertItem(GameObject obj)
    {
        obj.gameObject.layer = 7;
        JY_RayGrab.instance.isGrabOn = false;

        print(JY_RayGrab.instance.isGrabOn);

        JY_RayGrab.instance.NullGrabable();
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.GetComponent<Rigidbody>().useGravity = false;

        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
        obj.transform.localScale = new Vector3(obj.transform.localScale.x / 2.0f, obj.transform.localScale.y / 2.0f, obj.transform.localScale.z / 2.0f);

        StartCoroutine(IEVibration(1, 1, 0.3f, true, false));

        if (obj.tag == "WaterBall")
        {
            obj.transform.GetChild(1).gameObject.SetActive(false);
            obj.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (obj.tag == "JamStone")
        {
            obj.transform.GetChild(0).gameObject.SetActive(false);
            obj.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (obj.tag == "Bottle")
        {
            obj.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
        }

        obj.GetComponent<Item>().inSlot = true;

        if (this == slot01)
        {
            inSlot01 = true;
        }
        if (this == slot02)
        {
            inSlot02 = true;
        }
        if (this == slot03)
        {
            inSlot03 = true;
        }

        obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        isInitem = true;

        obj.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Inventory;

        //Count UI
        itemCount++;
        countImage.SetActive(true);
        text_Count.text = itemCount.ToString();
        print(">M< In Item >M<");
    }

    void ReleaseItem(GameObject obj)
    {
        obj.gameObject.layer = 6;
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.transform.SetParent(null);
        
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
        obj.GetComponent<Item>().inSlot = false;
        obj.GetComponent<Item>().currentSlot = null;
        ItemInSlot = null;

        if (text_Count.text == "0")
        {
            isInitem = false;
        }

        JY_RayGrab.instance.isGrabOn = true;
        JY_RayGrab.instance.grabable = obj.gameObject;
        obj.transform.SetParent(itemPOS.transform);

        
        obj.transform.localPosition = Vector3.zero;

        if (obj.tag == "JingleBell")
        {
            obj.transform.SetParent(jingleBellGrabPos.transform);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.localPosition = new Vector3(0.0287f, -0.04f, 0.0254f);
            obj.transform.localRotation = Quaternion.Euler(new Vector3(20.0f, 0.0f, -170.0f));
        }

        else if (obj.tag == "WaterBall")
        {
            obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        else if (obj.tag == "JamStone")
        {
            obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (obj.tag == "Branch")
        {
            obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        else if (obj.tag == "Bottle")
        {
            obj.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        }

        obj.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Grab;
        JY_RayGrab.instance.isSlotOff = false;

        itemCount--;
        countImage.SetActive(true);
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
        print(">>M< Out Item >M<<<");
    }

    public void ClearSlot()
    {
        countImage.SetActive(false);
    }

    IEnumerator IEVibration(float frequency, float amplitude, float duration, bool rightHand, bool leftHand)
    {
        if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
        if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);

        yield return new WaitForSeconds(duration);

        if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}
