using System;
using UnityEngine;

namespace HeroVS
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected int damage = 5;
        [SerializeField] protected int health = 100;
        [SerializeField] protected float attackSpeed;
        [SerializeField] GameObject target;
        float _lastAttack;
        protected abstract void UpdateTarget();

        protected abstract GameObject Target { get; set; }
        bool CanAttack => Time.time - _lastAttack > attackSpeed;
        bool TargetHasDied => Health <= 0;

        int Health
        {
            get => health;
            set => health = Mathf.Clamp(value, 0, int.MaxValue);
        }

        void Start()
        {
            UpdateTarget();
        }

        void Update()
        {
            UpdateTarget();
            if (TargetHasDied)
            {
                Reward();
                Destroy(gameObject);
            }

            if (!CanAttack || TargetHasDied || Target == null) return;
            DealDamage();
            print($"{this.name} is attacking dealing {damage} damage with {Health} hp left");

            _lastAttack = Time.time;
        }

        void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= damage;
        }

        void Reward()
        {
            if (TargetHasDied)
            {
                FindObjectOfType<PlayerGold>().Gold += 7;
            }
        }
    }
}