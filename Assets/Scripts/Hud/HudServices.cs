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

        public static void ProductInfo()
        {
            foreach (var product in Object.FindObjectOfType<Hud>().products)
            {
                product.nameText.text = product.name.ToString();
                product.costText.text = $"Cost: {product.Cost}$";
                product.productionsTimeText.text = $"Production time: {product.productionTime}s";
                product.productionAmountText.text = $"Production: {product.productionAmount}x";
            }
        }
    }
}