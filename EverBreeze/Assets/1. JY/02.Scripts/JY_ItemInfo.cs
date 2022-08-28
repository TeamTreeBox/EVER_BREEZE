using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemState
{
    Field,
    Grab,
    Inventory
}


public class JY_ItemInfo : MonoBehaviour
{
    private bool activeState;

    public GameObject itemInfo;

    public ItemState state = ItemState.Field;
    
    void Start()
    {
        itemInfo.SetActive(false);
        activeState = false;
    }

    bool stateInventory;
    void Update()
    {
        switch (state)
        {
            case ItemState.Field:
                    Feild();
                break;

            case ItemState.Grab:
                Grab();
                break;

            case ItemState.Inventory:
                Inventory();
                break;
        }

        /*if (BookVR.instance.InventoryOn == true && stateInventory == false)
        {
            stateInventory = true;
            ItemState state = ItemState.Inventory;
            //print("%R.Two ��ư ����%");
            //print(state);
        }*/
    }

    private void Feild()
    {
        itemInfo.SetActive(false);
        print(state);
    }

    private void Grab()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            print(state);
            print("Grab B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                print("Grab �����");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                print("Grab ������");
                activeState = true;
            }
        }
    }

    bool itemInfoActive;
    private void Inventory()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "Water")
        {
            print(state);
            //print("Inventory B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                print("Water������");
                activeState = false;
            }else
            {
                itemInfo.SetActive(false);
                print("Water�����");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "Branch")
        {
            print(state);
            //print("Inventory B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                print("Branch������");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                print("Branch�����");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "JamSotone")
        {
            print(state);
            //print("B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                print("JamSotone������");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                print("JamSotone�����");
                activeState = true;
            }
        }
    }
}
