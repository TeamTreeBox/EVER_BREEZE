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

    public GameObject waterInfo;

    public ItemState state = ItemState.Field;
    
    void Start()
    {
        waterInfo.SetActive(false);
        activeState = true;
    }

    public ItemState State
    {
        get => state;
        set
        {
            switch (state)
            {
                case ItemState.Field:
                    if (activeState = false)
                    {
                        Feild();
                    }
                    break;

                case ItemState.Grab:
                    Grab();
                    break;

                case ItemState.Inventory:
                    Inventory();
                    break;
            }
        }
    }
    bool stateInventory;
    void Update()
    {
        switch (state)
        {
            case ItemState.Field:
                if (activeState = false)
                {
                    Feild();
                }
                break;

            case ItemState.Grab:
                Grab();
                break;

            case ItemState.Inventory:
                Inventory();
                break;
        }

        if (BookVR.instance.InventoryOn == true && stateInventory == false)
        {
            stateInventory = true;
            ItemState state = ItemState.Inventory;
            //print("%R.Two 버튼 누름%");
            print(state);
        }
    }

    private void Feild()
    {
        waterInfo.SetActive(false);
    }

    private void Grab()
    {

    }

    bool itemInfoActive;
    private void Inventory()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && gameObject.tag == "Water")
        {
            print("B버튼 누름");
            if (activeState == true)
            {
                waterInfo.SetActive(false);
                print("사라짐");
                activeState = false;
            }else
            {
                waterInfo.SetActive(true);
                print("생겨짐");
                activeState = true;
            }
        }
    }
}
