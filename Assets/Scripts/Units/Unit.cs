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
        [SerializeField] Text damageTakenText;
        int _health;
        protected float _timeSinceLastAttack;

        protected bool WaitingForPlayerAction;

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
                    case SkillType.Physical:
                        return baseDamage + weapon.weaponDamage;
                    case SkillType.Magical:
                        return baseSpellDamage + weapon.spellDamage;
                    case SkillType.PhysicalAndMagical:
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
            var target = FindObjectOfType<Target>();
            if (target.PlayerTarget != null && target.PlayerTarget == this.gameObject)
            {
                print(target.PlayerTarget);
                target.UpdateTargetInfo(UpdateHealthImage(), ATBGauge(), name, Damage.ToString(), weapon.attackText);
            }

            UpdateHealthImage();

            if (IsDead)
            {
                Destroy(gameObject);
            }

            if (!CanAttack() || IsDead || Target == null || FindObjectOfType<Hero>().WaitingForPlayerAction) return;
            DealDamage();
        }

        void SpawnDamageText()
        {
            var dmgText = Instantiate(damageTakenText, new Vector3(Target.transform.position.x - 100, Target.transform.position.y, 0), Quaternion.identity);
            dmgText.transform.parent = FindObjectOfType<Canvas>().transform;
            dmgText.text = GetComponent<Unit>().Damage.ToString();
            Destroy(dmgText.gameObject, 1f);
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

        protected virtual float ATBGauge()
        {
            return aTBGauge.fillAmount = _timeSinceLastAttack / weapon.weaponAttackSpeed;
        }

        protected void DealDamage()
        {
            Target.GetComponent<Unit>().Health -= Damage;
            SpawnDamageText();
        }

        protected float UpdateHealthImage()
        {
            return healthImage.fillAmount = (float) Health / MaxHealth;
        }
    }
}