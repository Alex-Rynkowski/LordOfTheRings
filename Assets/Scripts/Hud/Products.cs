using System;
using UnityEngine;

namespace Hud
{
    public class Products : MonoBehaviour
    {
        public ProductionUnits[] products;


        void Start()
        {
            UpdateProductInfo();
        }

       void UpdateProductInfo()
        {
            foreach (var product in products)
            {
                product.nameText.text = product.unitName.ToString();
                product.costText.text = $"Cost: {product.Cost}$";
                product.productionTimeText.text = $"Production time: {product.productionTime}s";
                product.productionAmountText.text = $"Production: {product.productionAmount}x";
            }
        }

        public void UpdateProductInfo(UnitName productionUnitUnitName, float increaseCostBy)
        {
            foreach (var product in products)
            {
                if (product.unitName == productionUnitUnitName && product.UnitsOwned > 0)
                {
                    product.Cost = Mathf.RoundToInt(product.Cost * increaseCostBy);
                    product.costText.text = $"Cost: {product.Cost}$";
                    break;    
                }
            }
        }
    }
}