using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Label : MonoBehaviour
    {
        [SerializeField]
        private Text _text;

        public void SetText(string text)
            => _text.text = text;
    }
}
