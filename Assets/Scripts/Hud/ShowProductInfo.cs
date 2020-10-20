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
            HudServices.HideProductInfo();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            HudServices.HideProductInfo();

            DoShowProductInfo = true;
        }
    }
}