using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Content : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Button reselector;
    [SerializeField] List<Row> rows;

    [SerializeField] WordManager wordManager;

    [SerializeField] TextMeshProUGUI messageText;
    Animator messageAnimator;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(UpdateContent);
        inputField.onSubmit.AddListener(Submit);

        messageAnimator = messageText.GetComponent<Animator>();
    }

    public void UpdateContent(string txt)
    {
        rows[index].UpdateText(txt);
    }
    bool UpdateState()
    {
        var states = wordManager.GetStates(inputField.text);
        rows[index].UpdateState(states);
        foreach (var state in states)
        {
            if (state != Cell.State.Correct)
                return false;
        }

        return true;
    }
    public void Submit(string txt)
    {
        reselector.Select();
        inputField.Select();
        if (inputField.text.Length < rows[index].cells.Count)
        {
            messageText.text = "Kelime 5 Harfli Olmalı";
            messageAnimator.SetTrigger("Play");
            return;
        }
        if (!wordManager.wordList.Contains(inputField.text))
        {
            messageText.text = "Kelime Bulunamadı";
            messageAnimator.SetTrigger("Play");
            return;
        }
        if (UpdateState())
        {
            messageText.text = "Kazandın";
            messageAnimator.SetTrigger("Play");
            inputField.enabled = false;
            return;
        }
        index++;
        if (index == rows.Count)
        {
            messageText.text = "Kaybettin";
            messageAnimator.SetTrigger("Play");
            inputField.enabled = false;
            return;
        }
        inputField.text = "";
    }
}
