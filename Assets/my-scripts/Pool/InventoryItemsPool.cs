using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemsPool : MonoBehaviour
{
    public static InventoryItemsPool instance { get; private set; }

    [Header("Sword Images")]
    public GameObject[] SwordImages;
    [Header("Shield Images")]
    public GameObject[] ShieldImages;
    [Header("Shoulder Images")]
    public GameObject[] ShoulderImages;
    [Header("Helmet Images")]
    public GameObject[] HelmetImages;
    [Header("Buckle Images")]
    public GameObject[] BuckleImages;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
