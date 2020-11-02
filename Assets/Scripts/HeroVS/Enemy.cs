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

        void Start()
        {
            maxHealth = MaxHealth; //just for the visual aspect
            
            unitName.text = this.name;
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