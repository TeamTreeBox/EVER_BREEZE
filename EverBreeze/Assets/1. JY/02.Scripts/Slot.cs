using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    //public GameObject slotImage;
    //Color originalColor;

    void Start()
    {
        //slotImage = GetComponentInChildren<Image>();
        //originalColor = slotImage.color;
    }

    bool isInitem = false;
    private void OnTriggerStay(Collider other)
    {
        //if (ItemInSlot != null) return;
        GameObject obj = other.gameObject;
        if (!IsItem(obj)) return;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            InsertItem(obj);
        }
        if (OVRInput.GetDown(OVRInput.Button.Four))
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
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<Item>().slotRotatin;
        obj.transform.localScale = new Vector3(obj.transform.localScale.x / 2, obj.transform.localScale.y / 2, obj.transform.localScale.z / 2);
        obj.GetComponent<Item>().inSlot = true;
        //obj.GetComponent<Item>().currentSlot = this;
        ItemInSlot = obj;
        isInitem = true;
        //slotImage.color = Color.gray;
    }

    void ReleaseItem(GameObject obj)
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
        ResetColor();
    }

    public void ResetColor()
    {
        //slotImage.color = originalColor;
    }

    void Inventoryobj()
    {
        // 인벤토리 추가 ***
        if (ItemInSlot.GetComponent<Item>() == null) return;
        if (ItemInSlot.GetComponent<Item>().inSlot == true)
        {
            ItemInSlot.GetComponent<Slot>().ItemInSlot = null;
            ItemInSlot.transform.parent = null;
            ItemInSlot.GetComponent<Item>().inSlot = false;
            ItemInSlot.GetComponent<Item>().currentSlot = null;
        }
    }
}

