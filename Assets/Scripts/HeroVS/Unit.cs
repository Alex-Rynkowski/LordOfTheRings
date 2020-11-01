using System;
using UnityEngine;

namespace HeroVS
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] int damage = 5;
        [SerializeField] int maxHealth = 100;
        [SerializeField] float attackSpeed;
        int _health;
        protected float LastAttack;
        protected abstract void UpdateTarget();
        protected abstract GameObject Target { get; set; }
        protected bool CanAttack => Time.time - LastAttack > attackSpeed;
        protected bool IsDead => Health <= 0;

        protected int MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

        protected int Health
        {
            get => _health;
            set => _health = Mathf.Clamp(value, 0, MaxHealth);
        }

        protected void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= Damage;
        }
    }
}