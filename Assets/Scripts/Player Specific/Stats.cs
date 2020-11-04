using System;
using UnityEngine;

namespace Player_Specific
{
    [Serializable]
    public class Stats
    {
        [SerializeField] int strength;
        [SerializeField] int vitality;
        [SerializeField] int intelligence;
        
        public int Strength
        {
            get => PlayerPrefs.GetInt("Strength", strength);
            set => PlayerPrefs.SetInt("Strength", value);
        }

        public int Vitality
        {
            get => PlayerPrefs.GetInt("Vitality", vitality);
            set => PlayerPrefs.SetInt("Vitality", value);
        }

        public int Intelligence
        {
            get => PlayerPrefs.GetInt("Intelligence", intelligence);
            set => PlayerPrefs.SetInt("Intelligence", value);
        }
    }
}