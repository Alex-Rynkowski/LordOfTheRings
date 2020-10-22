using TMPro;
using UnityEngine;

namespace Hud
{
    public class GoldPress : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI goldPressText;
        int _goldPressesOwned;

        void Start()
        {
            HudServices.UpdateTextInfo(goldPressText, $"GD owned:", UnitName.GoldPress);
        }
        
        public void GoldPressPurchase()
        {
            HudServices.PurchaseUnit(UnitName.GoldPress, 2, RType.Gold);
            HudServices.UpdateTextInfo(goldPressText, $"GD owned:", UnitName.GoldPress);
        }
    }
}