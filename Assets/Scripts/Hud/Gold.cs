using System;
using TMPro;
using UnityEngine;

namespace Hud
{
    public class Gold : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldText;
        [SerializeField] int startingGold;

        public int UpdateGold
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
            startingGold = PlayerPrefs.GetInt("Gold", UpdateGold);
        }

        void OnDestroy()
        {
            startingGold = UpdateGold;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                UpdateGold += 5;
            }
        }
    }
}