using UnityEngine;
using UnityEngine.UI;

namespace Player_Specific
{
    public class Upgrades : MonoBehaviour
    {
        [SerializeField] Text vitalityText;
        [SerializeField] Text strengthText;
        [SerializeField] Text intelligenceText;
        readonly Stats _stats = new Stats();
        PlayerGold _playerGold;

        void Start()
        {
            _playerGold = FindObjectOfType<PlayerGold>();
            SetupText();
        }

        void SetupText()
        {
            vitalityText.text = $"Increase vitality by 10, 50 gold";
            strengthText.text = $"Increase strength by 10, 50 gold";
            intelligenceText.text = $"Increase intelligence by 10, 50 gold";
        }

        public void IncreaseVitality()
        {
            if (_playerGold.Gold < 50) return;
            _playerGold.Gold -= 50;
            _stats.Vitality += 10;
        }

        public void IncreaseStrength()
        {
            if (_playerGold.Gold < 50) return;
            _playerGold.Gold -= 50;
            _stats.Strength += 10;
        }

        public void IncreaseIntelligence()
        {
            if (_playerGold.Gold < 50) return;
            _playerGold.Gold -= 50;
            _stats.Strength += 10;
        }
    }
}