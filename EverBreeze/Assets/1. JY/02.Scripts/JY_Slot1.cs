using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JY_Slot1 : MonoBehaviour
{
    public GameObject ItemInSlot;
    public MeshRenderer slotMaterial;
    MaterialPropertyBlock originalBlock;

    void Start()
    {
        slotMaterial = GetComponent<MeshRenderer>();
        originalBlock = new MaterialPropertyBlock();

        slotMaterial.SetPropertyBlock(originalBlock);
    }
     
    public bool isInitem = false;
    public GameObject itemPOS;
    public void OnTriggerStay(Collider other)
    {
        //if (ItemInSlot != null) return;
        GameObject obj = other.gameObject;
        if (!IsItem(obj)) return;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            InsertItem(obj);
        }
        if (JY_RayGrab.instance.isSlotOff == true && OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            ReleaseItem(obj);
        }
    }

    bool IsItem(GameObject obj)
    {
        return obj.GetComponent<Item>();
    }

    void InsertItem(GameObject obj)
    {
        JY_RayGrab.instance.isGrabOn = false;
        JY_RayGrab.instance.NullGrabable();
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
        obj.transform.localScale = new Vector3(obj.transform.localScale.x * 0.5f, obj.transform.localScale.y * 0.5f, obj.transform.localScale.z * 0.5f);
        obj.GetComponent<Item>().inSlot = true;
        obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        isInitem = true;
        int id = Shader.PropertyToID("_Black");
        originalBlock.SetColor(id, Color.red);
        slotMaterial.SetPropertyBlock(originalBlock);
        obj.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Inventory;

        print(">M< In Item >M<");
    }

    void ReleaseItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.transform.SetParent(null);
        //obj.transform.localPosition = this.transform.position;
        obj.transform.localPosition = itemPOS.transform.position;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
        obj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        JY_RayGrab.instance.grabable.transform.SetParent(itemPOS.transform);
        obj.GetComponent<Item>().inSlot = false;
        obj.GetComponent<Item>().currentSlot = null;
        ItemInSlot = null;
        isInitem = false;
        obj.GetComponentInChildren<JY_ItemInfo>().state = ItemState.Grab;
        ResetColor();
        
        print(">>M< Out Item >M<<<");
    }

    public void ResetColor()
    {
        //slotMaterial.material.color = originalColor;
        int id = Shader.PropertyToID("_Black");
        originalBlock.SetColor(id, Color.green);
        slotMaterial.SetPropertyBlock(originalBlock);
    }

    /*void Inventoryobj()
    {
        // 인벤토리 추가 ***
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
