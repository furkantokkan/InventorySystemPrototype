using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    public static ItemPool instance { get; private set; }

    [Header("Sword Item List")]
    public GameObject[] SwordList;
    [Header("Shield Item List")]
    public GameObject[] ShieldList;
    [Header("Shoulder Item List")]
    public GameObject[] ShoulderLeftList;
    public GameObject[] ShoulderRightList;
    [Header("Helmet Item List")]
    public GameObject[] HelmetList;
    [Header("Buckle Item List")]
    public GameObject[] BuckleList;

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
