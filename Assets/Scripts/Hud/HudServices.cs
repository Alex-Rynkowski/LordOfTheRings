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

        

        public static void UpdateProductInfo(int arrayPosition, float increaseCostBy)
        {
            var product = Object.FindObjectOfType<AvailableProducts>();
            product.products[arrayPosition].Cost =
                Mathf.RoundToInt(product.products[arrayPosition].Cost * increaseCostBy);
            product.products[arrayPosition].costText.text = $"Cost: {product.products[arrayPosition].Cost}$";
        }
        
    }
}