using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Gameplay
{
    public class CardInteraction : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnInteacted;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnInteacted?.Invoke();
        }
    }
}
