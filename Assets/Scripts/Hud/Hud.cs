using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    public class Hud : MonoBehaviour
    {
        
        [SerializeField] TextMeshProUGUI goldPressText;
        
        [SerializeField] TextMeshProUGUI goldPressCostText;
        [SerializeField] int goldPressCost;
        [SerializeField] float productionTime;
        [SerializeField] int productionAmount;
        float _lastGoldIncrement;

        public int GoldPressesOwned { get; set; }

        int GoldPressCost
        {
            get => goldPressCost;
        }

        bool GoldIncrementTimer => Time.time - this._lastGoldIncrement < productionTime;

        void Start()
        {
            GoldPressText();
        }

        void Update()
        {
            GoldPressText();

            if (!GoldIncrementTimer)
            {
                GetComponent<Gold>().UpdateGold += GoldPressesOwned + productionAmount;
                this._lastGoldIncrement = Time.time;
            }

            if (Input.GetMouseButtonDown(0))
            {
                EventSystem.current.IsPointerOverGameObject();
                GetComponent<Gold>().UpdateGold += 5;
            }
        }

        void GoldPressText()
        {
            goldPressText.text = $"Goldpresses owned: {GoldPressesOwned}";
        }

        void GoldPressCostText()
        {
            goldPressCostText.text = $"Cost: {GoldPressCost}";
        }

        public void GoldPress()
        {
            if (GetComponent<Gold>().UpdateGold < GoldPressCost) return;

            GoldPressesOwned += 1;
            GetComponent<Gold>().UpdateGold -= GoldPressCost;
        }
    }
}