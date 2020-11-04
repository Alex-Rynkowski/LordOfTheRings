using UnityEngine;

namespace Equipment
{
    [CreateAssetMenu]
    public class Weapon : ScriptableObject
    {
        public WeaponType weaponType;
        public SkillType skillType;
        public int weaponDamage;
        public int spellDamage;
        public float weaponAttackSpeed;
        public string description;
        public string attackText;
    }

    public enum WeaponType
    {
        Sword,
        Axe,
        Hammer,
        Fists,
        Fireball
    }

    public enum SkillType
    {
        Physical,
        Magical,
        PhysicalAndMagical
        
    }
}