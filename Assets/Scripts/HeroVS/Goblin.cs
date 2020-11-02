using Units;
using UnityEngine;

namespace HeroVS
{
    public class Goblin : Unit, IEnemy
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
        protected override int SpellDamage => baseSpellDamage;
        protected override int MaxHealth => maxHealth;
        protected override int Damage => baseDamage + weapon.weaponDamage;

        public void Reward()
        {
            if (!IsDead) return;
            FindObjectOfType<PlayerGold>().Gold += 7;
        }
    }
}