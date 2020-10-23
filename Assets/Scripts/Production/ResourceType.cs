using Hud;
using TMPro;
using UnityEngine;

namespace Production
{
    public class ResourceType : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI resourceText;
        public RType resourceType;
        public int startingResourceAmount;

        public int CurrentResource
        {
            get => startingResourceAmount;
            set
            {
                startingResourceAmount = value;
                PlayerPrefs.SetInt(resourceType.ToString(), value);
                resourceText.text = $"{resourceType.ToString()}: {value}";
            }
        }

        void Start()
        {
            CurrentResource = PlayerPrefs.GetInt(resourceType.ToString(), CurrentResource);
        }
    }
}