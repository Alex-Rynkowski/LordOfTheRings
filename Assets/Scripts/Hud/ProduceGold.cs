using UnityEngine;

namespace Hud
{
    public class ProduceGold : MonoBehaviour
    {
        float _lastGoldIncrement;
        bool GoldIncrementTimer => Time.time - this._lastGoldIncrement < GetComponent<Hud>().products[0].productionTime;

        void Update()
        {
            if (!GoldIncrementTimer)
            {
                GetComponent<Gold>().CurrentGold += GetComponent<GoldPress>().GoldPressesOwned +
                                                    GetComponent<Hud>().products[0].productionAmount;
                this._lastGoldIncrement = Time.time;
            }
        }
    }
}