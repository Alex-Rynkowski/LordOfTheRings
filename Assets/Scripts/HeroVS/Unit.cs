using System;
using UnityEngine;

namespace HeroVS
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected int damage = 5;
        [SerializeField] protected int health = 100;
        [SerializeField] protected float attackSpeed;
        protected float LastAttack;
        protected abstract void UpdateTarget();
        protected abstract GameObject Target { get; set; }
        protected bool CanAttack => Time.time - LastAttack > attackSpeed;
        protected bool IsDead => Health <= 0;

        protected int Health
        {
            get => health;
            set => health = Mathf.Clamp(value, 0, int.MaxValue);
        }

        protected void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= damage;
        }


    }
}