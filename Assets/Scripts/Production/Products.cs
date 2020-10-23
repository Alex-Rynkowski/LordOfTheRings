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

        public void UpdateProductInfo()
        {
            foreach (var product in products)
            {
                product.nameText.text = product.unitName.ToString();
                product.costText.text = $"Cost: {product.Cost.ToString()}";
                product.productionTimeText.text = $"Production time: {product.productionTime}s";
                product.productionAmountText.text = $"Production: {product.productionAmount}";
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