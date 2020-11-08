using System;
using System.Linq;
using Equipment;
using Player_Specific;
using UnityEngine;
using UnityEngine.UI;

namespace Units
{
    public class Hero : Unit
    {
        [SerializeField] Stats stats;

        protected override void Start()
        {
            UnitSetup();
            aTBGauge.GetComponentInChildren<Text>().text = weapon.attackText;
        }


        protected override void Update()
        {
            this.UpdateHealthImage();
            this.UpdateTarget();
            if (IsDead)
            {
                Destroy(gameObject);
            }

            if (!CanAttack() || IsDead) return;
            WaitingForPlayerAction = true;
        }


        public void Attack()
        {
            if (!this.WaitingForPlayerAction || this.Target == null) return;
            this.WaitingForPlayerAction = false;
            this.DealDamage();
            this.aTBGauge.fillAmount = 0f;
            OnTargetDeath();
        }

        static void OnTargetDeath()
        {
            foreach (var enemy in FindObjectsOfType<MonoBehaviour>().OfType<IUnitDeath>())
            {
                enemy.OnDeath();
            }
        }

        protected override void UpdateTarget()
        {
            Target = FindObjectOfType<Target>().PlayerTarget;
        }

        protected override void UnitSetup()
        {
            maxHealth = MaxHealth;
            baseDamage = Damage;
            Health = MaxHealth;
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth => maxHealth + (stats.Vitality / 2);

        protected override int Damage
        {
            get
            {
                switch (weapon.skillType)
                {
                    case Weapon.SkillType.Physical:
                        return (stats.Strength / 10) + weapon.weaponDamage;
                    case Weapon.SkillType.Magical:
                        return (stats.Intelligence / 10) + weapon.weaponDamage;
                    case Weapon.SkillType.PhysicalAndMagical:
                        return ((stats.Strength / 10) + weapon.weaponDamage) + ((stats.Intelligence / 10) + weapon.weaponDamage);
                    default:
                        return 0;
                }
            }
        }
    }
}