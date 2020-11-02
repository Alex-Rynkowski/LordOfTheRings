using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeroVS
{
    public class PlayerGold : MonoBehaviour
    {
        [SerializeField] Text goldText;
        int _gold;

        public int Gold
        {
            get => PlayerPrefs.GetInt("Gold", _gold);
            set
            {
                PlayerPrefs.SetInt("Gold", value);
                goldText.text = Gold.ToString();
            }
        }

        void Start()
        {
            goldText.text = Gold.ToString();
        }
    }
}