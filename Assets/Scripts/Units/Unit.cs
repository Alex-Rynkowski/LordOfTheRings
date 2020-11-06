using Equipment;
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

        public delegate void UpdateDamageText(object value);
        public UpdateDamageText UpdateUI;
        
        protected abstract void UpdateTarget();
        protected abstract GameObject Target { get; set; }
        protected abstract int MaxHealth { get; }
        protected abstract void UnitSetup();
        protected bool IsDead => Health <= 0;

        protected virtual int Damage
        {
            get
            {
                switch (weapon.skillType)
                {
                    case Weapon.SkillType.Physical:
                        return baseDamage + weapon.weaponDamage;
                    case Weapon.SkillType.Magical:
                        return baseSpellDamage + weapon.spellDamage;
                    case Weapon.SkillType.PhysicalAndMagical:
                        return (baseSpellDamage + weapon.spellDamage) + (baseDamage + weapon.weaponDamage);
                    default:
                        return 0;
                }
            }
        }

        protected int Health
        {
            get => _health;
            set
            {
                _health = Mathf.Clamp(value, 0, MaxHealth);
                unitName.text = $"{name} {Health}/{MaxHealth}";
            }
        }

        protected virtual void Start()
        {
            UnitSetup();
            UpdateTarget();
            aTBGauge.GetComponentInChildren<Text>().text = weapon.attackText;
        }

        protected virtual void Update()
        {
            if (Target == null) return;
            var target = FindObjectOfType<Target>();
            if (target.PlayerTarget != null && target.PlayerTarget == this.gameObject)
            {
                target.UpdateTargetInfo(UpdateHealthImage(), ATBGauge(), name, Damage.ToString(), weapon.attackText);
            }

            UpdateHealthImage();

            if (IsDead)
            {
                var tar = FindObjectOfType<Target>();
                tar.PlayerTarget = null;
                tar.ShouldShowTarget(false);
                Destroy(gameObject);
            }

            if (!CanAttack() || IsDead || Target == null || FindObjectOfType<Hero>().WaitingForPlayerAction) return;
            DealDamage();
        }


        protected bool CanAttack()
        {
            if (FindObjectOfType<Hero>().WaitingForPlayerAction) return false;

            _timeSinceLastAttack += Time.deltaTime;
            ATBGauge();

            if (!(_timeSinceLastAttack >= weapon.weaponAttackSpeed)) return false;
            _timeSinceLastAttack -= weapon.weaponAttackSpeed;
            return true;
        }

        float ATBGauge()
        {
            return aTBGauge.fillAmount = _timeSinceLastAttack / weapon.weaponAttackSpeed;
        }

        protected void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= Damage;
            UpdateUI(Damage);
        }

        protected float UpdateHealthImage()
        {
            return healthImage.fillAmount = (float) Health / MaxHealth;
        }
    }
}