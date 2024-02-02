using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] itemSlot; // 0 - 11
    private bool FreeSpace;
    public bool addItem(GameObject obj)
    {
        // we need to get the image to add to the inventory
        // we need to figure out if there is an empty slot in the backpack
        // if there isn't any empty slot, we return false
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].transform.childCount == 0) // if we dont have child
            {
                obj.transform.SetParent(itemSlot[i].transform);
                FreeSpace = true;
                return true;
            }
        }
        // we may want a message to say the backpacs if Full
        FreeSpace = false;
        return false;
    }

    public bool GetItem
    {
        get
        {
           return FreeSpace;
        }
    }
 
 
}
