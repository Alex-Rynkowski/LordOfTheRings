using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeroVS
{
    public abstract class Unit : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] protected Weapon weapon;

        [SerializeField] protected int baseDamage = 5;
        [SerializeField] protected int baseSpellDamage = 5;
        [SerializeField] protected int maxHealth = 100;

        [Header("UI")]
        [SerializeField] Image healthImage;

        [SerializeField] protected Text unitName;
        [SerializeField] protected Image aTBGauge;

        int _health;
        float _timeSinceLastAttack;

        protected bool WaitingForPlayerAction;

        protected abstract void UpdateTarget();
        protected abstract GameObject Target { get; set; }
        protected abstract int MaxHealth { get; }
        protected abstract int Damage { get; }
        protected abstract int SpellDamage { get; }
        protected abstract void UnitSetup();

        protected virtual void Start()
        {
            UnitSetup();
            UpdateTarget();
        }

        protected bool IsDead => Health <= 0;

        protected int Health
        {
            get => _health;
            set => _health = Mathf.Clamp(value, 0, MaxHealth);
        }

        protected virtual void Update()
        {
            UpdateHealthImage();
            if (IsDead)
            {
                //Reward();
                Destroy(gameObject);
            }

            if (!CanAttack() || IsDead || Target == null) return;
            DealPhysicalDamage();
        }

        protected bool CanAttack()
        {
            if (FindObjectOfType<Hero>().WaitingForPlayerAction || Target == null) return false;

            _timeSinceLastAttack += Time.deltaTime;
            aTBGauge.fillAmount = _timeSinceLastAttack / weapon.weaponAttackSpeed;

            if (!(_timeSinceLastAttack >= weapon.weaponAttackSpeed)) return false;
            _timeSinceLastAttack -= weapon.weaponAttackSpeed;
            return true;
        }

        protected void DealPhysicalDamage()
        {
            Target.GetComponent<Unit>().Health -= Damage;
        }

        protected void DealMagicalDamage()
        {
            Target.GetComponent<Unit>().Health -= SpellDamage;
        }

        protected void UpdateHealthImage()
        {
            healthImage.fillAmount = (float) Health / MaxHealth;
        }
    }
}