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
        protected override int MaxHealth => maxHealth;

        protected override int Damage
        {
            get
            {
                switch (weapon.skillType)
                {
                    case SkillType.Physical:
                        return baseDamage + weapon.weaponDamage;
                    case SkillType.Magical:
                        return baseSpellDamage + weapon.spellDamage;
                    default:
                        return 0;
                }
            }
        }

        public void Reward()
        {
            if (!IsDead) return;
            FindObjectOfType<PlayerGold>().Gold += 7;
        }
    }
}