using System;
using UnityEngine;

namespace Hud
{
    public class AvailableProducts : MonoBehaviour
    {
        public Product[] products;


        void Start()
        {
            UpdateProductInfo();
        }

        public void UpdateProductInfo()
        {
            foreach (var product in products)
            {
                product.nameText.text = product.name.ToString();
                product.costText.text = $"Cost: {product.Cost}$";
                product.productionTimeText.text = $"Production time: {product.productionTime}s";
                product.productionAmountText.text = $"Production: {product.productionAmount}x";
            }
        }
    }
}