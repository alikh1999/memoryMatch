using System;
using Gameplay.Card;
using UnityEngine;
using UnityEngine.UI;

public class NumberCardContentView : MonoBehaviour 
{
    [SerializeField]
    private Text _text;

    private void Start()
    {
        UpdateView(GetComponent<MonoCard>().Card.Content);
    }

    private void UpdateView(CardContent c)
    {
        Debug.Log($"UpdateView  {((CardNumberContent)c).Number}");
        if (c is CardNumberContent n)
            _text.text = n.Number.ToString();
    }
}