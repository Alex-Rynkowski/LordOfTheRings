using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HeroVS
{
    public class LoadUpgrades : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] GameObject upgrades;

        public void OnPointerClick(PointerEventData eventData)
        {
            upgrades.SetActive(!upgrades.activeInHierarchy);
        }

        void Update()
        {
            if(!Input.GetMouseButtonDown(0)) return;
            if (EventSystem.current.currentSelectedGameObject == this.gameObject) return;
            upgrades.SetActive(false);
        }
    }
}