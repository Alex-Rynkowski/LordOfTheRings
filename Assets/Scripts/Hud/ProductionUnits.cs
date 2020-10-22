using TMPro;
using UnityEngine;

namespace Hud
{
    [System.Serializable]
    public class ProductionUnits
    {
        public RType rType;
        
        [Header("Name attributes")] 
        public TextMeshProUGUI nameText;
        public UnitName unitName;
        
        [Header("Cost attributes")] 
        public TextMeshProUGUI costText;
        [SerializeField] int cost;

        public int Cost
        {
            get => PlayerPrefs.GetInt(unitName + "1", cost);
            set
            {
                cost = value;
                PlayerPrefs.SetInt(unitName + "1", value);
            }
        }

        [Header("Units Owned")]
        int _unitsOwned;

        public int UnitsOwned
        {
            get => PlayerPrefs.GetInt(unitName.ToString(), _unitsOwned);
            set
            {
                _unitsOwned = value;
                PlayerPrefs.SetInt(unitName.ToString(), value);
            }
        }

        [Header("Production Time attribute")] 
        public TextMeshProUGUI productionTimeText;
        public float productionTime;

        [Header("Production Amount attribute")]
        public TextMeshProUGUI productionAmountText;
        public int productionAmount;

        public ResourceType resourceType;
    }
}