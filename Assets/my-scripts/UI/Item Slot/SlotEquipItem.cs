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
        equipItem.EquipRightHandWith(Instantiate(ItemPool.instance.SwordList[ItemSlot.slotItemNumber]));

    }
    public void EquipItemOnLeftHand()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        equipItem.EquipLeftHandWith(Instantiate(ItemPool.instance.ShieldList[ItemSlot.slotItemNumber]));

    }
    public void EquipItemOnHead()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        equipItem.EquipHeadWith(Instantiate(ItemPool.instance.HelmetList[ItemSlot.slotItemNumber]));

    }
    public void EquipItemOnShoulders()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        equipItem.EquipLeftShoulderWith(Instantiate(ItemPool.instance.ShoulderLeftList[ItemSlot.slotItemNumber]));
        equipItem.EquipRightShoulderWith(Instantiate(ItemPool.instance.ShoulderRightList[ItemSlot.slotItemNumber]));

    }
    public void EquipItemOnBelt()
    {
        //we want to remove any item on that slot and on the character (if any)
        //add the item to the player Character
        equipItem.EquipBeltWith(Instantiate(ItemPool.instance.BuckleList[ItemSlot.slotItemNumber]));

    }
    public void UnEquipHead()
    {
        equipItem.UnEquipHead();
    }
    public void UnEquipRightHand()
    {
        equipItem.UnEquipRightHand();
    }
    public void UnEquipLeftHand()
    {
        equipItem.UnEquipLeftHand();
    }
    public void UnEquipShoulders()
    {
        equipItem.UnEquipLeftShoulder();
        equipItem.UnEquipRightShoulder();
    }
    public void UnEquipBelt()
    {
        equipItem.UnEquipBelt();
    }
}
