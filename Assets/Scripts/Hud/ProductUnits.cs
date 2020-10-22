using TMPro;
using UnityEngine;

namespace Hud
{
    [System.Serializable]
    public class ProductUnits
    {
        public UnitType unitType;
        
        [Header("Name attributes")] 
        public TextMeshProUGUI nameText;
        public Names name;
                          
        [Header("Cost attributes")] 
        public TextMeshProUGUI costText;
        [SerializeField] int cost;

        public int Cost
        {
            get => PlayerPrefs.GetInt("Cost", cost);
            set
            {
                cost = value;
                PlayerPrefs.SetInt("Cost", value);
            }
        }

        [Header("Production Time attribute")] 
        public TextMeshProUGUI productionTimeText;
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

    public enum UnitType
    {
        Gold,
        Wood
    }
}