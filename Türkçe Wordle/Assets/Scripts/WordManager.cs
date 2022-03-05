using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class WordManager : MonoBehaviour
{
    [SerializeField] string targetWord;

    public List<string> wordList = new List<string>();

    private void Start()
    {
        /* //Read words from file
        TextAsset text = Resources.Load<TextAsset>("words");
        var arrayString = text.text.Split('\n','\r');
        
        foreach (var line in arrayString)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                wordList.Add(line);
            }
        }
        */
        targetWord = wordList[Random.Range(0, wordList.Count)];
    }
    public List<Cell.State> GetStates(string txt)
    {
        var output = new List<Cell.State>();

        var target = targetWord.ToCharArray().ToList();
        var current = txt.ToCharArray().ToList();

        for (var i = 0; i < current.Count; i++)
        {
            if (target.Contains(current[i]))
            {
                bool charEqual = current[i] == target[i];
                output.Add(charEqual ? Cell.State.Correct : Cell.State.Exist);
            }
            else
            {
                output.Add(Cell.State.Fail);
            }
        }
        return output;
    }
}
