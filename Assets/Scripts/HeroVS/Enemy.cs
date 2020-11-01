using System;
using UnityEngine;

namespace HeroVS
{
    public class Enemy : Unit
    {
        protected override void UpdateTarget()
        {
            Target = FindObjectOfType<Hero>().gameObject;
        }

        protected override GameObject Target { get; set; }
    }
}