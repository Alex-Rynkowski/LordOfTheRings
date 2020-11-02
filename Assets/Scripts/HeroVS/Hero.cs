using System.Linq;
using UnityEngine;

namespace HeroVS
{
    public class Hero : Unit, IStats
    {
        int _strength = 10;
        int _intelligence = 10;
        int _vitality = 10;

        protected override void Start()
        {
            UnitSetup();
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
            foreach (var enemy in FindObjectsOfType<MonoBehaviour>().OfType<IEnemy>())
            {
                enemy.Reward();
            }
        }

        protected override void UpdateTarget()
        {
            foreach (var enemy in FindObjectsOfType<MonoBehaviour>())
            {
                if (enemy is IEnemy e)
                {
                    Target = enemy.gameObject;
                    break;
                }
            }
        }

        protected override void UnitSetup()
        {
            maxHealth = MaxHealth;
            baseDamage = Damage;
            Health = MaxHealth;
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth => maxHealth + (Vitality / 2);

        protected override int Damage
        {
            get
            {
                switch (weapon.skillType)
                {
                    case SkillType.Physical:
                        return (Strength / 10) + weapon.weaponDamage;
                    case SkillType.Magical:
                        return (Intelligence / 10) + weapon.weaponDamage;
                    case SkillType.PhysicalAndMagical:
                        return ((Strength / 10) + weapon.weaponDamage) + ((Intelligence / 10) + weapon.weaponDamage);
                    default:
                        return 0;
                }
            }
        }

        public int Strength
        {
            get => PlayerPrefs.GetInt("Strength", _strength);
            set => PlayerPrefs.SetInt("Strength", value);
        }

        public int Vitality
        {
            get => PlayerPrefs.GetInt("Vitality", _vitality);
            set
            {
                PlayerPrefs.SetInt("Vitality", value);
                Health = MaxHealth;
            }
        }

        public int Intelligence
        {
            get => PlayerPrefs.GetInt("Intelligence", _intelligence);
            set => PlayerPrefs.SetInt("Intelligence", value);
        }
    }
}