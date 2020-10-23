using Hud;
using TMPro;
using Units;
using UnityEngine;

namespace Production
{
    [System.Serializable]
    public class ProductionUnits
    {
        public RType rType;
        public UnitName unitName;
        public ResourceType resourceType;
        
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

        public float productionTime;
        public int productionAmount;

        public TextMeshProUGUI nameText;
        public TextMeshProUGUI costText;
        public TextMeshProUGUI productionTimeText;
        public TextMeshProUGUI productionAmountText;
    }
}