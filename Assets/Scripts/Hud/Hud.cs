﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Saving_System;

namespace Hud
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldText;
        [SerializeField] TextMeshProUGUI goldPressText;
        [SerializeField] int playerGold;
        [SerializeField] TextMeshProUGUI goldPressCostText;
        [SerializeField] int goldPressCost;
        [SerializeField] float productionTime;
        [SerializeField] int productionAmount;
        float _lastGoldIncrement;

        public int Gold
        {
            get => playerGold;
            set => playerGold = value;
        }

        public int GoldPressesOwned { get; set; }

        int GoldPressCost
        {
            get => goldPressCost;
        }

        bool GoldIncrementTimer => Time.time - this._lastGoldIncrement < productionTime;

        void Start()
        {
            GoldText();
            GoldPressText();
        }

        void Update()
        {
            GoldText();
            GoldPressText();

            if (!GoldIncrementTimer)
            {
                Gold += GoldPressesOwned + productionAmount;
                this._lastGoldIncrement = Time.time;
            }

            if (Input.GetMouseButtonDown(0))
            {
                EventSystem.current.IsPointerOverGameObject();
                Gold += 5;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
        }

        void GoldText()
        {
            goldText.text = $"Gold: {Gold}";
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
            if (Gold < GoldPressCost) return;

            GoldPressesOwned += 1;
            Gold -= GoldPressCost;
        }

        public void Save()
        {
            SaveSystem.Save(this);
        }

        public void Load()
        {
            PlayerData data = SaveSystem.Load();

            Gold = data.gold;
            GoldPressesOwned = data.goldPresses;
        }
    }
}