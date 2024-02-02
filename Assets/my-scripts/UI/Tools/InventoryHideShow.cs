using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHideShow : MonoBehaviour
{
    public GameObject inventoryUI;

    public void HideInventory()
    {
        inventoryUI.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void ShowInventory()
    {
        inventoryUI.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
