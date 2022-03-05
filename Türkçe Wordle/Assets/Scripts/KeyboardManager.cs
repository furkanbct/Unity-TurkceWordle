using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Content content;
    public void KeyButton(string text)
    {
        if (inputField.IsActive())
        {
            if (text == "DEL")
            {
                string s = "";
                for (int i = 0; i < inputField.text.Length - 1; i++)
                {
                    s += inputField.text[i];
                }
                inputField.text = s;
                return;
            }
            if (text == "ENTER")
            {
                content.Submit(inputField.text.ToLower());
                return;
            }
            if (inputField.text.Length < 5)
            {
                inputField.text += text.ToLower();
            }
            inputField.text = inputField.text.ToLower();
        }
    }
}
