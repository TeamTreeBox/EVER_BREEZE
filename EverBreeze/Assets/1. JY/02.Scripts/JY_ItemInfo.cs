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
    public GameObject waterInfo;

    public ItemState state = ItemState.Field;
    
    void Start()
    {
        waterInfo.SetActive(false);
    }

    public ItemState State
    {
        get => state;
        set
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
        }
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

        if (BookVR.instance.InventoryOn == true && stateInventory == false)
        {
            stateInventory = true;
            ItemState state = ItemState.Inventory;
            print("%R.Two 버튼 누름%");
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

    public RaycastHit hit;
    float MaxDistance = 15f;

    bool isInfoOn;

    private void Inventory()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch) && isInfoOn == false)
        {
            print("%아이템 정보%");
            isInfoOn = true;
            waterInfo.SetActive(true);
        }
    }
}
