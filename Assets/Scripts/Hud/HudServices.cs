using TMPro;
using UnityEngine;

namespace Hud
{
    public static class HudServices
    {
        public static void HideProductInfo()
        {
            foreach (var showProductInfo in Object.FindObjectsOfType<ShowProductInfo>())
            {
                showProductInfo.DoShowProductInfo = false;
            }
        }

        public static void UpdateTextInfo(TextMeshProUGUI textToUpdate, string text, Names names)
        {
            foreach (var product in Object.FindObjectOfType<AvailableProducts>().products)
            {
                if (product.name == names)
                {
                    //PlayerPrefs.GetInt(product.name.ToString(), product.UnitsOwned);
                    textToUpdate.text = $"{text} {product.UnitsOwned}";
                }
            }
            
        }
    }
}