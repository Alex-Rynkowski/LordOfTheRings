using System;
using UnityEngine;

namespace HeroVS
{
    public class Hero : Unit
    {
        PlayerGold _playerGold;

        protected override void UpdateTarget()
        {
            if (FindObjectOfType<Enemy>() == null) return;
            Target = FindObjectOfType<Enemy>().gameObject;
        }

        protected override GameObject Target { get; set; }

        void Start()
        {
            _playerGold = FindObjectOfType<PlayerGold>();
            Health = MaxHealth;
        }

        void Update()
        {
            UpdateTarget();
            UpgradeHealth();
            if (IsDead)
            {
                Destroy(gameObject);
            }

            if (!CanAttack || IsDead || Target == null) return;
            DealDamage();
            print($"{this.name} is attacking dealing {Damage} damage with {Health} hp left");

            LastAttack = Time.time;
        }

        void UpgradeHealth()
        {
            if (_playerGold.Gold >= 50)
            {
                _playerGold.Gold -= 50;
                MaxHealth = (int) (MaxHealth * 1.1f);
                print(MaxHealth);
                Health = MaxHealth;
            }
        }
    }
}