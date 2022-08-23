using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookVR : MonoBehaviour
{
    public static BookVR instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject book;         //가이드북 Object
    public GameObject bookAnchor;   //가이드북 Position

    public GameObject inventory;    //인벤토리 Object
    public GameObject inventoryPos; //인벤토리 Position

    //public GameObject item;         //아이템 Object
    //public GameObject itemPos;      //인벤토리 Position

    bool UIActive;
    bool InventoryActive;
    bool ItemActive;

    public bool InventoryOn;

    public void Start()
    {
        book.SetActive(false);
        inventory.SetActive(false);
        //item.SetActive(false);

        UIActive = false;
        InventoryActive = false;
        InventoryOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //------------------------------------------가이드북
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            UIActive = !UIActive;
            book.SetActive(UIActive);

        }
        if (UIActive)
        {
            book.transform.position = bookAnchor.transform.position;
            book.transform.eulerAngles = new Vector3(bookAnchor.transform.eulerAngles.x, bookAnchor.transform.eulerAngles.y, bookAnchor.transform.eulerAngles.z);
        }
        //------------------------------------------인벤토리
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            InventoryActive = !InventoryActive;
            inventory.SetActive(InventoryActive);
        }
        if (InventoryActive)
        {
            inventory.transform.position = inventoryPos.transform.position;
            inventory.transform.eulerAngles = new Vector3(inventoryPos.transform.eulerAngles.x, inventoryPos.transform.eulerAngles.y, inventoryPos.transform.eulerAngles.z);
            InventoryOn = true;
        }
        //------------------------------------------아이템 정보
        /*if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            ItemActive = !ItemActive;
            item.SetActive(ItemActive);
        }

        if (ItemActive)
        {
            item.transform.position = itemPos.transform.position;
            item.transform.eulerAngles = new Vector3(itemPos.transform.eulerAngles.x, itemPos.transform.eulerAngles.y, itemPos.transform.eulerAngles.z);
        }*/
    }
}
