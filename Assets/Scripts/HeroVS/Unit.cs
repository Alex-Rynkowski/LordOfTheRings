using UnityEngine;

namespace HeroVS
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected int damage = 5;
        [SerializeField] protected int health = 100;
        [SerializeField] protected float attackSpeed;
        float _lastAttack;
        bool CanAttack => Time.time - _lastAttack > attackSpeed;


        void Update()
        {
            if (CanAttack)
            {
                print($"{this.name} is attacking dealing {damage} damage with {health} hp left");

                _lastAttack = Time.time;
            }
        }
    }
}