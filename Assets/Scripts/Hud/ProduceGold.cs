using UnityEngine;

namespace Hud
{
    public class ProduceGold : MonoBehaviour
    {
        [SerializeField] float productionTime;
        [SerializeField] int productionAmount;

        float _lastGoldIncrement;
        bool GoldIncrementTimer => Time.time - this._lastGoldIncrement < productionTime;

        void Update()
        {
            if (!GoldIncrementTimer)
            {
                GetComponent<Gold>().CurrentGold += GetComponent<GoldPress>().GoldPressesOwned + productionAmount;
                this._lastGoldIncrement = Time.time;
            }
        }
    }
}