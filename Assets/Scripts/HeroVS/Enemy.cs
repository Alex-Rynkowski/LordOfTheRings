using UnityEngine;

namespace HeroVS
{
    public class Enemy : Unit
    {
        [SerializeField] int goldReward;

        void Start()
        {
            UnitSetup();
            UpdateTarget();
        }

        protected override void Update()
        {
            UpdateHealthImage();
            if (IsDead)
            {
                Reward();
                Destroy(gameObject);
            }

            if (!CanAttack() || IsDead || Target == null) return;
            DealDamage();
        }

        void Reward()
        {
            FindObjectOfType<PlayerGold>().Gold += goldReward;
        }

        public void DamageOnTap(int dmg)
        {
            Health -= dmg;
        }

        protected override void UpdateTarget()
        {
            Target = FindObjectOfType<Hero>().gameObject;
        }

        protected override GameObject Target { get; set; }

        protected override void UnitSetup()
        {
            maxHealth = MaxHealth; //just for the visual aspect
            Health = MaxHealth;
            unitName.text = this.name;
        }

        protected override int MaxHealth => maxHealth;

        protected override int Damage => baseDamage + weapon.weaponDamage;
    }
}