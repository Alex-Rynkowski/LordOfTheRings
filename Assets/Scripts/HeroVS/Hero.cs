using System;
using UnityEngine;

namespace HeroVS
{
    public class Hero : Unit
    {
        protected override GameObject Target { get; set; }

        void Awake()
        {
            Target = FindObjectOfType<Enemy>().gameObject;
        }
    }
}
