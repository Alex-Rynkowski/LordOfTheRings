using System.Collections.Generic;
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

        public static void UpdateProductInfo()
        {
            foreach (var product in Object.FindObjectOfType<Hud>().products)
            {
                product.nameText.text = product.name.ToString();
                product.costText.text = $"Cost: {product.Cost}$";
                product.productionsTimeText.text = $"Production time: {product.productionTime}s";
                product.productionAmountText.text = $"Production: {product.productionAmount}x";
            }
        }

        public static void UpdateProductInfo(int arrayPosition, float increaseCostBy)
        {
            var product = Object.FindObjectOfType<Hud>();
            product.products[arrayPosition].Cost =
                Mathf.RoundToInt(product.products[arrayPosition].Cost * increaseCostBy);
            product.products[arrayPosition].costText.text = $"Cost: {product.products[arrayPosition].Cost}$";
        }
        
    }
}