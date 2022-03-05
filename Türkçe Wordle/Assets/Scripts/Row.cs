using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public List<Cell> cells;
    public void UpdateText(string text)
    {
        var charArray = text.ToCharArray();
        for (int i = 0; i < cells.Count; i++)
        {
            if (i < charArray.Length)
            {
                cells[i].UpdateText(charArray[i]);
            }
            else
            {
                cells[i].UpdateText(' ');
            }
        }
    }
    public void UpdateState(List<Cell.State> states)
    {
        for (int i = 0; i < states.Count; i++)
        {
            var cell = cells[i];
            var state = states[i];
            cell.UpdateState(state);
        }
    }
}
