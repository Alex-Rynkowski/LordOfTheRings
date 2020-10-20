using UnityEngine;

namespace Hud
{
    public class ProduceResources : MonoBehaviour
    {
        float _lastGoldIncrement;
        float _lastWoodIncrement;
        bool GoldIncrementTimer => Time.time - _lastGoldIncrement < GetComponent<Hud>().products[0].productionTime;

        bool WoodIncrementTimer => Time.time - _lastWoodIncrement < GetComponent<Hud>().products[1].productionTime;

        void Update()
        {
            if (!GoldIncrementTimer)
            {
                IncrementGold();
            }

            if (!WoodIncrementTimer)
            {
                IncrementWood();
            }
        }

        void IncrementGold()
        {
            GetComponent<Gold>().CurrentGold += GetComponent<GoldPress>().GoldPressesOwned +
                                                GetComponent<Hud>().products[0].productionAmount;
            _lastGoldIncrement = Time.time;
        }

        void IncrementWood()
        {
            GetComponent<Wood>().CurrentWood += GetComponent<WoodPress>().WoodPressesOwned +
                                                GetComponent<Hud>().products[1].productionAmount;
            _lastWoodIncrement = Time.time;
        }
    }
}