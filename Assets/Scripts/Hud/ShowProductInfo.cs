using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    public class ShowProductInfo : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] GameObject infoField;

        public bool DoShowProductInfo { get; set; }

        void Start()
        {
            infoField.SetActive(DoShowProductInfo = false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (DoShowProductInfo)
            {
                infoField.SetActive(DoShowProductInfo = false);
                return;
            }

            infoField.SetActive(DoShowProductInfo = true);
        }
    }
}