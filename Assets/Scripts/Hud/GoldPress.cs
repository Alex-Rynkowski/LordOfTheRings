using TMPro;
using UnityEngine;

namespace Hud
{
    public class GoldPress : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldPressText;
        int _goldPressesOwned;

        public int GoldPressesOwned
        {
            get => _goldPressesOwned;
            set
            {
                _goldPressesOwned = value;
                PlayerPrefs.SetInt("GoldPress", value);
                goldPressText.text = $"GD owned: {value}";
            }
        }

        void Start()
        {
            GoldPressesOwned = PlayerPrefs.GetInt("GoldPress", GoldPressesOwned);
        }

        void OnDestroy()
        {
            PlayerPrefs.SetInt("GoldPress", GoldPressesOwned);
        }

        public void GoldPressPurchase()
        {
            foreach (var product in FindObjectOfType<AvailableProducts>().products)
            {
                if (product.name != Names.GoldPress) continue;

                HudServices.HideProductInfo();
                if (GetComponent<Gold>().CurrentGold < product.Cost) return;

                GoldPressesOwned += 1;
                GetComponent<Gold>().CurrentGold -= product.Cost;
                HudServices.UpdateProductInfo(0, 2f);
            }
        }
    }
}