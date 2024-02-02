using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //add this

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public ItemType allowedItemType;
    ItemType insideItemSlotType;
    SlotEquipItem ItemScript;
    GameObject itemBeginDragged;
    public bool isEquipAble = false;
    public static int slotItemNumber;
    public GameObject item
    {
        //the first child image to be drag
        get
        {
            if (transform.childCount != 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        if (item == null)
        {
            //this slot is empty, we can drow an item
            itemBeginDragged = DragAndDrop.draggedItem;
            ItemScript = itemBeginDragged.GetComponentInParent<SlotEquipItem>();
            if (ItemScript != null)
            {
                if (!isEquipAble)
                {
                    switch (itemBeginDragged.GetComponentInParent<ItemSlot>().allowedItemType)
                    {
                        case ItemType.ANY:
                            break;
                        case ItemType.WEAPON:
                            ItemScript.UnEquipRightHand();
                            break;
                        case ItemType.SHIELD:
                            ItemScript.UnEquipLeftHand();
                            break;
                        case ItemType.HELMET:
                            ItemScript.UnEquipHead();
                            break;
                        case ItemType.SHOULDERS:
                            ItemScript.UnEquipShoulders();
                            break;
                        case ItemType.BUCKLE:
                            ItemScript.UnEquipBelt();
                            break;
                        case ItemType.CONSUMABLE:
                            break;
                    }
                }

            }

            // we need item type of the item begin dragged
            ItemType draggedItemType = itemBeginDragged.GetComponent<DragAndDrop>().itemType;

            if (CorrectItemType(draggedItemType))
            {
                itemBeginDragged.transform.SetParent(this.transform);

                if (isEquipAble)
                {
                    this.ItemScript = GetComponent<SlotEquipItem>();
                    if (this.ItemScript != null)
                    {
                        switch (allowedItemType)
                        {
                            case ItemType.ANY:
                                break;
                            case ItemType.WEAPON:
                                this.ItemScript.EquipItemOnRightHand();
                                break;
                            case ItemType.SHIELD:
                                this.ItemScript.EquipItemOnLeftHand();
                                break;
                            case ItemType.HELMET:
                                this.ItemScript.EquipItemOnHead();
                                break;
                            case ItemType.SHOULDERS:
                                this.ItemScript.EquipItemOnShoulders();
                                break;
                            case ItemType.BUCKLE:
                                this.ItemScript.EquipItemOnBelt();
                                break;
                            case ItemType.CONSUMABLE:
                                break;
                            case ItemType.TRASH:
                                //Destroy the item
                                UnEquipItemBeginDragged();
                                Destroy(itemBeginDragged);
                                return;
                        }
                    }
                }
            }
        }
        else
        {
            // THIS IS THE CASE THERE IS ALREADY AN ITEM IN THE SLOT

            itemBeginDragged = DragAndDrop.draggedItem;
            if (allowedItemType != ItemType.TRASH)
            {
                insideItemSlotType = item.GetComponent<DragAndDrop>().itemType;
            }
            ItemType draggedItemType = itemBeginDragged.GetComponent<DragAndDrop>().itemType;

            // we need item type of the item begin dragged

            if (CorrectItemType(draggedItemType))
            {
                ItemScript = itemBeginDragged.GetComponentInParent<SlotEquipItem>();
                if (ItemScript != null)
                {
                    if (!isEquipAble)
                    {
                        switch (allowedItemType)
                        {

                            case ItemType.ANY:
                                if (draggedItemType == insideItemSlotType)
                                {
                                    slotItemNumber = item.GetComponent<DragAndDrop>().ItemNumber;
                                    switch (draggedItemType)
                                    {
                                        case ItemType.WEAPON:
                                            ItemScript.UnEquipRightHand();
                                            ItemScript.EquipItemOnRightHand();
                                            break;
                                        case ItemType.SHIELD:
                                            ItemScript.UnEquipLeftHand();
                                            ItemScript.EquipItemOnLeftHand();
                                            break;
                                        case ItemType.HELMET:
                                            ItemScript.UnEquipHead();
                                            ItemScript.EquipItemOnHead();
                                            break;
                                        case ItemType.SHOULDERS:
                                            ItemScript.UnEquipShoulders();
                                            ItemScript.EquipItemOnShoulders();
                                            break;
                                        case ItemType.BUCKLE:
                                            ItemScript.UnEquipBelt();
                                            ItemScript.EquipItemOnBelt();
                                            break;
                                        case ItemType.CONSUMABLE:
                                            break;

                                    }
                                }
                                break;
                            case ItemType.WEAPON:
                                ItemScript.UnEquipRightHand();
                                break;
                            case ItemType.SHIELD:
                                ItemScript.UnEquipLeftHand();
                                break;
                            case ItemType.HELMET:
                                ItemScript.UnEquipHead();
                                break;
                            case ItemType.SHOULDERS:
                                ItemScript.UnEquipShoulders();
                                break;
                            case ItemType.BUCKLE:
                                ItemScript.UnEquipBelt();
                                break;
                            case ItemType.CONSUMABLE:
                                break;
                        }
                    }

                }

                if (CorrectItemType(draggedItemType))
                {

                    if (isEquipAble)
                    {
                        this.ItemScript = GetComponent<SlotEquipItem>();
                        if (this.ItemScript != null)
                        {
                            switch (allowedItemType)
                            {
                                case ItemType.ANY:
                                    //just to be make sure we can be able to switch the item
                                    if (draggedItemType == insideItemSlotType)
                                    {
                                        slotItemNumber = item.GetComponent<DragAndDrop>().ItemNumber;
                                        switch (draggedItemType)
                                        {
                                            case ItemType.WEAPON:
                                                ItemScript.UnEquipRightHand();
                                                ItemScript.EquipItemOnRightHand();
                                                break;
                                            case ItemType.SHIELD:
                                                ItemScript.UnEquipLeftHand();
                                                ItemScript.EquipItemOnLeftHand();
                                                break;
                                            case ItemType.HELMET:
                                                ItemScript.UnEquipHead();
                                                ItemScript.EquipItemOnHead();
                                                break;
                                            case ItemType.SHOULDERS:
                                                ItemScript.UnEquipShoulders();
                                                ItemScript.EquipItemOnShoulders();
                                                break;
                                            case ItemType.BUCKLE:
                                                ItemScript.UnEquipBelt();
                                                ItemScript.EquipItemOnBelt();
                                                break;
                                            case ItemType.CONSUMABLE:
                                                break;

                                        }
                                    }
                                    break;
                                case ItemType.WEAPON:
                                    this.ItemScript.EquipItemOnRightHand();
                                    break;
                                case ItemType.SHIELD:
                                    this.ItemScript.EquipItemOnLeftHand();
                                    break;
                                case ItemType.HELMET:
                                    this.ItemScript.EquipItemOnHead();
                                    break;
                                case ItemType.SHOULDERS:
                                    this.ItemScript.EquipItemOnShoulders();
                                    break;
                                case ItemType.BUCKLE:
                                    this.ItemScript.EquipItemOnBelt();
                                    break;
                                case ItemType.CONSUMABLE:
                                    break;
                                case ItemType.TRASH:
                                    //Destroy the item
                                    UnEquipItemBeginDragged();
                                    Destroy(itemBeginDragged);
                                    return;
                            }
                        }
                    }
                }

                item.transform.SetParent(itemBeginDragged.transform.parent);
                itemBeginDragged.transform.SetParent(this.transform);
            }
        }

    }

    bool CorrectItemType(ItemType type)
    {
        if (allowedItemType == ItemType.ANY || allowedItemType == ItemType.TRASH)
        {
            if (item != null)
            {
                if (allowedItemType != ItemType.TRASH)
                {
                    insideItemSlotType = item.GetComponent<DragAndDrop>().itemType;
                }
                bool itemSlotEquipAble = itemBeginDragged.GetComponentInParent<ItemSlot>().isEquipAble;
                ItemType draggedItemType = itemBeginDragged.GetComponent<DragAndDrop>().itemType;

                if (draggedItemType != insideItemSlotType && itemSlotEquipAble && allowedItemType != ItemType.TRASH)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        else
        {
            if (allowedItemType == type)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    private void UnEquipItemBeginDragged()
    {
        itemBeginDragged = DragAndDrop.draggedItem;
        ItemType draggedItemType = itemBeginDragged.GetComponent<DragAndDrop>().itemType;
        ItemScript = itemBeginDragged.GetComponentInParent<SlotEquipItem>();
        if (ItemScript != null)
        {

            switch (draggedItemType)
            {
                case ItemType.WEAPON:
                    ItemScript.UnEquipRightHand();
                    break;
                case ItemType.SHIELD:
                    ItemScript.UnEquipLeftHand();
                    break;
                case ItemType.HELMET:
                    ItemScript.UnEquipHead();
                    break;
                case ItemType.SHOULDERS:
                    ItemScript.UnEquipShoulders();
                    break;
                case ItemType.BUCKLE:
                    ItemScript.UnEquipBelt();
                    break;
            }

        }

    }
}
