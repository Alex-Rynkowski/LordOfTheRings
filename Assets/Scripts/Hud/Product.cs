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
        [SerializeField] int _cost;

        public int Cost
        {
            get => PlayerPrefs.GetInt("Cost", _cost);
            set
            {
                _cost = value;
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
}