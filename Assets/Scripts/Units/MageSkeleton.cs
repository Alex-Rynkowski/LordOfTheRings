using Player_Specific;
using UnityEngine;

namespace Units
{
    public class MageSkeleton : Unit, IReward
    {
        protected override void UpdateTarget()
        {
            Target = FindObjectOfType<Hero>().gameObject;
        }

        protected override GameObject Target { get; set; }
        protected override int MaxHealth => maxHealth;

        protected override void UnitSetup()
        {
            maxHealth = MaxHealth;
            Health = MaxHealth;
        }

        public void Reward()
        {
            if (!IsDead) return;
            FindObjectOfType<PlayerGold>().Gold += 50;
        }
    }
}