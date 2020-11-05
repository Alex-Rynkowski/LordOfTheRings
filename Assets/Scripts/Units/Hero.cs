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
            UpdateHealthImage();
            UpdateTarget();
            if (IsDead)
            {
                Destroy(gameObject);
            }


            if (!CanAttack() || IsDead) return;
            WaitingForPlayerAction = true;
        }

        protected override float ATBGauge()
        {
            return aTBGauge.fillAmount = _timeSinceLastAttack / weapon.weaponAttackSpeed;
        }

        public void Attack()
        {
            if (!WaitingForPlayerAction || Target == null) return;
            WaitingForPlayerAction = false;
            DealDamage();
            aTBGauge.fillAmount = 0f;
            foreach (var enemy in FindObjectsOfType<MonoBehaviour>().OfType<IReward>())
            {
                enemy.Reward();
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
                    case SkillType.Physical:
                        return (stats.Strength / 10) + weapon.weaponDamage;
                    case SkillType.Magical:
                        return (stats.Intelligence / 10) + weapon.weaponDamage;
                    case SkillType.PhysicalAndMagical:
                        return ((stats.Strength / 10) + weapon.weaponDamage) + ((stats.Intelligence / 10) + weapon.weaponDamage);
                    default:
                        return 0;
                }
            }
        }
    }
}