using TMPro;
using UnityEngine;

namespace Hud
{
    [System.Serializable]
    public class Product
    {
        [Header("Name attributes")] 
        public TextMeshProUGUI nameText;
        public Names name;
        
        [Header("Cost attributes")]
        public TextMeshProUGUI costText;
        public int cost;
        
        [Header("Production Time attribute")]
        public TextMeshProUGUI productionsTimeText;
        public float productionTime;
        
        [Header("Production Amount attribute")]
        public TextMeshProUGUI productionAmountText;
        public int productionAmount;
    }

    public enum Names
    {
        GoldPress,
        WoodPress
    }
}
