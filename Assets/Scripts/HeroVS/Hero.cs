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
            DealPhysicalDamage();
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
        protected override int MaxHealth => PlayerPrefs.GetInt("MaxHealth", maxHealth + (Vitality / 2));

        protected override int Damage => PlayerPrefs.GetInt("Damage", (Strength / 10) + weapon.weaponDamage);

        protected override int SpellDamage => PlayerPrefs.GetInt("Intelligence", (Intelligence / 10) + weapon.weaponDamage);

        public int Strength
        {
            get => PlayerPrefs.GetInt("Strength", _strength);
            set => PlayerPrefs.SetInt("Strength", value);
        }

        public int Vitality
        {
            get => PlayerPrefs.GetInt("Vitality", _vitality);
            set => PlayerPrefs.SetInt("Vitality", value);
        }

        public int Intelligence
        {
            get => PlayerPrefs.GetInt("Intelligence", _intelligence);
            set => PlayerPrefs.SetInt("Intelligence", value);
        }
    }
}