using System;
using TMPro;
using UnityEngine;

namespace Hud
{
    public class Gold : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldText;
        [SerializeField] int startingGold;

        public int CurrentGold
        {
            get => startingGold;
            set
            {
                startingGold = value;
                PlayerPrefs.SetInt("Gold", value);
                goldText.text = $"Gold: {value}";
            }
        }

        void Start()
        {
            startingGold = PlayerPrefs.GetInt("Gold", CurrentGold);
        }

        void OnDestroy()
        {
            startingGold = CurrentGold;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CurrentGold += 5;
            }
        }
    }
}