using UnityEngine;

namespace HeroVS
{
    [CreateAssetMenu]
    public class Weapon : ScriptableObject
    {
        public Type weaponType;
        public string weaponName;
        public int weaponDamage;
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