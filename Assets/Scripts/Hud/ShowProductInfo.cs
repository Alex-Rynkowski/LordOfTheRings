using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    public class ShowProductInfo : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] GameObject infoField;

        bool _shouldShowInfoFields;

        public bool DoShowProductInfo
        {
            get => _shouldShowInfoFields;
            set
            {
                _shouldShowInfoFields = value;
                infoField.SetActive(value);
            }
        }

        void Start()
        {
            DoShowProductInfo = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (DoShowProductInfo)
            {
                DoShowProductInfo = false;
                return;
            }

            DoShowProductInfo = true;
        }
    }
}