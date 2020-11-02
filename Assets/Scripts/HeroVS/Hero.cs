using System;
using UnityEngine;
using UnityEngine.UI;

namespace HeroVS
{
    public class Hero : Unit
    {
        PlayerGold _playerGold;

        protected override void UpdateTarget()
        {
            if (FindObjectOfType<Enemy>() == null) return;
            Target = FindObjectOfType<Enemy>().gameObject;
        }

        protected override GameObject Target { get; set; }

        protected override int MaxHealth
        {
            get => PlayerPrefs.GetInt("MaxHealth", maxHealth);
            set
            {
                PlayerPrefs.SetInt("MaxHealth", value);
                maxHealth = value;
            }
        }

        protected override int Damage
        {
            get => PlayerPrefs.GetInt("Damage", damage + weapon.weaponDamage);
            set
            {
                PlayerPrefs.SetInt("Damage", value);
                damage = value;
            }
        }

        protected override Text UnitName
        {
            get => unitName;
            set => unitName.text = value.ToString();
        }

        void Start()
        {
            UnitName.text = this.name;
            maxHealth = MaxHealth;
            damage = Damage;
            _playerGold = FindObjectOfType<PlayerGold>();
            Health = MaxHealth;
        }

        void Update()
        {
            UpdateHealthImage();
            UpdateTarget();
            if (IsDead)
            {
                Destroy(gameObject);
            }

            if (!CanAttack || IsDead || Target == null) return;
            _waitingForPlayerAction = true;

            //print($"{this.name} is dealing {Damage} damage");

            //LastAttack = Time.time;
        }

        public void UpgradeHealth()
        {
            if (_playerGold.Gold >= 50)
            {
                _playerGold.Gold -= 50;
                MaxHealth = (int) (MaxHealth * 1.1f);
                Health = MaxHealth;
            }
        }

        public void UpgradeWeapon()
        {
            if (_playerGold.Gold >= 50)
            {
                _playerGold.Gold -= 50;
                Damage = (int) (Damage * 1.1f);
            }
        }

        public void Attack()
        {
            _waitingForPlayerAction = false;
            DealDamage();
            LastAttack = Time.time;
        }
    }
}