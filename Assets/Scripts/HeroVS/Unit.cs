using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeroVS
{
    public abstract class Unit : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] protected Weapon weapon;

        [SerializeField] protected int damage = 5;
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

        protected abstract void UnitSetup();

        protected bool IsDead => Health <= 0;

        protected virtual int MaxHealth { get; set; }

        protected virtual int Damage { get; set; }

        protected int Health
        {
            get => _health;
            set => _health = Mathf.Clamp(value, 0, MaxHealth);
        }

        protected virtual void Update()
        {
            CanAttack();
        }

        protected bool CanAttack()
        {
            if (FindObjectOfType<Hero>().WaitingForPlayerAction) return false;

            _timeSinceLastAttack += Time.deltaTime;
            aTBGauge.fillAmount = _timeSinceLastAttack / weapon.weaponAttackSpeed;
            
            if (!(_timeSinceLastAttack >= weapon.weaponAttackSpeed)) return false;
            _timeSinceLastAttack -= weapon.weaponAttackSpeed;
            return true;

        }

        protected void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= Damage;
        }

        protected void UpdateHealthImage()
        {
            healthImage.fillAmount = (float) Health / MaxHealth;
        }

    }
}