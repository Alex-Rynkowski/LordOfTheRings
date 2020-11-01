using System;
using UnityEngine;

namespace HeroVS
{
    public class Enemy : Unit
    {
        protected override GameObject Target { get; set; }

        void Awake()
        {
            Target = FindObjectOfType<Hero>().gameObject;
        }
    }
}