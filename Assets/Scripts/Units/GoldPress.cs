using System;
using Hud;
using Production;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
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