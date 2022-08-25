using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HMItemState
{
    Field,
    Grab,
    Inventory
}

public class HM_NewItemInfo : MonoBehaviour
{
    private bool activeState;

    public GameObject itemInfo;

    public HMItemState state = HMItemState.Field;

    void Start()
    {
        itemInfo.SetActive(false);
        activeState = false;
    }

    bool stateInventory;
    void Update()
    {
        print(state);
        switch (state)
        {
            case HMItemState.Field:
                Feild();
                //print(state);
                break;

            case HMItemState.Grab:
                Grab();
                //print(state);
                break;

            case HMItemState.Inventory:
                Inventory();
                break;
        }

        if (BookVR.instance.InventoryOn == true && stateInventory == false)
        {
            stateInventory = true;
            ItemState state = ItemState.Inventory;
            //print("%R.Two 버튼 누름%");
            //print(state);
        }
    }

    private void Feild()
    {
        itemInfo.SetActive(false);
    }

    private void Grab()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                print("사라짐");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                print("생겨짐");
                activeState = true;
            }
        }
    }

    bool itemInfoActive;
    private void Inventory()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "Water")
        {
            print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                print("사라짐");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                print("생겨짐");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "Branch")
        {
            print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                print("사라짐");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                print("생겨짐");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "JamSotone")
        {
            print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                print("사라짐");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                print("생겨짐");
                activeState = true;
            }
        }
    }
}
