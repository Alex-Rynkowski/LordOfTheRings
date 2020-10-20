using TMPro;
using UnityEngine;

namespace Hud
{
    public class GoldPress : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldPressText;
        [SerializeField] TextMeshProUGUI goldPressCostText;
        [SerializeField] int goldPressCost;

        int _goldPressesOwned;

        public int GoldPressesOwned
        {
            get => _goldPressesOwned;
            set
            {
                _goldPressesOwned = value;
                goldPressText.text = $"Goldpresses owned: {value}";
            }
        }
        void Start()
        {
            goldPressCostText.text = $"Cost: {goldPressCost}";
        }

        public void GoldPressIncrement()
        {
            if (GetComponent<Gold>().UpdateGold < goldPressCost) return;

            GoldPressesOwned += 1;
            GetComponent<Gold>().UpdateGold -= goldPressCost;
        }
    }
}