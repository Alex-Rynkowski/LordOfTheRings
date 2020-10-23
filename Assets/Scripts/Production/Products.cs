using Units;
using UnityEngine;

namespace Production
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
                product.costText.text = $"Cost: {product.Cost.ToString()}$";
                product.productionTimeText.text = $"Prod time: {product.productionTime}s";
                product.productionAmountText.text = $"Prod amount: {product.productionAmount}x";
            }
        }

        public void UpdateProductInfo(UnitName productionUnitName, float increaseCostBy)
        {
            foreach (var product in products)
            {
                if (product.unitName == productionUnitName && product.UnitsOwned > 0)
                {
                    product.Cost = Mathf.RoundToInt(product.Cost * increaseCostBy);
                    product.costText.text = $"Cost: {product.Cost.ToString()}$";
                    break;
                }
            }
        }
    }
}