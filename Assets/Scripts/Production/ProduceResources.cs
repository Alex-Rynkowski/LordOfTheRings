using UnityEngine;

namespace Hud
{
    public class ProduceResources : MonoBehaviour
    {
        float _lastGoldIncrement;
        float _lastWoodIncrement;

        public bool GoldProduceTimer =>
            Time.time - _lastGoldIncrement < FindObjectOfType<Products>().products[0].productionTime;

        bool WoodProduceTimer =>
            Time.time - _lastWoodIncrement < FindObjectOfType<Products>().products[1].productionTime;

        void Update()
        {
            if (!GoldProduceTimer)
            {
                ProduceGold();
            }

            if (!WoodProduceTimer)
            {
                ProduceWood();
            }
        }

        void ProduceGold()
        {
            foreach (var product in FindObjectOfType<Products>().products)
            {
                if (product.rType == RType.Gold && product.UnitsOwned > 0)
                {
                    product.resourceType.CurrentResource += product.UnitsOwned * product.productionAmount;
                }
            }

            _lastGoldIncrement = Time.time;
        }

        void ProduceWood()
        {
            foreach (var product in FindObjectOfType<Products>().products)
            {
                if (product.rType == RType.Wood && product.UnitsOwned > 0)
                {
                    product.resourceType.CurrentResource += product.UnitsOwned * product.productionAmount;
                }
            }

            _lastWoodIncrement = Time.time;
        }
    }
}