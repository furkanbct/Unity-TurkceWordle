using System.Net;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cell : MonoBehaviour
{
    public enum State { None, Fail, Exist, Correct }

    [Header("Colors")]
    [SerializeField] Color colorNone;
    [SerializeField] Color colorFail;
    [SerializeField] Color colorExist;
    [SerializeField] Color colorCorrect;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;

    public void UpdateText(char txt)
    {
        text.SetText(txt.ToString());
    }
    public void UpdateState(State state)
    {
        image.color = GetColor(state);
    }
    public Color GetColor(State state)
    {
        return state switch
        {
            State.None => colorNone,
            State.Fail => colorFail,
            State.Exist => colorExist,
            State.Correct => colorCorrect
        };
    }
}
