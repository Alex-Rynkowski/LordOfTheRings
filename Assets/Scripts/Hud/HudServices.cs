using Production;
using TMPro;
using Units;
using UnityEngine;
using UnityEngine.EventSystems;

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

        public static void UpdateTextInfo(TextMeshProUGUI textToUpdate, string text, UnitName unitName)
        {
            foreach (var product in Object.FindObjectOfType<Products>().products)
            {
                if (product.unitName == unitName)
                {
                    textToUpdate.text = $"{text} {product.UnitsOwned}";
                }
            }
        }

        public static void PurchaseUnit(UnitName productionUnitName, float increaseCost, RType resourceType)
        {
            foreach (var product in Object.FindObjectOfType<Products>().products)
            {
                if (product.unitName != productionUnitName) continue;
                if (product.rType != resourceType) continue;


                if (product.resourceType.CurrentResource < product.Cost) return;

                product.UnitsOwned += 1;
                product.resourceType.CurrentResource -= product.Cost;

                Object.FindObjectOfType<Products>().UpdateProductInfo(productionUnitName, increaseCost);
            }

            HideProductInfo();
        }
    }
}