using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeroVS
{
    public class PlayerGold : MonoBehaviour
    {
        [SerializeField] int gold;
        [SerializeField] Text goldText;

        public int Gold
        {
            get => gold;
            set => gold = value;
        }

        void Update()
        {
            goldText.text = gold.ToString();
        }
    }
}