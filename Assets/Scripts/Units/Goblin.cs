using System;
using Hud;
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
            this.Target = FindObjectOfType<Hero>().gameObject;
        }

        protected override void UnitSetup()
        {
            this.maxHealth = this.MaxHealth;
            this.Health = this.MaxHealth;
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth => this.maxHealth;

        public void Reward()
        {
            if (!this.IsDead) return;
            FindObjectOfType<PlayerGold>().Gold += 7;
            FindObjectOfType<FloatingGoldText>().SpawnGoldText(7);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            FindObjectOfType<Target>().PlayerTarget = gameObject;
        }
    }
}