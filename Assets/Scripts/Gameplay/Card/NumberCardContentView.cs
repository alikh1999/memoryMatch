using System;
using Gameplay.Core;
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
        if (c is CardNumberContent n)
            _text.text = n.Number.ToString();
    }
}