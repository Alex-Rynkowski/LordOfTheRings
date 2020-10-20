using System;
using TMPro;
using UnityEngine;

namespace Hud
{
    public class GoldPress : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldPressText;
        [SerializeField] TextMeshProUGUI goldPressCostText;
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
//            goldPressCostText.text = $"Cost: {products[0].cost}";
        }

        void OnDestroy()
        {
            PlayerPrefs.SetInt("GoldPress", GoldPressesOwned);
        }

        // public void GoldPressIncrement()
        // {
        //     if (GetComponent<Gold>().UpdateGold < products[0].cost) return;
        //
        //     GoldPressesOwned += 1;
        //     GetComponent<Gold>().UpdateGold -= products[0].cost;
        // }
    }
}