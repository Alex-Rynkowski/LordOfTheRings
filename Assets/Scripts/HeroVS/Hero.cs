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

        void Update()
        {
            UpdateTarget();
            if (IsDead)
            {
                Destroy(gameObject);
            }

            if (!CanAttack || IsDead || Target == null) return;
            DealDamage();
            print($"{this.name} is attacking dealing {damage} damage with {Health} hp left");

            LastAttack = Time.time;
        }
    }
}