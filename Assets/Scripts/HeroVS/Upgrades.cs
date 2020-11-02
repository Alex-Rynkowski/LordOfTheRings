using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HeroVS
{
    public class Upgrades : MonoBehaviour
    {
        [SerializeField] Text vitalityText;
        [SerializeField] Text strengthText;
        [SerializeField] Text intelligenceText;
        readonly HashSet<IStats> _stats = new HashSet<IStats>();
        void Start()
        {
            SetupText();
            foreach (var mono in FindObjectsOfType<MonoBehaviour>())
            {
                if (mono is IStats stat)
                {
                    _stats.Add(stat);
                }
            }
        }

        void SetupText()
        {
            vitalityText.text = $"Increase vitality by 10, 50 gold";
            strengthText.text = $"Increase strength by 10, 50 gold";
            intelligenceText.text = $"Increase intelligence by 10, 50 gold";
        }

        public void IncreaseVitality()
        {
            foreach (var stat in _stats)
            {
                stat.Vitality += 10;
            }
        }

        public void IncreaseStrength()
        {
            foreach (var stat in _stats)
            {
                stat.Strength += 10;
            }
        }

        public void IncreaseIntelligence()
        {
            foreach (var stat in _stats)
            {
                stat.Strength += 10;
            }
        }
    }
}