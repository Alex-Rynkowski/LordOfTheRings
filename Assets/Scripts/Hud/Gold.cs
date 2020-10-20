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
                goldText.text = $"Gold: {value}";
            } 
        }

        void Start()
        {
            UpdateGold = startingGold;
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