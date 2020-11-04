using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    public class ShowUpgrades : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] GameObject upgrades;

        public void OnPointerClick(PointerEventData eventData)
        {
            upgrades.SetActive(!upgrades.activeInHierarchy);
        }

        void Start()
        {
            upgrades.SetActive(false);
        }

        void Update()
        {
            if(!Input.GetMouseButtonDown(0)) return;
            if (EventSystem.current.currentSelectedGameObject) return;
            upgrades.SetActive(false);
        }
    }
}