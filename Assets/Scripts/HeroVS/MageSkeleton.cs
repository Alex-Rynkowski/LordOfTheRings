using UnityEngine;

namespace HeroVS
{
    public class MageSkeleton : Unit, IEnemy
    {
        protected override void UpdateTarget()
        {
            Target = FindObjectOfType<Hero>().gameObject;
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth => maxHealth;
        protected override int Damage => baseDamage + weapon.weaponDamage;
        protected override int SpellDamage => baseSpellDamage + weapon.spellDamage;
        protected override void UnitSetup()
        {
            maxHealth = MaxHealth;
            Health = MaxHealth;
        }

        public void Reward()
        {
            if(!IsDead) return;
            FindObjectOfType<PlayerGold>().Gold += 10;
        }
    }
}