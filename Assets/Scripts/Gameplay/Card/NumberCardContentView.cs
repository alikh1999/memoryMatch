using Gameplay.Card;
using UnityEngine;
using UnityEngine.UI;

public class NumberCardContentView : MonoBehaviour 
{
    [SerializeField]
    private Text _text;
    public void UpdateView(CardContent c)
    {
        if (c is CardNumberContent n)
            _text.text = n.Number.ToString();
    }
}