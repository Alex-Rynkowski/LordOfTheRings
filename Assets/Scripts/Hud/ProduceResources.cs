using UnityEngine;

namespace Hud
{
    public class ProduceResources : MonoBehaviour
    {
        float _lastGoldIncrement;
        float _lastWoodIncrement;
        public bool GoldProduceTimer => Time.time - _lastGoldIncrement < FindObjectOfType<AvailableProducts>().products[0].productionTime;

        bool WoodProduceTimer => Time.time - _lastWoodIncrement < FindObjectOfType<AvailableProducts>().products[1].productionTime;

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
            GetComponent<Gold>().CurrentGold += GetComponent<GoldPress>().GoldPressesOwned +
                                                FindObjectOfType<AvailableProducts>().products[0].productionAmount;
            _lastGoldIncrement = Time.time;
        }

        void ProduceWood()
        {
            GetComponent<Wood>().CurrentWood += GetComponent<WoodPress>().WoodPressesOwned +
                                                FindObjectOfType<AvailableProducts>().products[1].productionAmount;
            _lastWoodIncrement = Time.time;

        }
    }
}