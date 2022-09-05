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
                    //print(state);
                break;

            case ItemState.Grab:
                Grab();
                print(state);
                break;

            case ItemState.Inventory:
                //Inventory();
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
    }

    private void Grab()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            print("B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("�����");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                //print("������");
                activeState = true;
            }
        }
    }

    bool itemInfoActive;
    private void Inventory()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "WaterBall")
        {
            //print("B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("Water������");
                activeState = false;
            }else
            {
                itemInfo.SetActive(false);
                //print("Water�����");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "Branch")
        {
            //print("B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("Branch������");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                //print("Branch�����");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "JamSotone")
        {
            //print("B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("JamSotone������");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
               // print("JamSotone�����");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "JingleBell")
        {
            //print("B��ư ����");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("JamSotone������");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
               // print("JamSotone�����");
                activeState = true;
            }
        }
    }
}
