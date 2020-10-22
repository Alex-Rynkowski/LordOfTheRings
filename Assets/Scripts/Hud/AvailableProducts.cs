using System;
using UnityEngine;

namespace Hud
{
    public class AvailableProducts : MonoBehaviour
    {
        public ProductionUnits[] products;


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

        public void UpdateProductInfo(Names productionUnitName, float increaseCostBy)
        {
            foreach (var product in products)
            {
                if (product.name == productionUnitName && product.UnitsOwned > 0)
                {
                    product.Cost = Mathf.RoundToInt(product.Cost * increaseCostBy);
                    product.costText.text = $"Cost: {product.Cost}$";
                    break;    
                }
            }
        }
    }
}