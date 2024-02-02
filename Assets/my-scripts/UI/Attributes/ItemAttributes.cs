using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ItemAttributes : MonoBehaviour
{
    public int Strength = 0;
    public int Dexterity = 0;
    public int Intelligence = 0;

    private void Awake()
    {
        if (Strength == 0 && !Application.isPlaying)
        {
            Strength = UnityEngine.Random.Range(1, 10);
            Dexterity = UnityEngine.Random.Range(1, 10);
            Intelligence = UnityEngine.Random.Range(1, 10);
        }
    }
}
