using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Saving_System;

namespace Hud
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldText;
        [SerializeField] int playerGold;

        public int Gold
        {
            get => playerGold;
            set => playerGold = value;
        }

        void Start()
        {
            GoldText();
        }

        void Update()
        {
            GoldText();
            if (Input.GetMouseButtonDown(0))
            {
                EventSystem.current.IsPointerOverGameObject();
                Gold += 5;
                GoldText();
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

        public void Save()
        {
            SaveSystem.Save(this);
        }

        public void Load()
        {
            PlayerData data = SaveSystem.Load();

            Gold = data._gold;
        }
    }
}