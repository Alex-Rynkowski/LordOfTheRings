using TMPro;
using UnityEngine;

namespace Hud
{
    [System.Serializable]
    public class ProductionUnits
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
            get => PlayerPrefs.GetInt(name + "1", cost);
            set
            {
                cost = value;
                PlayerPrefs.SetInt(name + "1", value);
            }
        }

        [Header("Units Owned")]
        int _unitsOwned;

        public int UnitsOwned
        {
            get => PlayerPrefs.GetInt(name.ToString(), _unitsOwned);
            set
            {
                _unitsOwned = value;
                PlayerPrefs.SetInt(name.ToString(), value);
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