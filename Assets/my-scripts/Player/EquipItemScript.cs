using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EquipItemScript : MonoBehaviour
{
    [Header("Referances")]
    public GameObject InventoryPanel;
    public GameObject BagPackPanel;
    [Header("Settings")]
    [Range(1, 2)] public int ItemSet;
    public bool startWithSword;
    public bool startWithLeftShoulder;
    public bool startWithRightShoulder;
    public bool startWithShield;
    public bool startWithHelmet;
    public bool startWithHook;
    [Header("Bones")]
    public GameObject HookRightHand;
    public GameObject HookLeftArm;
    public GameObject HookHead;
    public GameObject HookLeftShoulder;
    public GameObject HookRightShoulder;
    public GameObject HookBuckle;


    private void Start()
    {
        StartingItemSelector();
    }
    private void Update()
    {

    }
    public void EquipRightHandWith(GameObject weapon)
    {
        UnEquipRightHand();

        weapon.transform.SetParent(HookRightHand.transform);
        Vector3 offset = weapon.GetComponent<HookScript>().positionOffset;

        weapon.transform.position = HookRightHand.transform.position;
        weapon.transform.rotation = HookRightHand.transform.rotation;
        weapon.transform.localPosition = Vector3.zero + offset;


        Vector3 rotationOffset = weapon.GetComponent<HookScript>().RotationOffset;
        weapon.transform.Rotate(rotationOffset);
    }
    public void EquipLeftHandWith(GameObject shield)
    {
        UnEquipLeftHand();

        shield.transform.SetParent(HookLeftArm.transform);

        Vector3 offset = shield.GetComponent<HookScript>().positionOffset;

        shield.transform.position = HookLeftArm.transform.position;
        shield.transform.rotation = HookLeftArm.transform.rotation;
        shield.transform.localPosition = Vector3.zero + offset;

        Vector3 rotationOffset = shield.GetComponent<HookScript>().RotationOffset;
        shield.transform.Rotate(rotationOffset);

    }
    public void EquipHeadWith(GameObject helmet)
    {
        UnEquipHead();

        helmet.transform.SetParent(HookHead.transform);

        Vector3 offset = helmet.GetComponent<HookScript>().positionOffset;

        helmet.transform.position = HookHead.transform.position;
        helmet.transform.rotation = HookHead.transform.rotation;
        helmet.transform.localPosition = Vector3.zero + offset;

        Vector3 rotationOffset = helmet.GetComponent<HookScript>().RotationOffset;
        helmet.transform.Rotate(rotationOffset);
    }
    public void EquipLeftShoulderWith(GameObject leftShoulder)
    {
        UnEquipLeftShoulder();

        leftShoulder.transform.SetParent(HookLeftShoulder.transform);

        Vector3 offset = leftShoulder.GetComponent<HookScript>().positionOffset;

        leftShoulder.transform.position = HookLeftShoulder.transform.position;
        leftShoulder.transform.rotation = HookLeftShoulder.transform.rotation;
        leftShoulder.transform.localPosition = Vector3.zero + offset;

        Vector3 rotationOffest = leftShoulder.GetComponent<HookScript>().RotationOffset;
        leftShoulder.transform.Rotate(rotationOffest);
    }
    public void EquipRightShoulderWith(GameObject rightShoulder)
    {
        UnEquipRightShoulder();

        rightShoulder.transform.SetParent(HookRightShoulder.transform);

        Vector3 offset = rightShoulder.GetComponent<HookScript>().positionOffset;

        rightShoulder.transform.position = HookRightShoulder.transform.position;
        rightShoulder.transform.rotation = HookRightShoulder.transform.rotation;
        rightShoulder.transform.localPosition = Vector3.zero + offset;

        Vector3 rotationOffest = rightShoulder.GetComponent<HookScript>().RotationOffset;
        rightShoulder.transform.Rotate(rotationOffest);
    }
    public void EquipBeltWith(GameObject buckle)
    {
        UnEquipBelt();

        buckle.transform.SetParent(HookBuckle.transform);

        Vector3 offset = buckle.GetComponent<HookScript>().positionOffset;

        buckle.transform.position = HookBuckle.transform.position;
        buckle.transform.rotation = HookBuckle.transform.rotation;
        buckle.transform.localPosition = Vector3.zero + offset;

        Vector3 rotationOffest = buckle.GetComponent<HookScript>().RotationOffset;
        buckle.transform.Rotate(rotationOffest);
    }

    public void StartingItemSelector()
    {
        if (startWithSword)
        {
            if (ItemSet == 1)
            {
                GameObject swordClone = Instantiate(ItemPool.instance.SwordList[0]);
                EquipRightHandWith(swordClone);
            }
            else if (ItemSet == 2)
            {
                GameObject swordClone = Instantiate(ItemPool.instance.SwordList[1]);
                EquipRightHandWith(swordClone);
            }


        }
        if (startWithShield)
        {
            if (ItemSet == 1)
            {
                GameObject ShieldClone = Instantiate(ItemPool.instance.ShieldList[0]);
                EquipLeftHandWith(ShieldClone);
            }
            else if (ItemSet == 2)
            {
                GameObject ShieldClone = Instantiate(ItemPool.instance.ShieldList[1]);
                EquipLeftHandWith(ShieldClone);
            }


        }
        if (startWithHelmet)
        {
            if (ItemSet == 1)
            {
                GameObject HelmetClone = Instantiate(ItemPool.instance.HelmetList[0]);
                EquipHeadWith(HelmetClone);
            }
            else if (ItemSet == 2)
            {
                GameObject HelmetClone = Instantiate(ItemPool.instance.HelmetList[1]);
                EquipHeadWith(HelmetClone);
            }


        }

        if (startWithLeftShoulder)
        {
            if (ItemSet == 1)
            {
                GameObject LeftShoulderClone = Instantiate(ItemPool.instance.ShoulderLeftList[0]);
                EquipLeftShoulderWith(LeftShoulderClone);
            }
            else if (ItemSet == 2)
            {
                GameObject LeftShoulderClone = Instantiate(ItemPool.instance.ShoulderLeftList[1]);
                EquipLeftShoulderWith(LeftShoulderClone);
            }


        }
        if (startWithRightShoulder)
        {
            if (ItemSet == 1)
            {
                GameObject RightShoulderClone = Instantiate(ItemPool.instance.ShoulderRightList[0]);
                EquipRightShoulderWith(RightShoulderClone);
            }
            else if (ItemSet == 2)
            {
                GameObject RightShoulderClone = Instantiate(ItemPool.instance.ShoulderRightList[1]);
                EquipRightShoulderWith(RightShoulderClone);
            }


        }
        if (startWithHook)
        {
            if (ItemSet == 1)
            {
                GameObject HookClone = Instantiate(ItemPool.instance.BuckleList[0]);
                EquipBeltWith(HookClone);
            }
            else if (ItemSet == 2)
            {
                GameObject HookClone = Instantiate(ItemPool.instance.BuckleList[1]);
                EquipBeltWith(HookClone);
            }

        }
    }

    public void UnEquipRightHand()
    {
        for (int i = 0; i < HookRightHand.transform.childCount; i++)
        {
            Destroy(HookRightHand.transform.GetChild(i).gameObject);
        }
    }
    public void UnEquipLeftHand()
    {
        for (int i = 0; i < HookLeftArm.transform.childCount; i++)
        {
            Destroy(HookLeftArm.transform.GetChild(i).gameObject);
        }
    }
    public void UnEquipHead()
    {
        for (int i = 0; i < HookHead.transform.childCount; i++)
        {
            Destroy(HookHead.transform.GetChild(i).gameObject);
        }
    }
    public void UnEquipLeftShoulder()
    {
        for (int i = 0; i < HookLeftShoulder.transform.childCount; i++)
        {
            Destroy(HookLeftShoulder.transform.GetChild(i).gameObject);
        }
    }
    public void UnEquipRightShoulder()
    {
        for (int i = 0; i < HookRightShoulder.transform.childCount; i++)
        {
            Destroy(HookRightShoulder.transform.GetChild(i).gameObject);
        }
    }
    public void UnEquipBelt()
    {
        for (int i = 0; i < HookBuckle.transform.childCount; i++)
        {
            Destroy(HookBuckle.transform.GetChild(i).gameObject);
        }
    }
}
