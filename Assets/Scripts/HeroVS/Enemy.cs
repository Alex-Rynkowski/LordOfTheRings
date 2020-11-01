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
            Health = MaxHealth;
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
            print($"{this.name} is attacking dealing {Damage} damage with {Health} hp left");

            LastAttack = Time.time;
        }

        void Reward()
        {
            FindObjectOfType<PlayerGold>().Gold += goldReward;
        }
    }
}