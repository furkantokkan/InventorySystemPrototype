using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public static int Strength = 0;
    public static int Dexterity = 0;
    public static int Intelligence = 0;

    public CharacterType characterType;

    private void Start()
    {
        InitializeCharacters(characterType);    
    }
    public void InitializeCharacters(CharacterType type)
    {
        switch (type)
        {
            case CharacterType.Warrior:
                Strength = 10;
                Dexterity = 5;
                Intelligence = 5;
                break;
            case CharacterType.Assasin:
                Strength = 5;
                Dexterity = 10;
                Intelligence = 5;
                break;
            case CharacterType.Archer:
                Strength = 5;
                Dexterity = 5;
                Intelligence = 10;
                break;
            default:
                break;
        }
    }
}
