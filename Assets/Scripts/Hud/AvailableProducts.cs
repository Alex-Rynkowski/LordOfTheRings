using System;
using UnityEngine;

namespace Hud
{
    public class AvailableProducts : MonoBehaviour
    {
        public ProductUnits[] products;


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

        public void UpdateProductInfo(int arrayPosition, float increaseCostBy)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (i == arrayPosition)
                {
                    products[i].Cost =
                        Mathf.RoundToInt(products[i].Cost * increaseCostBy);
                    products[i].costText.text = $"Cost: {products[i].Cost}$";
                    break;
                }
            }
        }
    }
}