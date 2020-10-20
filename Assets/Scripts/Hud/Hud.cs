using System;
using TMPro;
using UnityEngine;

namespace Hud
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldText;
        [SerializeField] int playerGold;

        int Gold
        {
            get => playerGold;
            set => playerGold = value;
        }

        void Start()
        {
            GoldText();
        }

        void GoldText()
        {
            goldText.text = $"Gold: {Gold}";
        }

        public void IncrementGold(int goldToIncrement)
        {
            Gold += 5;
            GoldText();
        }
    }
}