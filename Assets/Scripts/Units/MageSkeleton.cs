using Hud;
using Player_Specific;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    public class MageSkeleton : Unit, IReward, IPointerClickHandler, IUnitDeath
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
            FindObjectOfType<FloatingGoldText>().SpawnGoldText(50);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            FindObjectOfType<Target>().PlayerTarget = gameObject;
        }

        public void OnDeath()
        {
            if (!this.IsDead) return;
            this.Reward();
            this.SendMessage("Fader", SendMessageOptions.DontRequireReceiver);
        }
    }
}