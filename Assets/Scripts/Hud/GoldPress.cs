using System;
using TMPro;
using UnityEngine;

namespace Hud
{
    public class GoldPress : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldPressText;
        [SerializeField] TextMeshProUGUI goldPressCostText;
        [SerializeField] int goldPressCost;

        int _goldPressesOwned;

        public int GoldPressesOwned
        {
            get => _goldPressesOwned;
            set
            {
                _goldPressesOwned = value;
                PlayerPrefs.SetInt("GoldPress", value);
                goldPressText.text = $"Goldpresses owned: {value}";
            }
        }

        void Start()
        {
            GoldPressesOwned = PlayerPrefs.GetInt("GoldPress", GoldPressesOwned);
            goldPressCostText.text = $"Cost: {goldPressCost}";
        }

        void OnDestroy()
        {
            PlayerPrefs.SetInt("GoldPress", GoldPressesOwned);
        }

        public void GoldPressIncrement()
        {
            if (GetComponent<Gold>().UpdateGold < goldPressCost) return;

            GoldPressesOwned += 1;
            GetComponent<Gold>().UpdateGold -= goldPressCost;
        }
    }
}