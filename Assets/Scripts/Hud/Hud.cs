using UnityEngine;
using UnityEngine.EventSystems;

namespace Hud
{
    [RequireComponent(typeof(Gold)), RequireComponent(typeof(GoldPress))]
    public class Hud : MonoBehaviour
    {
        [SerializeField] float productionTime;
        [SerializeField] int productionAmount;
        float _lastGoldIncrement;

        bool GoldIncrementTimer => Time.time - this._lastGoldIncrement < productionTime;

        void Update()
        {
            if (!GoldIncrementTimer)
            {
                GetComponent<Gold>().UpdateGold += GetComponent<GoldPress>().GoldPressesOwned + productionAmount;
                this._lastGoldIncrement = Time.time;
            }

            if (Input.GetMouseButtonDown(0))
            {
                EventSystem.current.IsPointerOverGameObject();
                GetComponent<Gold>().UpdateGold += 5;
            }
        }
    }
}