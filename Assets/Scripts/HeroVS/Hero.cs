using System;
using UnityEngine;

namespace HeroVS
{
    public class Hero : Unit
    {
        protected override void UpdateTarget()
        {
            if (FindObjectOfType<Enemy>() == null) return;
            Target = FindObjectOfType<Enemy>().gameObject;
        }

        protected override GameObject Target { get; set; }
    }
}