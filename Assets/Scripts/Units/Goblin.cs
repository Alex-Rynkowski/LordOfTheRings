using System;
using Player_Specific;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    public class Goblin : Unit, IReward, IPointerClickHandler
    {
        public void DamageOnTap(int dmg)
        {
            Health -= dmg;
        }

        protected override void UpdateTarget()
        {
            Target = FindObjectOfType<Hero>().gameObject;
        }

        protected override void UnitSetup()
        {
            maxHealth = MaxHealth;
            Health = MaxHealth;
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth => maxHealth;

        public void Reward()
        {
            if (!IsDead) return;
            FindObjectOfType<PlayerGold>().Gold += 7;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            FindObjectOfType<Target>().PlayerTarget = gameObject;
        }
    }
}