using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeroVS
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected int damage = 5;
        [SerializeField] protected int maxHealth = 100;
        [SerializeField] float attackSpeed;

        [SerializeField] Image healthImage;
        int _health;
        protected float LastAttack;
        protected abstract void UpdateTarget();
        protected abstract GameObject Target { get; set; }
        protected bool CanAttack => Time.time - LastAttack > attackSpeed;
        protected bool IsDead => Health <= 0;

        protected virtual int MaxHealth { get; set; }

        protected virtual int Damage { get; set; }

        protected int Health
        {
            get => _health;
            set => _health = Mathf.Clamp(value, 0, MaxHealth);
        }

        protected void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= Damage;
        }

        protected void UpdateHealthImage()
        {
            print((float) Health / MaxHealth + Health);
            healthImage.fillAmount = (float) Health / MaxHealth;
        }
    }
}