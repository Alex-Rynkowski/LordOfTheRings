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
        protected override void UnitSetup()
        {
            maxHealth = MaxHealth;
            Health = MaxHealth;
        }

        public void Reward()
        {
            if (!IsDead) return;
            FindObjectOfType<PlayerGold>().Gold += 10;
        }
    }
}