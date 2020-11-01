using System;
using UnityEngine;

namespace HeroVS
{
    public class Enemy : Unit
    {
        [SerializeField] int goldReward;

        protected override void UpdateTarget()
        {
            Target = FindObjectOfType<Hero>().gameObject;
        }

        protected override GameObject Target { get; set; }

        void Start()
        {
            UpdateTarget();
        }

        void Update()
        {
            if (IsDead)
            {
                Reward();
                Destroy(gameObject);
            }

            if (!CanAttack || IsDead || Target == null) return;
            DealDamage();
            print($"{this.name} is attacking dealing {damage} damage with {Health} hp left");

            LastAttack = Time.time;
        }

        void Reward()
        {
            FindObjectOfType<PlayerGold>().Gold += goldReward;
        }
    }
}