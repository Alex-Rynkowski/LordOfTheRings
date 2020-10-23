using Hud;
using Production;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    public class WoodPress : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI woodPressText;
        int _woodPressesOwned;

        void Start()
        {
            HudServices.UpdateTextInfo(woodPressText, "WD owned:", UnitName.WoodPress);
        }

        public void WoodPressPurchase()
        {
            HudServices.PurchaseUnit(UnitName.WoodPress, 1.1f, RType.Wood);
            HudServices.UpdateTextInfo(woodPressText, "WD owned:", UnitName.WoodPress);
        }
    }
}