using UnityEngine;

namespace HeroVS
{
    public class Hero : Unit, IStats
    {
        int _strength = 10;
        int _intelligence = 10;
        int _vitality = 10;

        void Start()
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
        }

        protected override void UpdateTarget()
        {
            if (FindObjectOfType<Enemy>() == null) return;
            Target = FindObjectOfType<Enemy>().gameObject;
        }

        protected override void UnitSetup()
        {
            unitName.text = this.name;
            maxHealth = MaxHealth;
            baseDamage = Damage;
            Health = MaxHealth;
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth => PlayerPrefs.GetInt("MaxHealth", maxHealth + (Vitality / 2));

        protected override int Damage => PlayerPrefs.GetInt("Damage", (Strength / 10) + weapon.weaponDamage);

        protected override int SpellDamage => PlayerPrefs.GetInt("Intelligence", (_intelligence / 10) + weapon.weaponDamage);

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