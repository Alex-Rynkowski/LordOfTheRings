﻿using TMPro;
using UnityEngine;

namespace Hud
{
    [RequireComponent(typeof(Wood))]
    public class WoodPress : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI woodPressText;
        int _woodPressesOwned;

        public int WoodPressesOwned
        {
            get => _woodPressesOwned;
            set
            {
                _woodPressesOwned = value;
                PlayerPrefs.SetInt("WoodPress", value);
                woodPressText.text = $"WD owned: {value}";
            }
        }

        void Start()
        {
            WoodPressesOwned = PlayerPrefs.GetInt("WoodPress", WoodPressesOwned);
        }

        void OnDestroy()
        {
            PlayerPrefs.SetInt("WoodPress", WoodPressesOwned);
        }

        public void WoodPressPurchase()
        {
            foreach (var product in GetComponent<Hud>().products)
            {
                if (product.name != Names.WoodPress) continue;

                HudServices.HideProductInfo();
                if (GetComponent<Wood>().CurrentWood < product.cost) return;

                WoodPressesOwned += 1;
                GetComponent<Wood>().CurrentWood -= product.cost;
            }
        }
    }
}