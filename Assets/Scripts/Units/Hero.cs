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

            if (!CanAttack() || IsDead || Target == null) return;
            WaitingForPlayerAction = true;
        }

        public void Attack()
        {
            if (!WaitingForPlayerAction) return;
            WaitingForPlayerAction = false;
            DealDamage();
            foreach (var enemy in FindObjectsOfType<MonoBehaviour>().OfType<IReward>())
            {
                enemy.Reward();
            }
        }

        protected override void UpdateTarget()
        {
            foreach (var enemy in FindObjectsOfType<MonoBehaviour>())
            {
                if (!(enemy is IReward e)) continue;
                Target = enemy.gameObject;
                break;
            }
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