using System;
using Equipment;
using Hud;
using UnityEngine;
using UnityEngine.UI;

namespace Units
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
        protected abstract void UnitSetup();
        protected bool IsDead => this.Health <= 0;

        protected virtual int Damage
        {
            get
            {
                switch (this.weapon.skillType)
                {
                    case Weapon.SkillType.Physical:
                        return this.baseDamage + this.weapon.weaponDamage;
                    case Weapon.SkillType.Magical:
                        return this.baseSpellDamage + this.weapon.spellDamage;
                    case Weapon.SkillType.PhysicalAndMagical:
                        return (this.baseSpellDamage + this.weapon.spellDamage) + (this.baseDamage + this.weapon.weaponDamage);
                    default:
                        return 0;
                }
            }
        }

        protected int Health
        {
            get => this._health;
            set
            {
                this._health = Mathf.Clamp(value, 0, this.MaxHealth);
                this.unitName.text = $"{this.name} {this.Health}/{this.MaxHealth}";
            }
        }

        protected virtual void Start()
        {
            this.UnitSetup();
            this.UpdateTarget();
            this.aTBGauge.GetComponentInChildren<Text>().text = this.weapon.attackText;
        }

        protected virtual void Update()
        {
            if (this.Target == null) return;
            var target = FindObjectOfType<Target>();
            if (target.PlayerTarget != null && target.PlayerTarget == this.gameObject)
            {
                target.UpdateTargetInfo(this.UpdateHealthImage(), ATBGauge(), this.name, this.Damage.ToString(), this.weapon.attackText);
                target.UpdateTargetImage(this.GetComponentInChildren<UnitImageReference>().GetComponent<Image>().sprite);
            }

            this.UpdateHealthImage();

            if (this.IsDead)
            {
                var tar = FindObjectOfType<Target>();
                tar.PlayerTarget = null;
                tar.ShouldShowTarget(false);
            }

            if (!this.CanAttack() || this.IsDead || this.Target == null || FindObjectOfType<Hero>().WaitingForPlayerAction) return;
            this.DealDamage();
        }


        protected bool CanAttack()
        {
            if (FindObjectOfType<Hero>().WaitingForPlayerAction) return false;

            this._timeSinceLastAttack += Time.deltaTime;
            ATBGauge();

            if (!(_timeSinceLastAttack >= this.weapon.weaponAttackSpeed)) return false;
            this._timeSinceLastAttack -= this.weapon.weaponAttackSpeed;
            return true;
        }

        float ATBGauge()
        {
            return this.aTBGauge.fillAmount = this._timeSinceLastAttack / this.weapon.weaponAttackSpeed;
        }

        protected void DealDamage()
        {
            this.Target.GetComponent<Unit>().Health -= this.Damage;

            if (this.Target.name != "Hero")
            {
                FindObjectOfType<Target>().GetComponent<DamageTakenUI>().SpawnDamageText(this.Damage);
                return;
            }

            this.Target.GetComponent<DamageTakenUI>().SpawnDamageText(this.Damage);
        }

        protected float UpdateHealthImage()
        {
            return this.healthImage.fillAmount = (float) this.Health / this.MaxHealth;
        }
    }
}