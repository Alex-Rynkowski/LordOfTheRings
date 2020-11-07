using System;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace Hud
{
    public class HealthUI : MonoBehaviour
    {
        public Image health;


        void Start()
        {
        }

        public void UpdateHealthImage(float value)
        {
            health.fillAmount = value;
        }
    }
}