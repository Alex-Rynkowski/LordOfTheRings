using UnityEngine;

namespace HeroVS
{
    [CreateAssetMenu]
    public class Weapon : ScriptableObject
    {
        public Type weaponType;
        public int weaponDamage;
        public int spellDamage;
        public float weaponAttackSpeed;
        public string description;
    }

    public enum Type
    {
        Sword,
        Axe,
        Hammer,
        Fists
    }
}