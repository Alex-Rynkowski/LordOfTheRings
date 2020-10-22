using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    public class PurchaseProduct : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            foreach (var product in FindObjectOfType<AvailableProducts>().products)
            {
                if (product.name != Names.GoldPress) continue;

                HideInfoField();
                if (FindObjectOfType<Gold>().CurrentGold < product.Cost) return;

                //product.UnitsOwned += 1;
                //FindObjectOfType<GoldPress>().GoldPressesOwned += 1;
                //FindObjectOfType<Gold>().CurrentGold -= product.Cost;
            }
        }

        static void HideInfoField()
        {
            foreach (var showProductInfo in FindObjectsOfType<ShowProductInfo>())
            {
                showProductInfo.DoShowProductInfo = false;
            }
        }
    }
}