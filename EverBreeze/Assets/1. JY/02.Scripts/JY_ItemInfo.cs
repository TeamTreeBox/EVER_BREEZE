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
            //print("%R.Two 버튼 누름%");
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
            print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("사라짐");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                //print("생겨짐");
                activeState = true;
            }
        }
    }

    bool itemInfoActive;
    private void Inventory()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "WaterBall")
        {
            //print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("Water생겨짐");
                activeState = false;
            }else
            {
                itemInfo.SetActive(false);
                //print("Water사라짐");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "Branch")
        {
            //print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("Branch생겨짐");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
                //print("Branch사라짐");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "JamSotone")
        {
            //print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("JamSotone생겨짐");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
               // print("JamSotone사라짐");
                activeState = true;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "JingleBell")
        {
            //print("B버튼 누름");
            if (activeState == true)
            {
                itemInfo.SetActive(true);
                //print("JamSotone생겨짐");
                activeState = false;
            }
            else
            {
                itemInfo.SetActive(false);
               // print("JamSotone사라짐");
                activeState = true;
            }
        }
    }
}
