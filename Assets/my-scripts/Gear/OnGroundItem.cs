using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGroundItem : MonoBehaviour
{
    public enum ITEMTYPE
    {
        SWORD,
        SHIELD,
        LEFTSHOULDER,
        RIGHTSHOULDER,
        HELMET,
        BUCKLE,
        NONE
    }
    public enum ITEMQUALITY
    {
        JUNK,
        NORMAL,
        MAGIC,
        RARE,
        LEGENDARY,
        NONE

    }
    [Header("Instantiate Settings")]
    [Tooltip("Number in ıtem pool")] public int ItemNumber;
    private TextMesh ıtemName;
    [Header("Item Settings")]
    public bool RandomItemQuality;
    public string NameOfTheItem;
    public ITEMTYPE ItemType = ITEMTYPE.NONE;
    public ITEMQUALITY ItemQuality = ITEMQUALITY.NONE;
    private Color color;

    private void Start()
    {
        RandomQuality();
        SetItemQuality();
        SetItemName();
    }
    void RandomQuality()
    {
        if (RandomItemQuality)
        {
            ItemQuality = (ITEMQUALITY)Random.Range(0, 4);
        }
    }
    void SetItemName()
    {
        ıtemName = GetComponentInChildren<TextMesh>();
        ıtemName.text = NameOfTheItem;
        ıtemName.color = color;
    }
    public void SetItemQuality()
    {
        switch (ItemQuality)
        {
            case ITEMQUALITY.JUNK:
                color = Color.grey;
                break;
            case ITEMQUALITY.NORMAL:
                color = Color.white;
                break;
            case ITEMQUALITY.MAGIC:
                color = Color.blue;
                break;
            case ITEMQUALITY.RARE:
                color = Color.yellow;
                break;
            case ITEMQUALITY.LEGENDARY:
                color = new Color(255 / 255, 140 / 255, 0, 1.0f);//Orange
                break;
            case ITEMQUALITY.NONE:
                color = Color.white;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //EquipItemScript EquipItem = other.gameObject.GetComponent<EquipItemScript>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        GameObject BagpackObject = player.GetComponent<EquipItemScript>().BagPackPanel;

        InventoryManager inventory = BagpackObject.GetComponent<InventoryManager>();

        //Add item to inventory

        if (other.gameObject.tag == "Player")
        {
            // Equip it as you pick it up on ground

            GameObject clone = null;

            if (ItemType == ITEMTYPE.SWORD)
            {
                // EquipItem.EquipRightHandWith(Instantiate(ItemPool.instance.SwordList[ItemNumber]));
                clone = Instantiate(InventoryItemsPool.instance.SwordImages[ItemNumber]);
            }
            else if (ItemType == ITEMTYPE.SHIELD)
            {
                // EquipItem.EquipLeftHandWith(Instantiate(ItemPool.instance.ShieldList[ItemNumber]));
                clone = Instantiate(InventoryItemsPool.instance.ShieldImages[ItemNumber]);
            }
            else if (ItemType == ITEMTYPE.RIGHTSHOULDER)
            {
                // EquipItem.EquipRightShoulderWith(Instantiate(ItemPool.instance.ShoulderRightList[ItemNumber]));
                // EquipItem.EquipLeftShoulderWith(Instantiate(ItemPool.instance.ShoulderRightList[ItemNumber]));
                clone = Instantiate(InventoryItemsPool.instance.ShoulderImages[ItemNumber]);
            }
            else if (ItemType == ITEMTYPE.HELMET)
            {
                // EquipItem.EquipHeadWith(Instantiate(ItemPool.instance.HelmetList[ItemNumber]));
                clone = Instantiate(InventoryItemsPool.instance.HelmetImages[ItemNumber]);
            }
            else if (ItemType == ITEMTYPE.BUCKLE)
            {
               // EquipItem.EquipBeltWith(Instantiate(ItemPool.instance.BuckleList[ItemNumber]));
                clone = Instantiate(InventoryItemsPool.instance.BuckleImages[ItemNumber]);
            }
            else
            {
                Debug.Log("Nothing Selected");
            }

            inventory.AddItem(clone);

            //ItemAttributes itemAttributes = clone.GetComponent<ItemAttributes>();



            if (inventory.GetItem)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
