using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotEquipItem : MonoBehaviour
{
    private GameObject player;
    private EquipItemScript equipItem;
    private ItemSlot itemslot;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        equipItem = player.GetComponent<EquipItemScript>(); 
    }

    public void EquipItemOnRightHand()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        GameObject item = Instantiate(ItemPool.instance.SwordList[ItemSlot.slotItemNumber]);
        equipItem.EquipRightHandWith(item);
        ItemAttributes itemAttributes = item.gameObject.GetComponent<ItemAttributes>();
        SetItemAttributes(itemAttributes, true);
    }
    public void EquipItemOnLeftHand()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        GameObject item = Instantiate(ItemPool.instance.ShieldList[ItemSlot.slotItemNumber]);
        equipItem.EquipLeftHandWith(item);
        ItemAttributes itemAttributes = item.gameObject.GetComponent<ItemAttributes>();
        SetItemAttributes(itemAttributes, true);
    }
    public void EquipItemOnHead()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        GameObject item = Instantiate(ItemPool.instance.HelmetList[ItemSlot.slotItemNumber]);
        equipItem.EquipHeadWith(item);
        ItemAttributes itemAttributes = item.gameObject.GetComponent<ItemAttributes>();
        SetItemAttributes(itemAttributes, true);
    }
    public void EquipItemOnShoulders()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        GameObject item = Instantiate(ItemPool.instance.ShoulderRightList[ItemSlot.slotItemNumber]);
        GameObject item2 = Instantiate(ItemPool.instance.ShoulderLeftList[ItemSlot.slotItemNumber]);
        equipItem.EquipRightShoulderWith(item);
        equipItem.EquipLeftShoulderWith(item2);
        ItemAttributes itemAttributes = item.gameObject.GetComponent<ItemAttributes>();
        SetItemAttributes(itemAttributes, true);
    }
    public void EquipItemOnBelt()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        GameObject item = Instantiate(ItemPool.instance.BuckleList[ItemSlot.slotItemNumber]);
        equipItem.EquipBeltWith(item);
        ItemAttributes itemAttributes = item.gameObject.GetComponent<ItemAttributes>();
        SetItemAttributes(itemAttributes, true);
    }
    public void UnEquipHead()
    {
        
        SetItemAttributes(equipItem.HookHead.GetComponentInChildren<ItemAttributes>(), false);
        equipItem.UnEquipHead();
    }

    public void UnEquipRightHand()
    {
        SetItemAttributes(equipItem.HookRightHand.GetComponentInChildren<ItemAttributes>(), false);
        equipItem.UnEquipRightHand();
    }
    public void UnEquipLeftHand()
    {
        SetItemAttributes(equipItem.HookLeftArm.GetComponentInChildren<ItemAttributes>(), false);
        equipItem.UnEquipLeftHand();
    }
    public void UnEquipShoulders()
    {
        SetItemAttributes(equipItem.HookRightShoulder.GetComponentInChildren<ItemAttributes>(), false);
        equipItem.UnEquipLeftShoulder();
        equipItem.UnEquipRightShoulder();
    }
    public void UnEquipBelt()
    {
        SetItemAttributes(equipItem.HookBuckle.GetComponentInChildren<ItemAttributes>(), false);
        equipItem.UnEquipBelt();
    }

    public void SetItemAttributes(ItemAttributes item, bool add)
    {
        if (add)
        {
            PlayerAttributes.Strength += item.Strength;
            PlayerAttributes.Dexterity += item.Dexterity;
            PlayerAttributes.Intelligence += item.Intelligence;
        }
        else
        {
            PlayerAttributes.Strength -= item.Strength;
            PlayerAttributes.Dexterity -= item.Dexterity;
            PlayerAttributes.Intelligence -= item.Intelligence;
        }
    }
}
