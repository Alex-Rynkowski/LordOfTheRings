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

        protected abstract GameObject Target { get; set; }
        float _lastAttack;
        bool CanAttack => Time.time - _lastAttack > attackSpeed;

        int Health
        {
            get => health;
            set => health = Mathf.Clamp(value, 0, int.MaxValue);
        }

        void Start()
        {
            target = Target;
        }

        void Update()
        {
            if (!CanAttack) return;
            DealDamage();
            print($"{this.name} is attacking dealing {damage} damage with {Health} hp left");

            _lastAttack = Time.time;
        }

        void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= damage;
        }
    }
}