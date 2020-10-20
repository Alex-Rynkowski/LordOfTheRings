using TMPro;
using UnityEngine;

namespace Hud
{
    public class Wood : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI woodText;
        [SerializeField] int startingWood;

        public int CurrentWood
        {
            get => startingWood;
            set
            {
                startingWood = value;
                PlayerPrefs.SetInt("Wood", value);
                woodText.text = $"Wood: {value}";
            }
        }

        void Start()
        {
            startingWood = PlayerPrefs.GetInt("Wood", CurrentWood);
        }

        void OnDestroy()
        {
            startingWood = CurrentWood;
        }
    }
}