using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeroVS
{
    public class Upgrades : MonoBehaviour
    {
        readonly HashSet<IStats> _stats = new HashSet<IStats>();
        void Start()
        {
            foreach (var mono in FindObjectsOfType<MonoBehaviour>())
            {
                if (mono is IStats stat)
                {
                    _stats.Add(stat);
                }
            }
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