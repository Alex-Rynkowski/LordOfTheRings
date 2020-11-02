using System;
using UnityEngine;
using UnityEngine.UI;

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

        protected override int MaxHealth
        {
            get => PlayerPrefs.GetInt("EnemyMaxHealth", maxHealth);
            set
            {
                PlayerPrefs.SetInt("EnemyMaxHealth", value);
                maxHealth = value;
            }
        }

        protected override int Damage
        {
            get => PlayerPrefs.GetInt("EnemyDamage", damage + weapon.weaponDamage);
            set
            {
                PlayerPrefs.SetInt("EnemyDamage", value);
                damage = value;
            }
        }
        protected override Text UnitName
        {
            get => unitName;
            set => unitName.text = value.ToString();
        }

        void Start()
        {
            maxHealth = MaxHealth;
            UnitName.text = this.name;
            UpdateTarget();
            Health = MaxHealth;
        }

        void Update()
        {
            UpdateHealthImage();
            if (IsDead)
            {
                Reward();
                Destroy(gameObject);
            }

            if (!CanAttack || IsDead || Target == null) return;
            DealDamage();
            print($"{this.name} is dealing {Damage} damage");

            LastAttack = Time.time;
        }

        void Reward()
        {
            FindObjectOfType<PlayerGold>().Gold += goldReward;
        }

        public void DamageOnTap(int dmg)
        {
            Health -= dmg;
        }
    }
}