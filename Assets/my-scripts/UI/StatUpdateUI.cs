using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUpdateUI : MonoBehaviour
{
    [SerializeField] Text strengthTextField;
    [SerializeField] Text intellagenceTextField;
    [SerializeField] Text dexterityTextField;

    private void Update()
    {
        strengthTextField.text = "Strength: " + PlayerAttributes.Strength.ToString();
        intellagenceTextField.text = "Intellagance: " + PlayerAttributes.Intelligence.ToString();
        dexterityTextField.text = "Dexterity: " + PlayerAttributes.Dexterity.ToString();
    }
}
